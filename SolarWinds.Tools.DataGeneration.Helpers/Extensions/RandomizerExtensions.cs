
using Bogus;
using SolarWinds.Tools.DataGeneration.Helpers.Fakes;

namespace SolarWinds.Tools.DataGeneration.Helpers.Extensions
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
