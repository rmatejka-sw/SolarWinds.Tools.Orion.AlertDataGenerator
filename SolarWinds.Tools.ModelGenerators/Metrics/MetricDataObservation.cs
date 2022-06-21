using System;
using System.Diagnostics;

namespace SolarWinds.Tools.ModelGenerators.Metrics
{
    [DebuggerDisplay("{Value} @ {DateTime}")]
    public class MetricDataObservation
    {
        public MetricDataObservation(DateTime when, double value, bool isAnomalous=false)
        {
            this.DateTime = when;
            this.Value = value;
            IsAnomalous = isAnomalous;  
        }
        public DateTime DateTime { get;  }
        public double Value { get;  }

        public bool IsAnomalous { get; set; }
    }
}
