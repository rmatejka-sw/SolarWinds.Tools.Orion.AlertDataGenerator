using System.Linq;
using SolarWinds.Tools.DataGeneration.Helpers.Fakes;

namespace SolarWinds.Tools.DataGeneration.Helpers.Extensions
{
    public static class TimeUnitsExtensions
    {
        public static string ToAbbreviation(this TimeUnit timeUnit) => timeUnit.ToString().First().ToString().ToLower();
    }
}
