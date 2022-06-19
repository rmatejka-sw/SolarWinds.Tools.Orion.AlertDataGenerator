using System;
using System.Diagnostics;

namespace SolarWinds.Tools.DataGeneration.Helpers.Fakes
{
    [DebuggerDisplay("{Value} @ {DateTime}")]
    public class MetricDataObservation
    {
        public MetricDataObservation(DateTime when, double value)
        {
            this.DateTime = when;
            this.Value = value;
        }
        public DateTime DateTime { get;  }
        public double Value { get;  }
    }
}
