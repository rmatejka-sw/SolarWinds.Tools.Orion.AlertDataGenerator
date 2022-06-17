using SolarWinds.Tools.DataGeneration.Helpers.Fakes;

namespace SolarWinds.Tools.ModelGenerators.InternetGenerator
{
    /// <summary>
    /// Represents memory for a device
    /// </summary>
    public class DeviceMemory: IDeviceComponent<MemoryMetricData>
    {

        public DeviceMemory()
        {
            this.MetricData = new MemoryMetricData();
        }

        public double Capacity { get; }
        public MemoryMetricData MetricData { get; }
        public int DeviceIndex { get; set; }
        public ComponentType ComponentType { get; } = ComponentType.Memory;
    }
}
