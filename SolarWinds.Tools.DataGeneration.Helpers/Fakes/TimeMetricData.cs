namespace SolarWinds.Tools.DataGeneration.Helpers.Fakes
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
