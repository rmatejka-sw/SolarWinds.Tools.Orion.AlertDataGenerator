using System.Collections.Generic;
using SolarWinds.Tools.DataGeneration.Helpers.Extensions;

namespace SolarWinds.Tools.DataGeneration.Helpers.Fakes
{
    public class VolumeMetricData : CapacityMetricData {

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
