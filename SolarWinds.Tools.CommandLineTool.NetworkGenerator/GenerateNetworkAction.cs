using System;
using System.Linq;
using CommandLine;
using DapperExtensions;
using SolarWinds.Tools.CommandLineTool.Extensions;
using SolarWinds.Tools.DataGeneration.Helpers.Models;
using SolarWinds.Tools.CommandLineTool.Options;
using SolarWinds.Tools.DataGeneration.DAL.SwisEntities;
using SolarWinds.Tools.DataGeneration.DAL.Tables;
using SolarWinds.Tools.DataGeneration.DAL.Tables.Orion;
using SolarWinds.Tools.DataGeneration.DAL.Tables.Orion.Core.Metrics.CPULoad_CS;
using SolarWinds.Tools.DataGeneration.DAL.Tables.Orion.Core.Metrics.ResponseTime_CS;
using SolarWinds.Tools.DataGeneration.Helpers;
using SolarWinds.Tools.DataGeneration.Helpers.Fakes;
using SolarWinds.Tools.ModelGenerators.InternetGenerator.Options;

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

        public int MaxHops { get; set; }
        public int MinNodes { get; set; }
        public int ShadowNodes { get; set; }
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
                if (this.IncludeAiimAnomalies)
                {
                    this.GenerateAiimAnomalies();
                }
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

                CPULoad_CS.Populate(interval, timeRange, device);
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

        private void GenerateAiimAnomalies()
        {
            try
            {
                var f = FakerHelper.Faker;
                var anomalyObjects = AIIM_AlertConditionEntityProperty.Get<AIIM_AlertConditionEntityProperty>(
                    "SELECT DISTINCT * from Orion.AIIM.AlertConditionEntityProperty where IsAnomalyCondition = true");
                var source = f.PickRandom<AIIM_AlertConditionEntityProperty>(anomalyObjects);
                foreach (var interval in this.NextInterval())
                {
                    for (int i = 0; i < f.Random.Int(1, 10); i++)
                    {
                        var aiimAnomalyHistory = new AIIM_AnomalyHistory().Populate(interval, source);
                        DbConnectionManager.DbConnection.Insert(aiimAnomalyHistory);
                    }
                }
            }
            catch (Exception ex)
            {
                ConsoleLogger.Error(ex);
            }
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
                ConsoleLogger.Info($"Generating Volumes for {this.NetworkGenerator.Devices.Sum(_=>_.VolumeDevices.Count)} devices...");
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
