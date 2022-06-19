using System;
using System.Collections.Generic;
using SolarWinds.Tools.DataGeneration.Helpers.Models;
using SolarWinds.Tools.CommandLineTool.Options;

namespace SolarWinds.Tools.CommandLineTool.Extensions
{
    public static class TimeRangeOptionsExtensions
    {
        public static IEnumerable<DateTime> NextInterval(this ITimeRangeOptions timeRangeOptions, bool isLocal = false)
        {
            var timeRange = timeRangeOptions.TimeRange();
            var currentTime = timeRange.StartDate;
            while (currentTime <= timeRange.EndDate)
            {
                yield return currentTime;
                currentTime = currentTime.Add(timeRange.PollingInterval);
            }
        }

        public static TimeRange TimeRange(this ITimeRangeOptions timeRangeOptions, bool isLocal = false)
        {
            var nowTime = isLocal ? DateTime.Now : DateTime.UtcNow;
            var intervalSpan = TimeSpan.FromMinutes(timeRangeOptions.PollingInterval);
            var startTime = nowTime.Subtract(TimeSpan.FromDays(timeRangeOptions.PastDays));
            var endTime = nowTime.Add(TimeSpan.FromDays(timeRangeOptions.FutureDays));
            return new TimeRange(startTime, endTime, intervalSpan);
        }
    }
}
