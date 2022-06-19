using SolarWinds.Tools.DataGeneration.Helpers.Fakes;
using SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceComponents;

namespace SolarWinds.Tools.ModelGenerators.InternetGenerator
{
    public class DeviceVolume 
    {
        public int OrionNodeId { get; set; }
        public int OrionVolumeId { get; set; }
        public int VolumeIndex  { get;  }
        public VolumeTypeInfo VolumeType { get; }

        public DeviceVolumeUsage VolumeUsage { get; set; }
        
        public DeviceVolume(int volumeIndex) 
        {
            this.VolumeIndex = volumeIndex;
            this.VolumeType = new VolumeTypeInfo(this.VolumeIndex);
            this.VolumeUsage = new DeviceVolumeUsage();

        }

    }
}
