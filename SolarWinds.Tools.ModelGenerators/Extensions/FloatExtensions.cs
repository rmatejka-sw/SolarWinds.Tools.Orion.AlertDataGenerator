using System;
using SolarWinds.Tools.ModelGenerators.Metrics;

namespace SolarWinds.Tools.ModelGenerators.Extensions
{
    public static class FloatExtensions
    {
        public static double To(this double value, MetricPrefix prefix) => value * Math.Pow(1024,(int) prefix);
    }
}
