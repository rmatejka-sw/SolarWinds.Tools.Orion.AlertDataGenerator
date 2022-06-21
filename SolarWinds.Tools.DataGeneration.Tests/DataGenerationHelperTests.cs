using System;
using FluentAssertions;
using NUnit.Framework;
using SolarWinds.Tools.ModelGenerators.Metrics;

namespace SolarWinds.Tools.DataGeneration.Tests
{
    public class DataGenerationHelperTests
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void TimeRange_Test()
        {
            var timeRange = new TimeRange(TimeSpan.FromHours(-1));
            timeRange.StartDate.Should().BeBefore(timeRange.EndDate);
            timeRange.EndDate.Subtract(timeRange.StartDate).TotalHours.Should().Be(1);
        }

        [Test]
        public void MetricData_RecordObservation_Test()
        {
            var data = new BandwidthMetricRate();
            var now = DateTime.Now;
            var timeRange = new TimeRange(TimeSpan.FromHours(-1));
            var totalIntervals = 0;
            foreach (var interval in timeRange.PollingIntervals())
            {
                data.RecordObservation(interval, interval.Ticks);
                totalIntervals++;
            }
            data.Observations.Count.Should().Be(totalIntervals);
            foreach (var metricDataObservation in data.Observations)
            {
                metricDataObservation.Value.Should().Be(metricDataObservation.DateTime.Ticks);
            }
        }

        [Test]
        public void BandwidthMetricRate_Test()
        {
            var data = new BandwidthMetricRate();
            data.PhysicalCapacities.Should().Contain(data.Capacity);
            data.TimeUnits.Should().Be(TimeUnit.Seconds);
            data.Current = data.Capacity / 2.0;
            data.PercentUsed.Should().Be(50D);
            data.Available.Should().Be(data.Current);
            data.Used.Should().Be(data.Current);
            data.Units.Singular.Should().Be("Bps");
        }


        [Test]
        public void VolumeMetricData_Test()
        {
            var data = new VolumeMetricData();
            data.PhysicalCapacities.Should().Contain(data.Capacity);
            data.Current = data.Capacity / 2.0;
            data.PercentUsed.Should().Be(50D);
            data.Available.Should().Be(data.Current);
            data.Used.Should().Be(data.Current);
            data.Units.Abbreviation.Should().Be("B");
        }

        [Test]
        public void UtilizationMetricData_Test()
        {
            var data = new UtilizationMetricData();
            data.Units.Abbreviation.Should().Be("%");
            data.Current = 50;
            data.Current.Should().Be(50);
            data.Current = 500;
            data.Current.Should().Be(100);
            data.Current = -500;
            data.Current.Should().Be(0);
        }

       
    }
}