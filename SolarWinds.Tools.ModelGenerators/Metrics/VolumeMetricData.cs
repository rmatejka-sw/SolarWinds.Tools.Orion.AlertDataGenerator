using System.Collections.Generic;
using SolarWinds.Tools.ModelGenerators.Extensions;
using SolarWinds.Tools.ModelGenerators.Fakes;


namespace SolarWinds.Tools.ModelGenerators.Metrics
{
    public class VolumeMetricData : CapacityMetricData {

        public VolumeMetricData()
        {
            this.Current = FakerHelper.Faker.Random.Double(this.Min, this.Max);
        }

        public override IList<double> PhysicalCapacities => new List<double>
        {
            500D.To( MetricPrefix.Giga),
            1D.To( MetricPrefix.Tera),
            2D.To( MetricPrefix.Tera),
            3D.To( MetricPrefix.Tera),
            4D.To( MetricPrefix.Tera),
            5D.To( MetricPrefix.Tera),
            5D.To( MetricPrefix.Tera),
        };

        public override Units Units => new ByteUnits();

    }
}
