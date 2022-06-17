using SolarWinds.Tools.DataGeneration.Helpers.Fakes;

namespace SolarWinds.Tools.ModelGenerators.InternetGenerator
{
    public class DeviceVolume : IDeviceComponent<VolumeMetricData>
    {
        public VolumeMetricData MetricData { get; }
        public int DeviceIndex { get; set; }
        public ComponentType ComponentType { get; }
    }
}
