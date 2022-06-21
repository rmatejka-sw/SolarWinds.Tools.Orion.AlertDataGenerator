using System.Linq;
using SolarWinds.Tools.ModelGenerators.Metrics;

namespace SolarWinds.Tools.ModelGenerators.Extensions
{
    public static class TimeUnitsExtensions
    {
        public static string ToAbbreviation(this TimeUnit timeUnit) => timeUnit.ToString().First().ToString().ToLower();
    }
}
