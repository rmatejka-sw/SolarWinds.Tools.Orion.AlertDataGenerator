﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using DapperExtensions;
using SolarWinds.Tools.DataGeneration.Helpers.Models;
using SolarWinds.Tools.DataGeneration.DAL.Tables.Orion;
using SolarWinds.Tools.DataGeneration.DAL.Tables.Orion.Core;
using SolarWinds.Tools.DataGeneration.Helpers;
using SolarWinds.Tools.DataGeneration.Helpers.Fakes;
using SolarWinds.Tools.ModelGenerators.InternetGenerator;

namespace SolarWinds.Tools.CommandLineTool.NetworkGenerator
{
    public class NetworkGenerator : CommandLineTool
    {

        public override IList<ICommandLineAction> Actions => new List<ICommandLineAction>
        {
            new DeleteFakesAction(),
            new GenerateNetworkAction(),
            new UpdateStatusAction()
        };

        //10% of auto edges also has manual edges
        private const int AutoEdgeVsManualEdgeRatio = 10;
        private readonly Dictionary<int, Device> devicesByIndex = new Dictionary<int, Device>();
        private readonly List<DeviceInterface> deviceInterfaces = new List<DeviceInterface>();
        private readonly List<DeviceConnection> deviceConnections = new List<DeviceConnection>();
        private InternetNetworkGenerator internetNetworkGenerator;
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
                throw;
            }
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

    }
}
