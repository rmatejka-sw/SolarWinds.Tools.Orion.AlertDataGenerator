﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using DapperExtensions;
using SolarWinds.Tools.DataGeneration.DAL.Tables.Orion;
using SolarWinds.Tools.DataGeneration.DAL.Tables.Orion.Core;
using SolarWinds.Tools.DataGeneration.Helpers;
using SolarWinds.Tools.ModelGenerators.InternetGenerator;

namespace SolarWinds.Tools.CommandLineTool.NetworkGenerator
{
    public class NetworkGenerator : CommandLineTool
    {
        public const long GigaBytes = 1024 ^ 3;

        public override IList<ICommandLineAction> Actions => new List<ICommandLineAction>
        {

        };

        //10% of auto edges also has manual edges
        private const int AutoEdgeVsManualEdgeRatio = 10;
        private readonly char pathDelimiter = '-';
        private string[] paths;
        private readonly Dictionary<int, Device> devicesByIndex = new Dictionary<int, Device>();
        private readonly List<DeviceInterface> deviceInterfaces = new List<DeviceInterface>();
        private readonly List<DeviceConnection> deviceConnections = new List<DeviceConnection>();

        public NetworkGenerator(string[] args) : base(args)
        {
            CreateNetworkElements();

        }
        private static int Main(string[] args)
        {
            var app = new NetworkGenerator(args);
            return 0;
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
                throw;
            }
        }

        private int CreateNetworkElements()
        {
            var internet = new InternetNetworkGenerator(this.Options);
            this.deviceConnections.Clear();
            this.deviceInterfaces.Clear();
            this.deviceConnections.AddRange(internet.DeviceConnections);
            this.deviceInterfaces.AddRange(internet.DeviceInterfaces);
            this.devicesByIndex.Clear();
            foreach (var device in internet.Devices)
            {
                this.devicesByIndex[device.DeviceIndex] = device;
            }

            return internet.TotalNetworks;
        }


        private void CreateDevice(int deviceId, int shadowNodes)
        {
            if (this.devicesByIndex.ContainsKey(deviceId))
            {
                return;
            }

            var shadowNodePercentage = shadowNodes;

            this.devicesByIndex.Add(
                deviceId,
                new Device
                {
                    DeviceIndex = deviceId,
                    IpAddress = FakerHelper.Faker.Internet.Ip(),
                    NodeName = FakerHelper.Faker.Internet.DomainName(),
                    IsShadowNode = FakerHelper.Faker.Random.Int(1, 100) <= shadowNodePercentage
                });
        }

        private void ConnectDevices(int sourceDeviceId, int targetDeviceId)
        {
            var source = this.devicesByIndex[sourceDeviceId];
            var target = this.devicesByIndex[targetDeviceId];
            if (this.deviceConnections.Any(c => c.SourceDeviceIndex == source.DeviceIndex && c.TargetDeviceIndex == targetDeviceId))
            {
                return;
            }

            this.deviceConnections.Add(
                new DeviceConnection
                {
                    SourceDeviceIndex = sourceDeviceId,
                    TargetDeviceIndex = targetDeviceId,
                    SourceDeviceInterfaceIndex = source.IsShadowNode ? 0 : CreateDeviceInterface(source).InterfaceIndex,
                    TargetDeviceInterfaceIndex = target.IsShadowNode ? 0 : CreateDeviceInterface(target).InterfaceIndex
                });
        }

        private DeviceInterface CreateDeviceInterface(Device device)
        {
            int totalInterfaces = this.deviceInterfaces.Count(di => di.DeviceIndex == device.DeviceIndex);
            var deviceInterface = new DeviceInterface
            {
                DeviceIndex = device.DeviceIndex,
                InterfaceIndex = totalInterfaces + 1,
                Name = $"{device.NodeName} - eth{totalInterfaces}"
            };
            this.deviceInterfaces.Add(deviceInterface);
            return deviceInterface;
        }

        public void DeleteFakes()
        {
            try
            {
                var fakeNodes = DbConnectionManager.DbConnection.Query<Int32>($"SELECT NodeID from NodesData WHERE IOSImage ='{FakerHelper.FakeMarker}'").ToList();
                var relatedTables = new[]
                    {
                        "CPULoad_CS_cur",
                        "CPULoad_CS_Daily_hist",
                        "CPULoad_CS_Detail_hist",
                        "CPULoad_CS_Hourly_hist",
                        "CPUMultiLoad_CS_cur",
                        "CPUMultiLoad_CS_Daily_hist",
                        "CPUMultiLoad_CS_Detail_hist",
                        "CPUMultiLoad_CS_Hourly_hist",
                        "InterfaceAvailability_CS_cur",
                        "InterfaceAvailability_CS_Daily_hist",
                        "InterfaceAvailability_CS_Detail_hist",
                        "InterfaceAvailability_CS_Hourly_hist",
                        "InterfaceErrors_CS_cur",
                        "InterfaceErrors_CS_Daily_hist",
                        "InterfaceErrors_CS_Detail_hist",
                        "InterfaceErrors_CS_Hourly_hist",
                        "InterfaceTraffic_CS_cur",
                        "InterfaceTraffic_CS_Daily_hist",
                        "InterfaceTraffic_CS_Detail_hist",
                        "InterfaceTraffic_CS_Hourly_hist",
                        "InterfaceTrafficUtil_Daily",
                        "LoadAverage_CS_cur",
                        "LoadAverage_CS_Daily_hist",
                        "LoadAverage_CS_Detail_hist",
                        "LoadAverage_CS_Hourly_hist",
                        "ResponseTime_CS_cur",
                        "ResponseTime_CS_Daily_hist",
                        "ResponseTime_CS_Detail_hist",
                        "ResponseTime_CS_Hourly_hist",
                        "VolumeUsage_CS_cur",
                        "VolumeUsage_CS_Daily_hist",
                        "VolumeUsage_CS_Detail_hist",
                        "VolumeUsage_CS_Hourly_hist",
                        "NodesStatistics",
                        "NodesCustomProperties"
                    };
                var command = new StringBuilder();
                foreach (var nodeID in fakeNodes)
                {
                    foreach (var table in relatedTables)
                    {
                        command.AppendLine($"DELETE dbo.{table} where NodeID={nodeID};");
                    }
                    command.AppendLine($"DELETE dbo.TopologyConnections where SourceNodeID={nodeID} or MappedNodeID={nodeID};");
                   // DbConnectionManager.DbConnection.ExecuteNonQuery(command.ToString());
                    command.Clear();
                }
                command.AppendLine($"DELETE dbo.AIIM_AnomalyHistory;");
                command.AppendLine($"DELETE dbo.NodesData where IOSImage='{FakerHelper.FakeMarker}';");
                command.AppendLine($"DELETE dbo.ShadowNodes where NodeName like'%{FakerHelper.FakeName}%';");
                command.AppendLine($"DELETE dbo.Interfaces where Comments='{FakerHelper.FakeMarker})';");
                command.AppendLine($"DELETE dbo.Events where EventType={Events.AnomalyDetectedTypeId};");
                command.AppendLine($"DELETE dbo.Events where EventType={Events.AnomalyDetectedTypeId};");
                command.AppendLine($"DELETE dbo.Volumes where VolumeDescription like'%{FakerHelper.FakeName}%';");
                //DbConnectionManager.DbConnection.ExecuteNonQuery(command.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"DeleteFakes failed: {ex.Message}");
            }
        }

    }
}