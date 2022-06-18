
using System;
using System.Collections.Generic;

namespace SolarWinds.Tools.DataGeneration.Helpers.Fakes
{
    /// <summary>
    /// Used to represent faked metric data for a single point in time. All values will be consistent
    /// (Current and average will never be greater or less than max and min respectively).
    /// </summary>
    public abstract class MetricData : IMetricData
    {
        protected MetricData()
        {
            this.Observations = new List<MetricDataObservation>();
        }

        public abstract Units Units { get; }
        public virtual double Current { get; set; }
        // We need to set these via some scale (time, voltage, temp) or physical capacity
        public double Min { get; set; }
        public double Max { get; set; }
        public double Average { get; set; }
        public double Span => this.Max - this.Min;

        public void RecordObservation(DateTime pollingInterval, double current)
        {
            this.Current = Clamp(current, this.Min, this.Max);
            this.Observations.Add(new MetricDataObservation(pollingInterval, this.Current));
        }

        public IList<MetricDataObservation> Observations { get; }

        public static T Clamp<T>(T value, T min, T max) where T : notnull, IComparable<T>
        {
            if (value.CompareTo(min) < 0)
                return min;
            if (value.CompareTo(max) > 0)
                return max;

            return value;
        }
    }
}
