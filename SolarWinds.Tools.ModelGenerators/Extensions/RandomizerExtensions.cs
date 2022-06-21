using Bogus;
using SolarWinds.Tools.ModelGenerators.Metrics;

namespace SolarWinds.Tools.ModelGenerators.Extensions
{

    public static class RandomizerExtensions
    {
        public static long Capacity(this Randomizer randomizer, MetricPrefix units, int min = 1, int max = 999)
        {
            var multiplier = 1024 ^ (int)units;
            return randomizer.Long((long)min * multiplier, (long)max * multiplier);
        }

        public static double Rate(this Randomizer randomizer, MetricPrefix units, int min = 1, int max = 999)
        {
            var multiplier = 1024 ^ (int)units;
            return randomizer.Double(min * multiplier, max * multiplier);
        }

    }
}
