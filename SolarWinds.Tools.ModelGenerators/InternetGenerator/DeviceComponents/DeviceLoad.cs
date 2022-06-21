
using SolarWinds.Tools.ModelGenerators.Metrics;

namespace SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceComponents
{
    /// <summary>
    /// Represents memory for a device
    /// </summary>
    public class DeviceLoad: DeviceComponent<UtilizationMetricData>
    {

        public DeviceLoad() : base(ComponentType.Device)
        {
            this.MetricData = new UtilizationMetricData();
        }
    }
}
