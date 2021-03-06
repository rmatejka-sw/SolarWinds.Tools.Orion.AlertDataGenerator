using System;
using System.Linq;
using CommandLine;
using DapperExtensions;
using SolarWinds.Tools.CommandLineTool.Extensions;
using SolarWinds.Tools.CommandLineTool.Options;
using SolarWinds.Tools.DataGeneration.DAL.SwisEntities;
using SolarWinds.Tools.DataGeneration.DAL.Tables;
using SolarWinds.Tools.DataGeneration.DAL.Tables.Orion;
using SolarWinds.Tools.DataGeneration.DAL.Tables.Orion.Core.Metrics.CPULoad_CS;
using SolarWinds.Tools.DataGeneration.DAL.Tables.Orion.Core.Metrics.ResponseTime_CS;
using SolarWinds.Tools.DataGeneration.Helpers;
using SolarWinds.Tools.ModelGenerators.Fakes;
using SolarWinds.Tools.ModelGenerators.InternetGenerator;
using SolarWinds.Tools.ModelGenerators.InternetGenerator.Options;
using SolarWinds.Tools.ModelGenerators.Metrics;

namespace SolarWinds.Tools.CommandLineTool.NetworkGenerator
{
    [Verb("GenerateNetwork")]
    public class GenerateNetworkAction : ActionBase, ICommandLineAction, IInternetGeneratorOptions, IDatabaseOptions, ITimeRangeOptions,
    IOrionOptions
    {
        [Option('d', "DeleteFakesBefore", Default = false, HelpText = "Delete any previously generated fakes before generating new fakes.")]
        public bool DeleteFakesBefore { get; set; }
        [Option("IncludeAiimAnomalies", Default = false, HelpText = "If true, populates AIIM anomaly history table (AIIM_AnomalyHistory).")]
        public bool IncludeAiimAnomalies { get; set; }

        [Option("MaxHops", Default = 10, HelpText = "Maximum number of hops between start and end nodes in a network.")]
        public int MaxHops { get; set; }

        [Option("MinNodes", Default = 50, HelpText = "Minimum number of nodes to create.")]
        public int MinNodes { get; set; }

        [Option("ShadowNodes", Default = 2, HelpText = "Percentage of nodes that will be created as Shadow Nodes")]
        public int ShadowNodes { get; set; }

        [Option("MaxInternalNodes", Default = 10, HelpText = "Maximum number of nodes for an internal network address space")]
        public int MaxInternalNodes { get; set; }

        public int MaxConnectionsBetweenNodes { get; set; }
        public bool ExcludeIntranetDevices { get; set; }
        public string DbServerName { get; set; }
        public string DbName { get; set; }
        public string DbUserName { get; set; }
        public string DbPassword { get; set; }
        public int PastDays { get; set; }
        public int FutureDays { get; set; }
        public int PollingInterval { get; set; }
        public string OrionServerName { get; set; }
        public bool UseHttps { get; set; }
        public string OrionUserName { get; set; }
        public string OrionPassword { get; set; }


        public RunStatus Run(DateTime? timeInterval = null, TimeRange timeRange = null)
        {
            try
            {
                if (timeInterval == null)
                {
                    if (this.DeleteFakesBefore)
                    {
                        ConsoleLogger.Info($"Deleting previously generated fake data...");
                        DeleteFakesAction.DeleteFakes();
                    }
                    this.GenerateStaticData();
                    this.NetworkGenerator.PopulateMetrics(timeRange);
                }
                else
                {
                    this.GenerateMetrics(timeInterval.Value, timeRange);
                }
            }
            catch (Exception e)
            {
                ConsoleLogger.Error(e);
            }

            return RunStatus.CommandError;
        }

        public void AfterRun()
        {
        }

        public void BeforeRun(CommandLineTool commandLineTool)
        {
            this.NetworkGenerator = commandLineTool as NetworkGenerator;
            if (this.NetworkGenerator == null)
            {
                ConsoleLogger.Error("BeforeRun failed to cast commandLineTool to NetworkGenerator");
                return;
            }
            this.NetworkGenerator.CreateNetworkElements(this);
        }

        private void GenerateStaticData()
        {
            try
            {
                this.GenerateNodesForDevices();
                this.GenerateInterfacesForDevices();
                this.GenerateVolumesForDevices();
            }
            catch (Exception e)
            {
                ConsoleLogger.Error(e);
            }
        }


        private void GenerateMetrics(DateTime interval, TimeRange timeRange)
        {
            ConsoleLogger.Info($"Generating metrics for {interval}");
            this.GenerateNodeMetricsForDevices(interval, timeRange);
            this.GenerateInterfaceMetricsForDevices(interval, timeRange);
            if (this.IncludeAiimAnomalies)
            {
                this.GenerateAiimAnomalies(interval, timeRange);
            }
        }


        private void GenerateNodesForDevices()
        {
            try
            {
                ConsoleLogger.Info($"Generating nodes for {this.NetworkGenerator.Devices.Count} devices...");
                foreach (var device in this.NetworkGenerator.Devices)
                {
                    try
                    {
                        if (device.IsShadowNode)
                        {
                            var shadowNode = new ShadowNodes().Populate();
                            shadowNode.NodeId = TableBase<ShadowNodes>.GetMaxId("NodeId") + 1;
                            DbConnectionManager.DbConnection.Insert(shadowNode);
                        }
                        else
                        {
                            var node = new NodesData().Populate();
                            node.Caption = $"{device.NodeName}-FAKE{device.DeviceIndex}";
                            node.DNS = node.IPAddress = device.IpAddress;
                            node.Description = $"{device.NodeName}-{device.NetworkId}";
                            node.NodeID = device.OrionNodeID = (int)DbConnectionManager.DbConnection.Insert(node);
                            var nodeStatistics = new NodesStatistics();
                            nodeStatistics.Populate(node);
                            DbConnectionManager.DbConnection.Insert<NodesStatistics>(nodeStatistics);
                            if (FakerHelper.Faker.Random.Int(1, 100) > 20)
                            {
                                var customProperties = new NodesCustomProperties().Populate();
                                customProperties.NodeID = (int)node.NodeID;
                                DbConnectionManager.DbConnection.Insert(customProperties);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        ConsoleLogger.Error(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                ConsoleLogger.Error(ex);
            }
        }

        private void GenerateNodeMetricsForDevices(DateTime interval, TimeRange timeRange)
        {
            foreach (var device in this.NetworkGenerator.Devices)
            {
                if (device.IsShadowNode) continue;
                CPULoad_CS.Populate(interval, timeRange, device);
                ResponseTime_CS.Populate(interval, timeRange, device);
                foreach (var deviceVolume in device.VolumeDevices)
                {
                    VolumeUsage_CS.Populate(interval, timeRange, device, deviceVolume);
                }
            }
        }
        private void GenerateInterfaceMetricsForDevices(DateTime interval, TimeRange timeRange)
        {
            foreach (var deviceInterface in this.NetworkGenerator.Interfaces)
            {

                //CPULoad_CS.Populate(interval, timeRange, device);
            }
        }

        private void GenerateAiimAnomalies(DateTime interval, TimeRange timeRange)
        {
            try
            {
                var nodes = System_ManagedEntity.GetManagedEntity("SELECT * FROM System.ManagedEntity WHERE InstanceType = 'Orion.Nodes'");
                foreach (var device in this.NetworkGenerator.Devices)
                {
                    if (device.IsShadowNode) continue;
                    var entityInstance = nodes.FirstOrDefault(_ => _.Uri.EndsWith($"={device.OrionNodeID}"));
                    if (entityInstance == null)
                    {
                        ConsoleLogger.Error($"Orion.Node {device.OrionNodeID} not found.");
                        continue;
                    }
                    GenerateMetricAnomaly(interval, timeRange, device, "Orion.ResponseTime.AvgResponseTime", device.ResponseTime.MetricData, entityInstance);
                    GenerateMetricAnomaly(interval, timeRange, device, "Orion.CPULoad.AvgLoad", device.Load.MetricData, entityInstance);
                    foreach (var memory in device.MemoryDevices)
                    {
                        GenerateMetricAnomaly(interval, timeRange, 
                            device, 
                            "Orion.CPULoad.AvgPercentMemoryUsed", 
                            memory.MetricData, 
                            entityInstance,
                            (MetricData md)=>(md as MemoryMetricData)?.PercentUsed??md.Current);
                    }
                }
            }
            catch (Exception ex)
            {
                ConsoleLogger.Error(ex);
            }
        }

        private static void GenerateMetricAnomaly(DateTime interval,
            TimeRange timeRange,
            Device device,
            string metricId,
            MetricData metricData,
            System_ManagedEntity entityInstance,
            Func<MetricData,double> getMetricValue = null)
        {
            var observation = metricData.RestoreTo(interval, timeRange);
            if (!observation.IsAnomalous)
            {
                var aiopsMetricStatus = new AIIM_AiOpsMetricStatus().Populate(
                    interval, 
                    entityInstance.Uri,
                    metricId);
                DbConnectionManager.DbConnection.Insert(aiopsMetricStatus);
                return;
            };
            var aiimAnomalyHistory = new AIIM_AnomalyHistory()
                .Populate(interval, device, entityInstance,
                    metricId,
                    observation,
                    getMetricValue?.Invoke(metricData) ?? metricData.Current);
            DbConnectionManager.DbConnection.Insert(aiimAnomalyHistory);
            metricData.RestoreToLatest();
        }

        private void GenerateInterfacesForDevices()
        {
            try
            {
                ConsoleLogger.Info($"Generating Interfaces for {this.NetworkGenerator.Interfaces.Count} interfaces...");
                foreach (var deviceInterface in this.NetworkGenerator.Interfaces)
                {
                    var device = this.NetworkGenerator.Devices.FirstOrDefault(d => d.DeviceIndex == deviceInterface.DeviceIndex);
                    var orionInterface = new Interfaces().Populate(device.OrionNodeID, deviceInterface.Name, deviceInterface.InterfaceIndex);
                    var result = DbConnectionManager.DbConnection.Insert(orionInterface);
                    deviceInterface.OrionInterfaceID = (int)result.InterfaceID;
                }
            }
            catch (Exception ex)
            {
                ConsoleLogger.Error(ex);
            }
        }

        private void GenerateVolumesForDevices()
        {
            try
            {
                ConsoleLogger.Info($"Generating Volumes for {this.NetworkGenerator.Devices.Sum(_ => _.VolumeDevices.Count)} devices...");
                foreach (var device in this.NetworkGenerator.Devices)
                {
                    foreach (var volume in device.VolumeDevices)
                    {
                        var orionVolume = new Volumes().Populate(device, volume);
                        var result = DbConnectionManager.DbConnection.Insert(orionVolume);
                        volume.OrionNodeId = (int)result.NodeID;
                        volume.OrionVolumeId = (int)result.VolumeID;
                    }
                }
            }
            catch (Exception ex)
            {
                ConsoleLogger.Error(ex);
            }
        }
    }
}
