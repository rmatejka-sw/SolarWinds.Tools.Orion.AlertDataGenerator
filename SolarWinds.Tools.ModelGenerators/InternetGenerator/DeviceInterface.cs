using SolarWinds.Tools.DataGeneration.Helpers.Fakes;

namespace SolarWinds.Tools.ModelGenerators.InternetGenerator
{
    public class DeviceInterface : IDeviceComponent<BandwidthMetricRate>
    {
        public DeviceInterface()
        {
            this.MetricData = new BandwidthMetricRate();
        }
        public BandwidthMetricRate MetricData { get; }
        public int DeviceIndex { get; set; }
        public ComponentType ComponentType { get; } = ComponentType.Interface;
        public int InterfaceIndex { get; set; }
        public string Name { get; set; }
        public int OrionInterfaceID { get; set; }
        public string NetworkId { get; set; }
    }
}
