using SolarWinds.Tools.DataGeneration.Helpers.Fakes;

namespace SolarWinds.Tools.ModelGenerators.InternetGenerator
{
    /// <summary>
    /// Represents Overall CPU for a device
    /// </summary>
    public class DeviceCpu : IDeviceComponent<UtilizationMetricData>
    {
        public DeviceCpu()
        {
            this.MetricData = new UtilizationMetricData();

        }
        public int DeviceIndex { get; set; }

        public ComponentType ComponentType { get; } = ComponentType.Cpu;
        public UtilizationMetricData MetricData { get;  }

    }
}
