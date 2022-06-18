using SolarWinds.Tools.DataGeneration.Helpers.Fakes;

namespace SolarWinds.Tools.ModelGenerators.InternetGenerator
{
    public class DeviceVolume : DeviceComponent<VolumeMetricData>
    {
        public DeviceVolume() : base(ComponentType.Volume)
        {
            this.MetricData = new VolumeMetricData();

        }
    }
}
