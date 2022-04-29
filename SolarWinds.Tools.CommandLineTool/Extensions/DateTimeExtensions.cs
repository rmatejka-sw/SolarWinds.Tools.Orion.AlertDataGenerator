using System;

namespace SolarWinds.Tools.CommandLineTool.Extensions
{
    public static class DateTimeExtensions
    {
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
    }
}
