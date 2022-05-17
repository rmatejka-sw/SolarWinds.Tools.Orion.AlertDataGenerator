using System;
using SolarWinds.Tools.DataGeneration.Helpers.Fakes;

namespace SolarWinds.Tools.DataGeneration.Helpers.Extensions
{
    public static class FloatExtensions
    {
        public static double To(this double value, MetricPrefix prefix) => value * Math.Pow(1024,(int) prefix);
    }
}
