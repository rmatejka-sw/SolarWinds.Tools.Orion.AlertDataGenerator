

using SolarWinds.Tools.ModelGenerators.Fakes;

namespace SolarWinds.Tools.ModelGenerators.Metrics
{
    public class UtilizationMetricData : MetricData
    {
        public UtilizationMetricData()
        {
            this.Max = 100.0;
            this.Min = 0.0;
            this.Current = FakerHelper.Faker.Random.Double(this.Min, this.Max);
        }

        public override Units Units => new PercentUnits();

        public override double Current
        {
            get => base.Current;
            set => base.Current = Clamp(value, 0, 100.0);
        }
    }
}
