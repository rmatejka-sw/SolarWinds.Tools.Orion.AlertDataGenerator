namespace SolarWinds.Tools.DataGeneration.Helpers.Fakes
{
    public class MetricRate<TMetricData> where TMetricData : MetricData
    {
        public MetricRate(TMetricData metricData, float rate, TimeUnit timeUnits)
        {
            this.Rate = rate;
            this.TimeUnits = timeUnits; 
            this.MetricData = metricData;
        }

        public TMetricData MetricData { get; set; }
        public float Rate { get; set; }
        public TimeUnit TimeUnits { get; set; }

    }
}
