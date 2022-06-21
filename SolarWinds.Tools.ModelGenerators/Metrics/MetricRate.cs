namespace SolarWinds.Tools.ModelGenerators.Metrics
{
    public abstract class MetricRate : MetricData, IRate {
 
        public abstract TimeUnit TimeUnits { get;  }

    }
}
