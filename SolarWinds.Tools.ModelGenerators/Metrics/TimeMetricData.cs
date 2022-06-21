

using SolarWinds.Tools.ModelGenerators.Fakes;

namespace SolarWinds.Tools.ModelGenerators.Metrics
{
    public class TimeMetricData : MetricData
    {
        public TimeMetricData()
        {
            this.Current = FakerHelper.Faker.Random.Double(this.Min, this.Max);
        }

        public override Units Units => new Units("ms", "ms", "ms");
    }
}
