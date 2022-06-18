using System;
using SolarWinds.Tools.CommandLineTool.Models;
using SolarWinds.Tools.ModelGenerators.InternetGenerator;

namespace SolarWinds.Tools.ModelGenerators.Extensions
{
    public static class DateTimeExtensions
    {

        /// <summary>
        /// Takes a DateTime and rounds to the interval start time if the time
        /// is less than the normalized start time (e.g., 5, 10, 15 for 5 minute
        /// interval span)
        /// </summary>
        public static DateTime ToTimeInterval(this DateTime dateTime, TimeSpan intervalSpan)
        {
            long ticks = (dateTime.Ticks / intervalSpan.Ticks);
            return new DateTime(ticks * intervalSpan.Ticks);
        }

        /// <summary>
        /// Returns the zero-based interval index date dateTime falls into
        /// for the specified TimeRange. If TimeRange is null, uses a default TimeRange
        /// of 24 hours with the first interval starting at midnight.
        /// </summary>
        public static int ToTimeIntervalIndex(this DateTime dateTime, TimeRange timeRange=null, int minutesPerInterval = 10)
        {
            timeRange ??= new TimeRange(dateTime.Date, dateTime.Date.AddDays(1), TimeSpan.FromMinutes(minutesPerInterval));
            var normalized = dateTime.ToTimeInterval(timeRange.PollingInterval);
            var percentOfTotal = (normalized - timeRange.StartDate).Ticks / (double)timeRange.TimeSpan.Ticks;
            var totalIntervals = timeRange.TimeSpan.Ticks / timeRange.PollingInterval.Ticks;
            return (int) Math.Round(totalIntervals * percentOfTotal);
        }
    }
}
