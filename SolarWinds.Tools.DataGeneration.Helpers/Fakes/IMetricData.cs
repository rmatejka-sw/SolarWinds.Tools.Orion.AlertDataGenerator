using System;
using System.Collections.Generic;
using SolarWinds.Tools.DataGeneration.Helpers.Models;

namespace SolarWinds.Tools.DataGeneration.Helpers.Fakes
{
    public interface IMetricData
    {
        Units Units { get; }
        double Current { get; set; }
        double Min { get; set; }
        double Max { get; set; }
        double Average { get; set; }
        double Span { get; }
        void RecordObservation(DateTime pollingInterval, double current);
        
        /// <summary>
        /// Restores historic Metric date from the requested polling interval.
        /// NOTE: Current value is set to historic value. Call RestoreToLatest
        /// </summary>
        /// <returns></returns>
        double RestoreTo(DateTime pollingInterval, TimeRange timeRange);

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