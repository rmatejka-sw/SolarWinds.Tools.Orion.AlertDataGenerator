using System.Collections.Generic;
using SolarWinds.Tools.DataGeneration.Helpers.Extensions;

namespace SolarWinds.Tools.DataGeneration.Helpers.Fakes
{
    public class MemoryMetricData : CapacityMetricData
    {
        public override IList<double> PhysicalCapacities => new List<double>
        {
            4D.To( MetricPrefix.Giga),
            16D.To( MetricPrefix.Giga),
            24D.To( MetricPrefix.Giga),
            128D.To( MetricPrefix.Giga),
            256D.To( MetricPrefix.Giga),
            (2*256D).To( MetricPrefix.Giga),
            (4*256D).To( MetricPrefix.Giga),
            (6*256D).To( MetricPrefix.Giga),
            (8*256D).To( MetricPrefix.Giga),
        };
    }
}
