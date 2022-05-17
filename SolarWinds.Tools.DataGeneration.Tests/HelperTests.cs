using System;
using FluentAssertions;
using NUnit.Framework;
using SolarWinds.Tools.DataGeneration.Helpers;
using SolarWinds.Tools.DataGeneration.Helpers.Extensions;
using SolarWinds.Tools.DataGeneration.Helpers.Fakes;

namespace SolarWinds.Tools.DataGeneration.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void OrionStatusInfo_Test()
        {
            var infos = OrionStatusInfo.StatusInfos;
            infos.Count.Should().Be(40);
        }

        [TestCase(10, -1, "1/1/2020 1:03am", "1/1/2020 1:00am")]
        [TestCase(10, 0, "1/1/2020 1:03am", "1/1/2020 1:00am")]
        [TestCase(10, 1, "1/1/2020 1:03am", "1/1/2020 1:10am")]
        [TestCase(10, -1, "1/1/2020 1:10am", "1/1/2020 1:10am")]
        [TestCase(10, 0, "1/1/2020 1:10am", "1/1/2020 1:10am")]
        [TestCase(10, 1, "1/1/2020 1:10am", "1/1/2020 1:10am")]
        [TestCase(10, -1, "1/1/2020 1:09am", "1/1/2020 1:00am")]
        [TestCase(10, 0, "1/1/2020 1:09am", "1/1/2020 1:10am")]
        [TestCase(10, 1, "1/1/2020 1:09am", "1/1/2020 1:10am")]
        public void DateTime_ToPollingInterval_Test(int pollingIntervalMinutes, DateTimeExtensions.RoundDirection direction, string testCase,  string expectedString)
        {
            var date = DateTime.Parse(testCase);
            var expected = DateTime.Parse(expectedString);
            date.ToPollingInterval(TimeSpan.FromMinutes((double) pollingIntervalMinutes), direction)
                .Should().Be(expected);
        }

        [Test]
        public void MemoryMetricData_Test()
        {
            var test = new MemoryMetricData();
            test.PhysicalCapacities.Count.Should().Be(9);
        }
    }
}