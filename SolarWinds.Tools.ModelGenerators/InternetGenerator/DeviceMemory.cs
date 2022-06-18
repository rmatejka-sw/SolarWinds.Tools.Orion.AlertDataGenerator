using SolarWinds.Tools.DataGeneration.Helpers.Fakes;

namespace SolarWinds.Tools.ModelGenerators.InternetGenerator
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
