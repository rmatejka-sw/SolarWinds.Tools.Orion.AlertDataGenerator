using SolarWinds.Tools.DataGeneration.Helpers.Fakes;

namespace SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceComponents
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
