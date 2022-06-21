using System;
using System.Linq;
using SolarWinds.Tools.ModelGenerators.Metrics;

namespace SolarWinds.Tools.ModelGenerators.Extensions
{
    public static class MetricPrefixExtensions
    {
        public static string ToAbbreviation(this MetricPrefix metricPrefix) => metricPrefix == 0 ? String.Empty : metricPrefix.ToString().First().ToString().ToLower();
    }
}
