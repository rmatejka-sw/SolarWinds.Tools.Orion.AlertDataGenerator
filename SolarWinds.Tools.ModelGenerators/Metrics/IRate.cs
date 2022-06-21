namespace SolarWinds.Tools.ModelGenerators.Metrics
{
    public interface IRate : IMetricData
    {
        public TimeUnit TimeUnits { get;  }

    }
}
