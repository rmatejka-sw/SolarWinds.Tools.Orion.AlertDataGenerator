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
    }
}
