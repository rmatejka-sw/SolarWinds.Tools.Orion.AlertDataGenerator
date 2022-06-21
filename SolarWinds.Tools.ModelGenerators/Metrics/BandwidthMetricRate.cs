using System.Collections.Generic;
using SolarWinds.Tools.ModelGenerators.Extensions;
using SolarWinds.Tools.ModelGenerators.Fakes;


namespace SolarWinds.Tools.ModelGenerators.Metrics
{
    public class BandwidthMetricRate : CapacityMetricData, IRate
    {
        public BandwidthMetricRate()
        {
            this.Current = FakerHelper.Faker.Random.Double(this.Min, this.Max);
        }

        public override Units Units => new Units($"Bps");
        public TimeUnit TimeUnits => TimeUnit.Seconds;
        public override IList<double> PhysicalCapacities => new List<double>
        {
            10D.To( MetricPrefix.Mega),
            100D.To( MetricPrefix.Mega),
            1D.To( MetricPrefix.Giga),
        };

    }
}
