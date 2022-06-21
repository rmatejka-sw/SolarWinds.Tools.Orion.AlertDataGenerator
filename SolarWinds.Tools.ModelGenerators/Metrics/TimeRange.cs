using System;
using System.Collections.Generic;

namespace SolarWinds.Tools.ModelGenerators.Metrics
{
    public class TimeRange
    {
        private TimeSpan _defaulPollingInterval = TimeSpan.FromMinutes(10);

        public TimeRange(DateTime startDate, DateTime endDate, TimeSpan? pollingInterval = null)
        {
            this.StartDate = startDate;
            this.EndDate = endDate;
            TimeSpan = endDate.Subtract(startDate);
            if (StartDate > EndDate) (StartDate, EndDate) = (EndDate, StartDate);
            this.PollingInterval = pollingInterval ?? _defaulPollingInterval;
        }


        public TimeRange(DateTime startDate, TimeSpan timeSpan, TimeSpan? pollingInterval = null)
        {
            StartDate = startDate;
            TimeSpan = timeSpan;
            EndDate = startDate.Add(TimeSpan);
            if (StartDate > EndDate) (StartDate, EndDate) = (EndDate, StartDate);
            this.PollingInterval = pollingInterval ?? _defaulPollingInterval;
        }

        public TimeRange(TimeSpan timeSpan, TimeSpan? pollingInterval = null)
        {
            StartDate = DateTime.UtcNow;
            TimeSpan = timeSpan;
            EndDate = StartDate.Add(TimeSpan);
            if (StartDate > EndDate) (StartDate, EndDate) = (EndDate, StartDate);
            this.PollingInterval = pollingInterval ?? _defaulPollingInterval;
        }

        public TimeSpan PollingInterval { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
        public TimeSpan TimeSpan { get; }

        /// <summary>
        /// Iterates over TimeRange from StartDate to EndDate every PollingInterval
        /// </summary>
        /// <returns>DateTime for current interval.</returns>
        public IEnumerable<DateTime> PollingIntervals()
        {
            var currentInterval = StartDate;
            while (currentInterval < EndDate)
            {
                yield return currentInterval;
                currentInterval = currentInterval.Add(PollingInterval);
            }
        }
    }
}
