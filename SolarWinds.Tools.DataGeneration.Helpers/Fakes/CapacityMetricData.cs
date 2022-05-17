using System.Collections.Generic;

namespace SolarWinds.Tools.DataGeneration.Helpers.Fakes
{
    /// <summary>
    /// Represents Metric Data that has a physical capacity like memory, disk space,
    /// and bandwidth. Base MetricData will be bounded by the Capacity.
    /// </summary>
    public abstract class CapacityMetricData : MetricData
    {
        private double? capacity;

        protected CapacityMetricData()
        {
            this.Max = this.Capacity;
            this.Min = 0d;
        }

        /// <summary>
        /// List of typical capacities for the associated physical device. For example,
        /// disk drives could be 500MB, 1TB, 2TB, etc.
        /// </summary>
        public abstract IList<double> PhysicalCapacities { get; }

        public double Capacity => capacity ??= FakerHelper.Faker.PickRandom(PhysicalCapacities);
        public double CapacityPercentage => Current / Capacity * 100.0;
    }
}
