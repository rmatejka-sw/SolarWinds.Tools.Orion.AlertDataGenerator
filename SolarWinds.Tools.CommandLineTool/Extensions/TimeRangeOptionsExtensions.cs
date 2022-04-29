using System;
using System.Collections.Generic;
using SolarWinds.Tools.CommandLineTool.Options;

namespace SolarWinds.Tools.CommandLineTool.Extensions
{
    public static class TimeRangeOptionsExtensions
    {
        public static IEnumerable<DateTime> NextInterval(this ITimeRangeOptions timeRangeOptions, bool isLocal = false)
        {
            var nowTime = isLocal ? DateTime.Now : DateTime.UtcNow;
            var intervalSpan = TimeSpan.FromMinutes(timeRangeOptions.PollingInterval);
            var startTime = nowTime.Subtract(TimeSpan.FromDays(timeRangeOptions.PastDays));
            var endTime = nowTime.Add(TimeSpan.FromDays(timeRangeOptions.FutureDays));
            var currentTime = startTime;
            while (currentTime <= endTime)
            {
                yield return currentTime;
                currentTime = currentTime.Add(intervalSpan);
            }
        }
    }
}
