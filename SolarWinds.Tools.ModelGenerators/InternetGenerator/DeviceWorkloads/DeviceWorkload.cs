using System;
using System.Collections.Generic;
using System.Linq;
using SolarWinds.Tools.DataGeneration.Helpers.Fakes;
using SolarWinds.Tools.DataGeneration.Helpers.Models;

namespace SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads
{
    /// <summary>
    /// Represents a specific type of work that is done on a device which can impact the device
    /// memory, cpu, interface, and other component metrics. For example, workload for a backup task
    /// would affect cpu, memory, interface bandwidth, and volume space. Workload segments  are used to
    /// describe the overall shape or envelope for the workload over time. It is very similar to the concept of
    /// an Attack, Decay, Sustain, Release envelope used in waveform generation.
    /// </summary>
    public class DeviceWorkload
    {
        public static char segmentDefinitionListSeparator = '|';

        public DeviceWorkload(string name, string segmentDefinitionList)
        {
            var segmentDefinitions = segmentDefinitionList.Split(segmentDefinitionListSeparator);
            this.Definition = new WorkloadDefinition(segmentDefinitions);
            WorkLevel = new UtilizationMetricData();
            this.Name = name;
            this.ComponentAffects = new List<ComponentAffect>();
        }

        public WorkloadDefinition Definition { get;}
        public UtilizationMetricData WorkLevel { get; }

        public string Name { get; }

        /// <summary>
        /// The components
        /// </summary>
        public IList<ComponentAffect> ComponentAffects { get; set; }

        public DeviceWorkload Affects(ComponentType componentType, AffectBehavior behavior, float by)
        {
            var componentAffect = this.ComponentAffects.FirstOrDefault(_ => _.ComponentTypes == componentType);
            if (componentAffect == null)
            {
                componentAffect = new ComponentAffect(componentType, this);
                componentAffect.Behavior = behavior;
                componentAffect.AffectWeight = by;
                this.ComponentAffects.Add(componentAffect);
            }

            return this;
        }

        public void GenerateDeviceMetricData(TimeRange timeRange, IList<Device> devices)
        {
            var intervalIndex = 0;
            var workLevels = this.Definition.WorkloadLevels().ToList();
            foreach (var pollingInterval in timeRange.PollingIntervals())
            {
                var workLevel = intervalIndex > workLevels.Count - 1 ? 0 : workLevels[intervalIndex];
                this.WorkLevel.RecordObservation(pollingInterval, workLevel);
                foreach (var device in devices)
                {
                    this.GenerateDeviceMetricData(pollingInterval, device, workLevel);
                }

                intervalIndex++;
            }
        }

        private void GenerateDeviceMetricData(DateTime pollingInterval, Device device, double workLevel)
        {
            foreach (var component in device.MemoryDevices)
            {
                var affects = this.ComponentAffects.FirstOrDefault(_ => (_.ComponentTypes & ComponentType.Memory) != 0);
                component.MetricData.RecordObservation(pollingInterval, workLevel * affects?.AffectWeight??0);
            }
            foreach (var component in device.InterfaceDevices)
            {
                var affects = this.ComponentAffects.FirstOrDefault(_ => (_.ComponentTypes & ComponentType.Interface) != 0);
                component.MetricData.RecordObservation(pollingInterval, workLevel * affects?.AffectWeight??0);
            }
            foreach (var component in device.CpuDevices)
            {
                var affects = this.ComponentAffects.FirstOrDefault(_ => (_.ComponentTypes & ComponentType.Cpu) != 0);
                component.MetricData.RecordObservation(pollingInterval, workLevel * affects?.AffectWeight??0);
            }
            foreach(var component in device.VolumeDevices)
            {
                var affects = this.ComponentAffects.FirstOrDefault(_ => (_.ComponentTypes & ComponentType.Volume) != 0);
                component.VolumeUsage.MetricData.RecordObservation(pollingInterval, workLevel * affects?.AffectWeight??0);
            }
        }

        
    }
}
