namespace SolarWinds.Tools.DataGeneration.Helpers.Fakes
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
