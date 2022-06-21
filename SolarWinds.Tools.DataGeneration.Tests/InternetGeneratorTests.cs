using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using SolarWinds.Tools.DataGeneration.Helpers.Extensions;
using SolarWinds.Tools.ModelGenerators.Extensions;
using SolarWinds.Tools.ModelGenerators.InternetGenerator;
using SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceComponents;
using SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads;
using SolarWinds.Tools.ModelGenerators.InternetGenerator.Options;
using SolarWinds.Tools.ModelGenerators.Metrics;

namespace SolarWinds.Tools.DataGeneration.Tests
{
    public class GeneratorOptions : IInternetGeneratorOptions
    {
        public int MaxHops { get; set; }
        public int MinNodes { get; set; }
        public int ShadowNodes { get; set; }
        public int MaxInternalNodes { get; set; }
        public int MaxConnectionsBetweenNodes { get; set; }
        public bool ExcludeIntranetDevices { get; set; }
    }
    public class InternetGeneratorTests
    {

        private InternetNetworkGenerator _networkGenerator;
        [SetUp]
        public void Setup()
        {
            this._networkGenerator = new InternetNetworkGenerator(new GeneratorOptions
            {
                MaxHops = 10,
                MinNodes = 10,
                ShadowNodes = 1,
                MaxInternalNodes = 10,
                ExcludeIntranetDevices = false,
                MaxConnectionsBetweenNodes = 10
            });
        }

        [Test]
        public void PopulateMetrics_Tests()
        {
            var timeRange = new TimeRange(TimeSpan.FromDays(7));
            _networkGenerator.CreateNetworks();
            _networkGenerator.PopulateMetrics(timeRange);
        }

        [Test]
        public void CreateNetworks_Test()
        {
            _networkGenerator.CreateNetworks();
            _networkGenerator.TotalNetworks.Should().BeGreaterThan(0);
            _networkGenerator.Devices.Count.Should().BeGreaterThan(0);
            _networkGenerator.DeviceInterfaces.Count.Should().BeGreaterThan(0);
            _networkGenerator.DeviceConnections.Count.Should().BeGreaterThan(0);
            foreach (var device in _networkGenerator.Devices)
            {
                device.MemoryDevices.Count.Should().BeGreaterThan(0);
                device.CpuDevices.Count.Should().BeGreaterThan(0);
                device.VolumeDevices.Count.Should().BeInRange(1,5);
            }
        }

        [TestCase(5, 10, false)]
        [TestCase(15, 30, false)]
        [TestCase(5, 10, true)]
        public void ToTimeIntervalIndex_Tests(int minutesPerInterval, int days, bool noTimeRange)
        {
            var pollingInterval = TimeSpan.FromMinutes(minutesPerInterval);
            var timeRangeSpan = TimeSpan.FromDays(days);
            var timeRange = new TimeRange(timeRangeSpan, pollingInterval);
            var index = 0;
            timeRange = new TimeRange(timeRange.StartDate.Date, timeRange.EndDate.Date,
                TimeSpan.FromMinutes(minutesPerInterval));
            var intervalsPerDay = TimeSpan.FromDays(1).TotalMinutes / minutesPerInterval;
            foreach (var interval in timeRange.PollingIntervals())
            {
                if (noTimeRange && index >= intervalsPerDay) index = 0;
                for (int i = 0; i < minutesPerInterval - 1; i++)
                {
                    var testTime = interval.AddMinutes(i);
                    var normalized = testTime.ToTimeInterval(pollingInterval);
                    normalized.Should().Be(interval);
                    var intervalIndex = noTimeRange
                        ? testTime.ToTimeIntervalIndex(minutesPerInterval)
                        : testTime.ToTimeIntervalIndex(timeRange);
                    intervalIndex.Should().Be(index);
                }
                index++;
            }

        }

        [TestCase(10, 1)]
        public void WorkDay_GetWorkLevelForInterval_Test(int minutesPerInterval, int days)
        {
            var pollingInterval = TimeSpan.FromMinutes(minutesPerInterval);
            var intervalsPerHour = TimeSpan.FromHours(1).TotalMinutes / minutesPerInterval;
            var workDay = new WorkDay(minutesPerInterval);
            var startDate = DateTime.Parse("1/1/2020");
            var timeRange = new TimeRange(startDate,TimeSpan.FromDays(1), pollingInterval);
            var totalIntervals = 0;
            foreach (var interval in timeRange.PollingIntervals())
            {
                var index = interval.ToTimeIntervalIndex(minutesPerInterval);
                index.Should().Be(totalIntervals);
                var workLevel = workDay.GetWorkLevelForInterval(interval, pollingInterval);
                workLevel.Should().Be(workDay.WorkLevels[index]);
                totalIntervals++;
            }
        }


        [TestCase(0)]
        [TestCase(1000000f)]
        public void AnomalyGenerator_Test(double startValue)
        {
            var metricData = new MemoryMetricData();
            var anomalyGenerator = new AnomalyGenerator(metricData);
            double? anomalyValue = 0;
            var maxIterations = 100;
            metricData.Current = startValue;
            metricData.RecordObservation(DateTime.UtcNow, metricData.Current);
            do
            {
                anomalyValue = anomalyGenerator.NextValue();

            } while (!anomalyValue.HasValue && maxIterations-- > 0);
            if (anomalyValue.HasValue) metricData.RecordObservation(DateTime.UtcNow, anomalyValue.Value);
            while ((anomalyValue = anomalyGenerator.NextValue()).HasValue)
            {
                metricData.RecordObservation(DateTime.UtcNow, anomalyValue.Value);
            }
            metricData.Observations.Count.Should().Be(5);
            metricData.Observations.First().Value.Should().BeApproximately(metricData.Observations.Last().Value, 0.01);
            metricData.Observations.Count(_=>_.Value != metricData.Observations.First().Value).Should().Be(3);
            ((metricData.Observations[2].Value - metricData.Observations[0].Value) / metricData.Span)
                .Should().BeApproximately(0.5f, 0.01f);
            ((metricData.Observations[2].Value - metricData.Observations[4].Value) / metricData.Span)
                .Should().BeApproximately(0.50f, 0.01f);
        }

        [Test]
        public void AnomalyGenerator_Reset_Test()
        {
            var metricData = new MemoryMetricData();
            var anomalyGenerator = new AnomalyGenerator(metricData);
            var count = 0;
            while (anomalyGenerator.NextValue().HasValue) count++;
            count.Should().Be(4);
            while (anomalyGenerator.NextValue().HasValue) count++;
            anomalyGenerator.Reset();
            while (anomalyGenerator.NextValue().HasValue) count++;
            count.Should().Be(8);
        }
    }
}