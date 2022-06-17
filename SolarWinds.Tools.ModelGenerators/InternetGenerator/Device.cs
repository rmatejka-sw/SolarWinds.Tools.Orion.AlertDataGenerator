using System.Collections.Generic;
using SolarWinds.Tools.DataGeneration.Helpers.Fakes;

namespace SolarWinds.Tools.ModelGenerators.InternetGenerator
{
    public class Device
    {
        public int DeviceIndex { get; set; }
        public string IpAddress { get; set; }
        public string NodeName { get; set; }
        public int OrionNodeID { get; set; }
        public int AsNumber { get; set; }
        public string CidrPrefix { get; set; }
        public string DomainName { get; set; }
        public string NetworkId { get; set; }
        public int TotalInterfaces { get; set; }
        public bool IsLocalDevice { get; set; }
        public bool IsServer { get; set; }
        public bool IsShadowNode { get; set; }
        public IList<DeviceCpu> CpuDevices { get; set; } = new List<DeviceCpu>();
        public IList<DeviceMemory> MemoryDevices { get; set; } = new List<DeviceMemory>();
        public IList<DeviceInterface> InterfaceDevices { get; set; } = new List<DeviceInterface>();
        public IList<DeviceVolume> VolumeDevices { get; set; } = new List<DeviceVolume>();
    }
}
