using System;
using System.Linq;
using NUnit.Framework;
using SolarWinds.Tools.DataGeneration.Helpers.Models;
using SolarWinds.Tools.ModelGenerators.InternetGenerator;
using SolarWinds.Tools.ModelGenerators.InternetGenerator.BusinessProcesses;
using SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceComponents;
using SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads;

namespace SolarWinds.Tools.DataGeneration.Tests
{
    public class BusinessProcessTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void BusinessProcess_Tests()
        {
            var bp = new BusinessProcess
            {
                Devices = 
                {
                    new Device
                    {
                        CpuDevices = {new DeviceCpu()},
                        MemoryDevices = {new DeviceMemory()},
                        VolumeDevices = { new DeviceVolume(0) }
                    }
                },
                DeviceWorkloads =
                {
                    new DeviceWorkload("WorkloadA", "1@1|5@0|1@-1")
                        .Affects(ComponentType.Cpu, AffectBehavior.Linear, 0.1f)
                        .Affects(ComponentType.Memory, AffectBehavior.Exponential, 0.1f),
                    new DeviceWorkload("WorkloadB", "5@5|1@-10|1@10|1@-10|5@30|1@-100")
                        .Affects(ComponentType.Cpu, AffectBehavior.Linear, 0.2f)
                        .Affects(ComponentType.Volume, AffectBehavior.Linear, 0.5f)
                        .Affects(ComponentType.Memory, AffectBehavior.Exponential, 0.2f),
                }
            };
            var observations = bp.WorkloadLevelObservations(new TimeRange(TimeSpan.FromDays(-1))).ToList();
            foreach (var observation in observations)
            {

            }
        }
    }
}