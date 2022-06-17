using System;
using System.Linq;
using SolarWinds.Tools.DataGeneration.Helpers.Fakes;

namespace SolarWinds.Tools.DataGeneration.Helpers.Extensions
{
    public static class MetricPrefixExtensions
    {
        public static string ToAbbreviation(this MetricPrefix metricPrefix) => metricPrefix == 0 ? String.Empty : metricPrefix.ToString().First().ToString().ToLower();
    }
}
