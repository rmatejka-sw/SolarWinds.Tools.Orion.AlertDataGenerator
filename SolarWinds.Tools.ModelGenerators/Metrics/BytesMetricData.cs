

using SolarWinds.Tools.ModelGenerators.Fakes;

namespace SolarWinds.Tools.ModelGenerators.Metrics
{
    public class BytesMetricData : MetricData
    {

        public BytesMetricData()
        {
            this.Current = FakerHelper.Faker.Random.Double(this.Min, this.Max);
        }

        public override Units Units => new Units("byte", "bytes", "B");
    }
}
