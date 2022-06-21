using System.Collections.Generic;
using SolarWinds.Tools.ModelGenerators.Extensions;
using SolarWinds.Tools.ModelGenerators.Fakes;


namespace SolarWinds.Tools.ModelGenerators.Metrics
{
    public class MemoryMetricData : CapacityMetricData
    {
        public MemoryMetricData()
        {
            this.Current = FakerHelper.Faker.Random.Double(this.Min, this.Max);
        }

        public override IList<double> PhysicalCapacities => new List<double>
        {
            4D.To( MetricPrefix.Giga),
            16D.To( MetricPrefix.Giga),
            24D.To( MetricPrefix.Giga),
            128D.To( MetricPrefix.Giga),
            256D.To( MetricPrefix.Giga),
            (2*256D).To( MetricPrefix.Giga),
            (4*256D).To( MetricPrefix.Giga),
            (6*256D).To( MetricPrefix.Giga),
            (8*256D).To( MetricPrefix.Giga),
        };
        public override Units Units => new ByteUnits();
    }
}
