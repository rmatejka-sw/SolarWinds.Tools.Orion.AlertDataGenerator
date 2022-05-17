using System;
using System.Linq;
using CommandLine;
using DapperExtensions;
using SolarWinds.Tools.CommandLineTool.Options;
using SolarWinds.Tools.DataGeneration.DAL.Tables;
using SolarWinds.Tools.DataGeneration.DAL.Tables.Orion;
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
        public string OrionUserName { get; set; }
        public string OrionPassword { get; set; }

        public RunStatus Run(DateTime? timeInterval = null)
        {
            try
            {
                if (timeInterval == null)
                {
                    if (this.DeleteFakesBefore)
                    {
                        this.NetworkGenerator.DeleteFakes();
                    }
                    this.GenerateStaticData();
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


        private void GenerateNodesForDevices()
        {
            try
            {
                foreach (var device in this.NetworkGenerator.Devices)
                {
                    try
                    {
                        if (device.IsShadowNode)
                        {
                            var shadowNode = new ShadowNodes().Populate();
                            shadowNode.NodeId = TableBase<ShadowNodes>.GetMaxId("NodeId")+1;
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

        private void GenerateInterfacesForDevices()
        {
            try
            {
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
                foreach (var device in this.NetworkGenerator.Devices)
                {
                    var volumeCount = FakerHelper.Faker.Random.Int(1, 5);
                    for (int volumeIndex = 1; volumeIndex <= volumeCount; volumeIndex++)
                    {
                        var volume = new Volumes().Populate(device.NodeName, device.OrionNodeID, volumeIndex);
                        var result = DbConnectionManager.DbConnection.Insert(volume);
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
