using System;
using System.Collections.Generic;

namespace SolarWinds.Tools.DataGeneration.Helpers.Fakes
{
    public interface IMetricData
    {
        Units Units { get; }
        double Current { get; set; }
        double Min { get; set; }
        double Max { get; set; }
        double Average { get; set; }
        void RecordObservation(DateTime pollingInterval, double current);

        IList<MetricDataObservation> Observations { get; }
    }
}