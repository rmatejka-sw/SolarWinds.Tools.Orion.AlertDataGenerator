using System;
using System.Collections.Generic;
using SolarWinds.Tools.DataGeneration.Helpers.Fakes;
using SolarWinds.Tools.DataGeneration.Helpers.Models;
using SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceComponents;
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
            while (this.VolumeDevices.Count < totalVolumes)
            {
                this.VolumeDevices.Add(new DeviceVolume(this.VolumeDevices.Count+1));
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
        public DeviceLoad Load { get; } = new DeviceLoad();
        public DeviceResponseTime ResponseTime { get; } = new DeviceResponseTime();
        public DeviceAvailability Availability { get; } = new DeviceAvailability();

        /// <summary>
        /// Generates faked observations for all device components for the time interval specified
        /// </summary>
        public void GenerateObservation(DateTime interval, TimeRange timeRange, WorkWeek workWeek)
        {
            double intervalsPerHour = 60/timeRange.PollingInterval.TotalMinutes;
            this.Load.GenerateObservation(interval, timeRange, workWeek);
            var responseTime = this.ResponseTime.GenerateObservation(interval, timeRange, workWeek, 0.01);
            this.Availability.MetricData.RecordObservation(interval, responseTime >= this.ResponseTime.MetricData.Max ? 0 : 100);
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
                deviceVolume.VolumeUsage.GenerateObservation(interval, timeRange, workWeek);
            }
            foreach (var deviceCpu in this.CpuDevices)
            {
                deviceCpu.GenerateObservation(interval, timeRange, workWeek);
            }
        }
    }
}
