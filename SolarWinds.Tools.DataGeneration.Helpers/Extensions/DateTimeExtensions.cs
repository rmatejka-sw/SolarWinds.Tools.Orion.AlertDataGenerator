using System;

namespace SolarWinds.Tools.DataGeneration.Helpers.Extensions
{
    public static class DateTimeExtensions
    {
        public enum RoundDirection
        {
            Down = -1,
            Nearest = 0,
            Up = 1,
        }
        public static DateTime AsUtc(this DateTime dateTime)
        {
            return dateTime.Kind == DateTimeKind.Unspecified
                       ? DateTime.SpecifyKind(dateTime, DateTimeKind.Utc)
                       : dateTime.ToUniversalTime();
        }

        public static DateTime? AsUtc(this DateTime? dateTime)
        {
            return dateTime?.AsUtc();
        }

        public static DateTime TruncateToSeconds(this DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second).AsUtc();
        }

        public static DateTime TruncateToMinutes(this DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, 0).AsUtc();
        }

        public static bool IsInRange(this DateTime date, DateTime startDate, DateTime endDate)
        {
            return date >= startDate && date <= endDate;
        }

        /// <summary>
        /// Returns new DateTime that has been normalized to a time aligned with the start of the hour.
        /// For example, if passed 1/1/2020 1:15am, for a 10 minutes polling interval, returns 1/1/2020 1:20am.
        /// </summary>
        /// <param name="date">Date to be normalized</param>
        /// <param name="pollingInterval">Time between polls</param>
        /// <param name="roundDirection">Direction to round date.</param>
        /// <returns>DateTime rounded up to next polling interval</returns>
        public static DateTime ToPollingInterval(this DateTime date, TimeSpan pollingInterval, RoundDirection roundDirection)
        {
            try
            {
                switch (roundDirection)
                {
                    case RoundDirection.Down:
                        var downDelta = date.Ticks % pollingInterval.Ticks;
                        return new DateTime(date.Ticks - downDelta, date.Kind);
                    case RoundDirection.Up:
                        var modTicks = date.Ticks % pollingInterval.Ticks;
                        var upDelta = modTicks != 0 ? pollingInterval.Ticks - modTicks : 0;
                        return new DateTime(date.Ticks + upDelta, date.Kind);
                    case RoundDirection.Nearest:
                        var nearestDelta = date.Ticks % pollingInterval.Ticks;
                        bool roundUp = nearestDelta > pollingInterval.Ticks / 2;
                        var offset = roundUp ? pollingInterval.Ticks : 0;
                        return new DateTime(date.Ticks + offset - nearestDelta, date.Kind);
                }
            }
            catch (Exception e)
            {
                ConsoleLogger.Error(e);
            }

            return date;
        }
    }
}
