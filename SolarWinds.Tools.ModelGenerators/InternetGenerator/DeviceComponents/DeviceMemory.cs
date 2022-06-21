
using SolarWinds.Tools.ModelGenerators.Metrics;

namespace SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceComponents
{
    /// <summary>
    /// Represents memory for a device
    /// </summary>
    public class DeviceMemory: DeviceComponent<MemoryMetricData>
    {

        public DeviceMemory() : base(ComponentType.Memory)
        {
            this.MetricData = new MemoryMetricData();
        }
    }
}
