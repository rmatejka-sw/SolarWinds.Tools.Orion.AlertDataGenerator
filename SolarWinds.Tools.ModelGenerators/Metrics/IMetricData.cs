using System;
using System.Collections.Generic;


namespace SolarWinds.Tools.ModelGenerators.Metrics
{
    public interface IMetricData
    {
        Units Units { get; }
        double Current { get; set; }
        double Min { get; set; }
        double Max { get; set; }
        double Average { get; set; }
        double Span { get; }
        bool IsAnomalous { get; }
        void RecordObservation(DateTime pollingInterval, double current, bool isAnomalous=false);

        /// <summary>
        /// Restores historic Metric date from the requested polling interval.
        /// NOTE: Current value is set to historic value. Call RestoreToLatest
        /// </summary>
        /// <returns></returns>
        MetricDataObservation RestoreTo(DateTime pollingInterval, TimeRange timeRange);

        /// <summary>
        /// Restores current value to the value prior to calling
        /// RestoreTo and returns the current value. If Restore was not called,
        /// returns the current value.
        /// </summary>
        /// <returns></returns>
        double RestoreToLatest();

        IList<MetricDataObservation> Observations { get; }
    }
}