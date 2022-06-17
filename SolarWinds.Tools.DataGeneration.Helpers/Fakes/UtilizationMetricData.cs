using System;

namespace SolarWinds.Tools.DataGeneration.Helpers.Fakes
{
    public class UtilizationMetricData : MetricData
    {
        public override Units Units => new PercentUnits();

        public override double Current
        {
            get => base.Current;
            set => base.Current = Clamp(value, 0, 100.0);
        }
    }
}
