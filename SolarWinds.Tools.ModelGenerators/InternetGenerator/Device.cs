using System;
using System.Collections.Generic;
using SolarWinds.Tools.CommandLineTool.Models;
using SolarWinds.Tools.DataGeneration.Helpers.Fakes;
using SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads;

namespace SolarWinds.Tools.ModelGenerators.InternetGenerator
{
    public class Device
    {

        public Device()
        {
            this.MemoryDevices.Add(new DeviceMemory());
            this.CpuDevices.Add(new DeviceCpu());
            var totalVolumes = FakerHelper.Faker.Random.Int(1, 5);
            while (totalVolumes-- > 0)
            {
                this.VolumeDevices.Add(new DeviceVolume());
            }
        }

        public int DeviceIndex { get; set; }
        public string IpAddress { get; set; }
        public string NodeName { get; set; }
        public int OrionNodeID { get; set; }
        public int AsNumber { get; set; }
        public string CidrPrefix { get; set; }
        public string DomainName { get; set; }
        public string NetworkId { get; set; }
        public int TotalInterfaces { get; set; }
        public bool IsLocalDevice { get; set; }
        public bool IsServer { get; set; }
        public bool IsShadowNode { get; set; }
        public IList<DeviceCpu> CpuDevices { get; set; } = new List<DeviceCpu>();
        public IList<DeviceMemory> MemoryDevices { get; set; } = new List<DeviceMemory>();
        public IList<DeviceInterface> InterfaceDevices { get; set; } = new List<DeviceInterface>();
        public IList<DeviceVolume> VolumeDevices { get; set; } = new List<DeviceVolume>();

        /// <summary>
        /// Generates faked observations for all device components for the time interval specified
        /// </summary>
        public void GenerateObservation(DateTime interval, TimeRange timeRange, WorkWeek workWeek)
        {
            foreach (var deviceMemory in this.MemoryDevices)
            {
                deviceMemory.GenerateObservation(interval, timeRange, workWeek);
            }
            foreach (var deviceInterface in this.InterfaceDevices)
            {
                deviceInterface.GenerateObservation(interval, timeRange, workWeek);
            }
            foreach (var deviceVolume in this.VolumeDevices)
            {
                deviceVolume.GenerateObservation(interval, timeRange, workWeek);
            }
            foreach (var deviceCpu in this.CpuDevices)
            {
                deviceCpu.GenerateObservation(interval, timeRange, workWeek);
            }
        }
    }
}
