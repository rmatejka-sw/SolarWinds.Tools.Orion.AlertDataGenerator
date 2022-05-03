namespace SolarWinds.Tools.ModelGenerators.InternetGenerator
{
    public class DeviceConnection
    {
        public int SourceDeviceIndex { get; set; }
        public int SourceDeviceInterfaceIndex { get; set; }
        public int TargetDeviceIndex { get; set; }
        public int TargetDeviceInterfaceIndex { get; set; }
        public string NetworkId { get; set; }
    }
}
