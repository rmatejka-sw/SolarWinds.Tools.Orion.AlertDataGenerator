using SolarWinds.Tools.DataGeneration.Helpers.Fakes;
using System;

namespace SolarWinds.Tools.ModelGenerators.InternetGenerator
{
    /// <summary>
    /// Represents Overall CPU for a device
    /// </summary>
    public class DeviceCpu : DeviceComponent<UtilizationMetricData>
    {
        public DeviceCpu() : base(ComponentType.Cpu)
        {
            this.MetricData = new UtilizationMetricData();
        }
    }
}
