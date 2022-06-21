using SolarWinds.Tools.ModelGenerators.Metrics;

namespace SolarWinds.Tools.ModelGenerators.InternetGenerator
{
    public class DeviceInterface : DeviceComponent<BandwidthMetricRate>
    {
        public DeviceInterface() : base(ComponentType.Interface)
        {
            MetricData = new BandwidthMetricRate();
        }
        public int InterfaceIndex { get; set; }
        public string Name { get; set; }
        public int OrionInterfaceID { get; set; }
        public string NetworkId { get; set; }
    }
}
