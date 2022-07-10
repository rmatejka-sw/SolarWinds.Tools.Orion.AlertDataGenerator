using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Dapper;
using DapperExtensions;
using SolarWinds.Tools.DataGeneration.DAL.Tables;
using SolarWinds.Tools.DataGeneration.DAL.Tables.Orion;
using SolarWinds.Tools.DataGeneration.DAL.Tables.Orion.Core;
using SolarWinds.Tools.DataGeneration.Helpers;
using SolarWinds.Tools.ModelGenerators.Fakes;
using SolarWinds.Tools.ModelGenerators.InternetGenerator;
using SolarWinds.Tools.ModelGenerators.Metrics;

namespace SolarWinds.Tools.CommandLineTool.NetworkGenerator
{
    public class NetworkGenerator : CommandLineTool
    {

        public override IList<ICommandLineAction> Actions => new List<ICommandLineAction>
        {
            new DeleteFakesAction(),
            new GenerateNetworkAction(),
            new UpdateStatusAction(),
            new TriggerAnomalyBasedAlertsAction()
        };

        //10% of auto edges also has manual edges
        private const int AutoEdgeVsManualEdgeRatio = 10;
        private readonly Dictionary<int, Device> devicesByIndex = new Dictionary<int, Device>();
        private readonly List<DeviceInterface> deviceInterfaces = new List<DeviceInterface>();
        private readonly List<DeviceConnection> deviceConnections = new List<DeviceConnection>();
        private InternetNetworkGenerator internetNetworkGenerator;
        private IList<string> currentAnomalySourceUris = new List<string>();
        public NetworkGenerator()
        {
        }

        public override void PreInitializeServices()
        {
            base.PreInitializeServices();
        }

        private static int Main(string[] args)
        {
            return new NetworkGenerator().Run(args);
        }

        public IQueryable<AlertObjects> AlertObjects { get; set; }

        public void CreateAlertForAnomaly(Events anomalyEvent)
        {
            try
            {
                var eventAlerts = this.AlertObjects.Select(ao => ao.EntityNetObjectId == $"{anomalyEvent.NetObjectType}:{anomalyEvent.NetObjectID}").ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine($"CreateAlertForAnomaly: {e.Message}");
            }
        }

        public IReadOnlyList<Device> Devices => this.devicesByIndex.Values.ToList().AsReadOnly();
        public IReadOnlyList<DeviceInterface> Interfaces => this.deviceInterfaces.AsReadOnly();
        public IReadOnlyList<DeviceConnection> Connections => this.deviceConnections.AsReadOnly();

        public int UpdateStatuses()
        {
            try
            {
                var fakedNodes = DbConnectionManager.DbConnection.Query<NodesData>($"SELECT * FROM NodesData where IOSImage='{FakerHelper.FakeMarker}'");
                foreach (var node in fakedNodes)
                {
                    //node.UpdateData();
                    DbConnectionManager.DbConnection.Update<NodesData>(node);
                }
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"UpdateStatuses failed: {ex.Message}");
            }

            return 0;
        }

        public int CreateNetworkElements(GenerateNetworkAction options)
        {
            ConsoleLogger.Info($"Creating test network...");
            internetNetworkGenerator = new InternetNetworkGenerator(options);
            internetNetworkGenerator.CreateNetworks();
            this.deviceConnections.Clear();
            this.deviceInterfaces.Clear();
            this.deviceConnections.AddRange(internetNetworkGenerator.DeviceConnections);
            this.deviceInterfaces.AddRange(internetNetworkGenerator.DeviceInterfaces);
            this.devicesByIndex.Clear();
            ConsoleLogger.Info($"Created {internetNetworkGenerator.Devices.Count} Devices");
            ConsoleLogger.Info($"Created {internetNetworkGenerator.DeviceInterfaces.Count} Device Interfaces");
            foreach (var device in internetNetworkGenerator.Devices)
            {
                this.devicesByIndex[device.DeviceIndex] = device;
            }

            return internetNetworkGenerator.TotalNetworks;
        }


        public void PopulateMetrics(TimeRange timeRange)
        {
            internetNetworkGenerator.PopulateMetrics(timeRange);
        }


        public void TriggerAnomalyBasedAlerts(TimeRange timeRange, int maxAlerts)
        {
            try
            {
                //GenerateNetwork --IncludeAiimAnomalies --DeleteFakesBefore --pastDays 7 --futureDays 7
                var totalAlerts = 0;
                foreach (var pollingInterval in timeRange.PollingIntervals())
                {
                    ConsoleLogger.Success($">>>>>>>>> INTERVAL {pollingInterval}");
                    var anomalies = AIIM_AnomalyHistory.GetList(
                            $"SELECT * FROM AIIM_AnomalyHistory WHERE MeasurementTimeUtc between '{pollingInterval:O}' and '{(pollingInterval.AddMinutes(10)):O}' ")
                        .ToList();
                    foreach (var aiimAnomalyHistory in anomalies)
                    {
                        totalAlerts += this.TriggerAnomalyBasedAlertsForHistory(aiimAnomalyHistory);
                    }
                    this.ResetUntriggeredAnomalies(anomalies);
                    if (maxAlerts > 0 && totalAlerts > maxAlerts)
                    {
                        ConsoleLogger.Success($"Completed triggering {totalAlerts} alerts.");
                        return;
                    }
                    ConsoleLogger.Success($"Waiting for next interval..");
                    Thread.Sleep((int)timeRange.PollingInterval.TotalMilliseconds);
                }
            }
            catch (Exception ex)
            {
                ConsoleLogger.Error(ex);
            }
        }

        private void ResetUntriggeredAnomalies(IList<AIIM_AnomalyHistory> triggeredAnomalies)
        {
            var nodeAnomalies = AIIM_Orion_Nodes_Anomalies.GetList(true);
            foreach (var nodeAnomaly in nodeAnomalies)
            {
                var triggered = triggeredAnomalies.Where(_ => _.SourceUri == nodeAnomaly.SourceUri).ToList();
                var triggeredMetrics = triggered.Select(_ => _.MetricId).ToList();
                nodeAnomaly.OrionCPULoadAvgPercentMemoryUsedIsAnomalous = triggeredMetrics.Contains("Orion.CPULoad.AvgPercentMemoryUsed");
                nodeAnomaly.OrionResponseTimeAvgResponseTimeIsAnomalous = triggeredMetrics.Contains("Orion.ResponseTime.AvgResponseTime");
                nodeAnomaly.OrionCPULoadAvgLoadIsAnomalous = triggeredMetrics.Contains("Orion.CPULoad.AvgLoad");
                nodeAnomaly.OrionResponseTimePercentLossIsAnomalous = triggeredMetrics.Contains("Orion.ResponseTime.PercentLoss");
                var updated = DbConnectionManager.DbConnection.Update(nodeAnomaly);
                ConsoleLogger.Info(@$"Reset IsAnomalous on {nodeAnomaly.SourceUri}: 
CPULoadAvgPercentMemoryUsedIsAnomalous:{nodeAnomaly.OrionCPULoadAvgPercentMemoryUsedIsAnomalous}
ResponseTimeAvgResponseTimeIsAnomalous:{nodeAnomaly.OrionResponseTimeAvgResponseTimeIsAnomalous}
CPULoadAvgLoadIsAnomalous:{nodeAnomaly.OrionCPULoadAvgLoadIsAnomalous}
ResponseTimePercentLossIsAnomalous:{nodeAnomaly.OrionResponseTimePercentLossIsAnomalous}
");
            }
        }

        private int TriggerAnomalyBasedAlertsForHistory(AIIM_AnomalyHistory aiimAnomalyHistory)
        {
            try
            {
                var aiopsMetricStatus = new AIIM_AiOpsMetricStatus().Populate(aiimAnomalyHistory);
                DbConnectionManager.DbConnection.Insert(aiopsMetricStatus);
                switch (aiimAnomalyHistory.SourceInstanceType)
                {
                    case "Orion.Nodes":
                        var nodeAnomaly = AIIM_Orion_Nodes_Anomalies
                            .GetList(
                                @$"SELECT [SourceUri]
                            ,[Orion_CPULoad_AvgLoadDisplayName]
                        ,[Orion_CPULoad_AvgLoadIsAnomalous]
                        ,[Orion_CPULoad_AvgLoadUnits]
                        ,[Orion_CPULoad_AvgLoadValue]
                        ,[Orion_CPULoad_AvgPercentMemoryUsedDisplayName]
                        ,[Orion_CPULoad_AvgPercentMemoryUsedIsAnomalous]
                        ,[Orion_CPULoad_AvgPercentMemoryUsedUnits]
                        ,[Orion_CPULoad_AvgPercentMemoryUsedValue]
                        ,[Orion_ResponseTime_AvgResponseTimeDisplayName]
                        ,[Orion_ResponseTime_AvgResponseTimeIsAnomalous]
                        ,[Orion_ResponseTime_AvgResponseTimeUnits]
                        ,[Orion_ResponseTime_AvgResponseTimeValue]
                        ,[Orion_ResponseTime_PercentLossDisplayName]
                        ,[Orion_ResponseTime_PercentLossIsAnomalous]
                        ,[Orion_ResponseTime_PercentLossUnits]
                        ,[Orion_ResponseTime_PercentLossValue] FROM AIIM_Orion_Nodes_Anomalies where SourceUri='{aiimAnomalyHistory.SourceUri}'")
                            .FirstOrDefault();
                        if (nodeAnomaly == null)
                        {
                            nodeAnomaly = new AIIM_Orion_Nodes_Anomalies().Populate(aiimAnomalyHistory);
                            DbConnectionManager.DbConnection.Insert(nodeAnomaly);
                            ConsoleLogger.Success($"Triggered anomaly alert for {aiimAnomalyHistory.MetricId} on {aiimAnomalyHistory.SourceUri}");
                        }
                        else
                        {
                            nodeAnomaly.Populate(aiimAnomalyHistory);
                            DbConnectionManager.DbConnection.Update(nodeAnomaly);
                        }
                        break;
                    case "Orion.Volumes":
                        var volumeAnomaly = AIIM_Orion_Volumes_Anomalies.GetList(
                            $@"SELECT [SourceUri]
                              ,[Orion_VolumeUsageHistory_PercentDiskUsedDisplayName]
                              ,[Orion_VolumeUsageHistory_PercentDiskUsedIsAnomalous]
                              ,[Orion_VolumeUsageHistory_PercentDiskUsedUnits]
                              ,[Orion_VolumeUsageHistory_PercentDiskUsedValue]
                              ,[Orion_VolumeUsageHistory_PercentDiskUsedStatus]
                          FROM [dbo].[AIIM_Orion_Volumes_Anomalies] where SourceUri='{aiimAnomalyHistory.SourceUri}'").FirstOrDefault();
                        if (volumeAnomaly == null)
                        {
                            volumeAnomaly = new AIIM_Orion_Volumes_Anomalies().Populate(aiimAnomalyHistory);
                            DbConnectionManager.DbConnection.Insert(volumeAnomaly);
                            ConsoleLogger.Success($"Triggered anomaly alert for {aiimAnomalyHistory.MetricId} on {aiimAnomalyHistory.SourceUri}");
                        }
                        else
                        {
                            volumeAnomaly.Populate(aiimAnomalyHistory);
                            DbConnectionManager.DbConnection.Update(volumeAnomaly);
                        }
                        break;
                }

                return 1;
            }
            catch (Exception ex)
            {
                ConsoleLogger.Error(ex);
            }

            return 0;
        }
    }
}
