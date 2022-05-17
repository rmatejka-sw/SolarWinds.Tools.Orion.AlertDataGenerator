using System;
using System.Runtime.CompilerServices;
using SolarWinds.Tools.DataGeneration.DAL.Tables.Orion;
using SolarWinds.Tools.DataGeneration.Helpers;
using SolarWinds.Tools.ModelGenerators.InternetGenerator;

namespace SolarWinds.Tools.CommandLineTool.NetworkGenerator.Extensions
{
    public static class DeviceExtensions
    {

        public static NodesData PopulateNodesData(this Device device)
        {
            try
            {
                var newNode = new NodesData().Populate();
                newNode.IPAddress = device.IpAddress;
                newNode.Caption = $"{device.NodeName}-FAKE{device.DeviceIndex}";
                newNode.DNS = device.DomainName;
            }
            catch (Exception e)
            {
                ConsoleLogger.Error(e);
            }
            return null;
        }
    }
}
