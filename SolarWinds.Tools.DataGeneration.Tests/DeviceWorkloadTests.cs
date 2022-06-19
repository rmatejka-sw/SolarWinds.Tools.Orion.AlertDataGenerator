using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using SolarWinds.Tools.DataGeneration.Helpers.Models;
using SolarWinds.Tools.ModelGenerators.InternetGenerator;
using SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceComponents;
using SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads;

namespace SolarWinds.Tools.DataGeneration.Tests
{
    public class DeviceWorkloadTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CreateDeviceWorkload_Creation_Test()
        {
            var deviceWorkload = new DeviceWorkload("Backups", "1@0")
                .Affects(ComponentType.Cpu, AffectBehavior.Linear, 0.5f)
                .Affects(ComponentType.Interface, AffectBehavior.Exponential, -1.0f)
                ;
            deviceWorkload.ComponentAffects.Count.Should().Be(2);
        }


        [TestCase("5@0", 5, 0)]
        [TestCase("2@-3.0", 2, -3.0)]
        [TestCase("xxxx", 1, 0)]
        public void WorkloadSegment_Test(string segmentDefinition, int intervals, double rate)
        {
            var segment = new WorkloadSegment(segmentDefinition);
            segment.TotalIntervals.Should().Be(intervals);
            segment.PercentChangePerInterval.Should().Be(rate);
        }

        [TestCase("5>0", 5, 0)]
        [TestCase("2>3.0", 2, 3.0)]
        [TestCase("xxxx", 1, 0)]
        public void WorkloadSegmentEndValue_Test(string segmentDefinition, int intervals, double endPercent)
        {
            var segment = new WorkloadSegment(segmentDefinition);
            segment.TotalIntervals.Should().Be(intervals);
            segment.EndPercent.Should().Be(null);
        }


        [TestCase("1@1|5@0|1@-1", "1,1,1,1,1,1,0")]
        [TestCase("5@5|1@-10|1@10|1@-10|5@30|1@-100", "5,10,15,20,25,15,25,15,45,75,100,100,100,0")]
        [TestCase("1>1|5>6|1>0", "1,2,3,4,5,6,0")]
        public void WorkloadDefinition_Test(string segmentDefinitionList, string workLevelList)
        {
            var segmentDefinitions = segmentDefinitionList.Split('|');
            var workLevels = workLevelList.Split(',').Select(_ => double.Parse(_)).ToList();
            var workLoad = new WorkloadDefinition(segmentDefinitions);
            workLoad.WorkloadLevels().Count().Should().Be(workLevels.Count);
            var interval = 0;
            foreach (var workLevel in workLoad.WorkloadLevels())
            {
                workLevel.Should().Be(workLevels[interval]);
                interval++;
            }
        }

        [TestCase("1@1|5@0|1@-1")]
        [TestCase("5@5|1@-10|1@10|1@-10|5@30|1@-100")]
        public void CreateDeviceWorkload_Generation_Test(string segmentDefinitionList)
        {
            var deviceWorkload = new DeviceWorkload("Backups", segmentDefinitionList)
                    .Affects(ComponentType.Cpu, AffectBehavior.Linear, 0.5f)
                    .Affects(ComponentType.Memory, AffectBehavior.Exponential, 0.1f)
                ;
            var device = new Device();
            device.CpuDevices.Add(new DeviceCpu());
            device.MemoryDevices.Add(new DeviceMemory());
            deviceWorkload.GenerateDeviceMetricData(new TimeRange(TimeSpan.FromHours(-2)), new List<Device> { device });
            var intervalIndex = 0;
            foreach (var observation in device.MemoryDevices.First().MetricData.Observations)
            {
                observation.Value.Should().Be(deviceWorkload.WorkLevel.Observations[intervalIndex].Value * 0.1f);
                intervalIndex++;
            }
            intervalIndex = 0;
            foreach (var observation in device.CpuDevices.First().MetricData.Observations)
            {
                observation.Value.Should().Be(deviceWorkload.WorkLevel.Observations[intervalIndex].Value * 0.5f);
                intervalIndex++;
            }
        }

        
    }
}