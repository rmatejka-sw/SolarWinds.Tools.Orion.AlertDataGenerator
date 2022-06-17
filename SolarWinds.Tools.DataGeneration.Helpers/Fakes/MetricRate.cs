using SolarWinds.Tools.DataGeneration.Helpers.Extensions;

namespace SolarWinds.Tools.DataGeneration.Helpers.Fakes
{
    public abstract class MetricRate : MetricData, IRate {
 
        public abstract TimeUnit TimeUnits { get;  }

    }
}
