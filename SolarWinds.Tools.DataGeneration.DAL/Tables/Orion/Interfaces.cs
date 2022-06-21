
using System;
using System.ComponentModel.DataAnnotations;
using SolarWinds.Tools.DataGeneration.Helpers.Extensions;
using SolarWinds.Tools.ModelGenerators.Extensions;
using SolarWinds.Tools.ModelGenerators.Fakes;
using SolarWinds.Tools.ModelGenerators.Metrics;

namespace SolarWinds.Tools.DataGeneration.DAL.Tables.Orion
{
    public class Interfaces : TableBase<Interfaces>
    {
        public Interfaces()
        {
        }

        private static float StatusToInterfaceErrorsPerHour(OrionStatusInfo status)
        {
            if (status == OrionStatusInfo.Down) return 2600.0f;
            if (status == OrionStatusInfo.Up) return 0.0f;
            if (status == OrionStatusInfo.Warning) return 1002.0f;
            return 0.0f;
        }

        public long NodeID { get; set; }

        [Key]
        public long InterfaceID { get; set; }

        public string ObjectSubType { get; set; }

        public string InterfaceName { get; set; }

        public int? InterfaceIndex { get; set; }

        public int? InterfaceType { get; set; }

        public string InterfaceTypeName { get; set; }

        public string InterfaceTypeDescription { get; set; }

        public double? InterfaceSpeed { get; set; }

        public int? InterfaceMTU { get; set; }

        public DateTime? InterfaceLastChange { get; set; }

        public string PhysicalAddress { get; set; }

        public bool? UnManaged { get; set; }

        public DateTime? UnManageFrom { get; set; }

        public DateTime? UnManageUntil { get; set; }

        public short? AdminStatus { get; set; }

        public short? OperStatus { get; set; }

        public double? InBandwidth { get; set; }

        public double? OutBandwidth { get; set; }

        public string Caption { get; set; }

        public int? PollInterval { get; set; }

        public int? RediscoveryInterval { get; set; }

        public string FullName { get; set; }

        public string Status { get; set; }

        public string StatusLED { get; set; }

        public string AdminStatusLED { get; set; }

        public string OperStatusLED { get; set; }

        public string InterfaceIcon { get; set; }

        public Single? Outbps { get; set; }

        public Single? Inbps { get; set; }

        public Single? OutPercentUtil { get; set; }

        public Single? InPercentUtil { get; set; }

        public Single? OutPps { get; set; }

        public Single? InPps { get; set; }

        public short? InPktSize { get; set; }

        public short? OutPktSize { get; set; }

        public Single? OutUcastPps { get; set; }

        public Single? OutMcastPps { get; set; }

        public Single? InUcastPps { get; set; }

        public Single? InMcastPps { get; set; }

        public Single? InDiscardsThisHour { get; set; }

        public Single? InDiscardsToday { get; set; }

        public Single? InErrorsThisHour { get; set; }

        public Single? InErrorsToday { get; set; }

        public Single? OutDiscardsThisHour { get; set; }

        public Single? OutDiscardsToday { get; set; }

        public Single? OutErrorsThisHour { get; set; }

        public Single? OutErrorsToday { get; set; }

        public Single? MaxInBpsToday { get; set; }

        //Always a Null value.
        public DateTime? MaxInBpsTime { get; set; }

        public Single? MaxOutBpsToday { get; set; }

        //Always a Null value.
        public DateTime? MaxOutBpsTime { get; set; }

        public DateTime? NextRediscovery { get; set; }

        public DateTime? NextPoll { get; set; }

        public string Counter64 { get; set; }

        public short? StatCollection { get; set; }

        public DateTime? LastSync { get; set; }

        public string InterfaceAlias { get; set; }

        public string IfName { get; set; }

        public int? Severity { get; set; }

        public bool? CustomBandwidth { get; set; }

        public bool? UnPluggable { get; set; }

        public DateTime CustomPollerLastStatisticsPoll { get; set; }

        public int InterfaceSubType { get; set; }

        public bool? CollectAvailability { get; set; }

        public int DuplexMode { get; set; }

        public Single? LateCollisionsThisHour { get; set; }

        public Single? CRCAlignErrorsThisHour { get; set; }

        public Single? LateCollisionsToday { get; set; }

        public Single? CRCAlignErrorsToday { get; set; }

        //Always a Null value.
        public string CarrierName { get; set; }

        public string Comments { get; set; }


        public Interfaces Populate(long nodeId, string name, int interfaceIndex)
        {
            var f = FakerHelper.Faker;
            var status = f.Orion().Status();
            var inBandwidth = f.Random.Rate(MetricPrefix.Giga, 1, 10000);
            var inUsage = new BandwidthMetricRate();
            var outUsage = new BandwidthMetricRate();
            this.NodeID = nodeId;
            this.ObjectSubType = "SNMP";
            this.InterfaceName = name;
            this.InterfaceIndex = interfaceIndex;
            this.InterfaceType = 6;
            this.InterfaceTypeName = "ethernetCsmacd";
            this.InterfaceTypeDescription = "Ethernet";
            this.InterfaceSpeed = f.Random.Rate(MetricPrefix.Giga, 1, 1000);
            this.InterfaceMTU = 1500;
            this.InterfaceLastChange = f.Date.Past();
            this.PhysicalAddress = f.Random.Int(100000, 999999).ToString("X");
            this.UnManaged = false;
            this.UnManageFrom = null;
            this.UnManageUntil = null;
            this.AdminStatus = (short)status.StatusId;
            this.OperStatus = (short)status.StatusId;
            this.InBandwidth = inBandwidth;
            this.OutBandwidth = this.InBandwidth;
            this.Caption = this.InterfaceName;
            this.PollInterval = Int32.MaxValue;
            this.RediscoveryInterval = Int32.MaxValue;
            this.FullName = this.InterfaceName;
            this.Status = status.StatusText;
            this.StatusLED = status.StatusLED;
            this.AdminStatusLED = status.StatusLED;
            this.OperStatusLED = status.StatusLED;
            this.InterfaceIcon = "6.gif";
            //this.Outbps = (float)outUsage.;
            //this.Inbps = (float)inUsage.Used;
            this.OutPercentUtil = (float)outUsage.PercentUsed / 100.0f;
            this.InPercentUtil = (float)inUsage.PercentUsed / 100.0f;
            this.OutPps = this.Outbps / 148.0f;
            this.InPps = this.Inbps / 254.0f;
            this.InPktSize = (short)254;
            this.OutPktSize = (short)148;
            this.OutUcastPps = 1.0f;
            this.OutMcastPps = 1.0f;
            this.InUcastPps = 1.0f;
            this.InMcastPps = 1.0f;
            this.InDiscardsThisHour = StatusToInterfaceErrorsPerHour(status);
            this.InDiscardsToday = StatusToInterfaceErrorsPerHour(status);
            this.InErrorsThisHour = StatusToInterfaceErrorsPerHour(status);
            this.InErrorsToday = StatusToInterfaceErrorsPerHour(status);
            this.OutDiscardsThisHour = StatusToInterfaceErrorsPerHour(status);
            this.OutDiscardsToday = StatusToInterfaceErrorsPerHour(status);
            this.OutErrorsThisHour = StatusToInterfaceErrorsPerHour(status);
            this.OutErrorsToday = StatusToInterfaceErrorsPerHour(status);
            this.MaxInBpsToday = f.Random.Float(0, this.Inbps??0);
            this.MaxInBpsTime = null;
            this.MaxOutBpsToday = f.Random.Float(0, this.Inbps ?? 0);
            this.MaxOutBpsTime = null;
            this.NextRediscovery = f.Date.Future(1000);
            this.NextPoll = f.Date.Future(1000);
            this.Counter64 = "N";
            this.StatCollection = (short) 9;
            this.LastSync = f.Date.Past();
            this.InterfaceAlias = String.Empty;
            this.IfName = $"eth{this.InterfaceIndex}";
            this.Severity = 1;
            this.CustomBandwidth = false;
            this.UnPluggable = false;
            this.CustomPollerLastStatisticsPoll = f.Date.Past();
            this.InterfaceSubType = 0;
            this.CollectAvailability = true;
            this.DuplexMode = 0;
            this.LateCollisionsThisHour = 0;
            this.CRCAlignErrorsThisHour = 0;
            this.LateCollisionsToday = 0;
            this.CRCAlignErrorsToday = 0;
            this.CarrierName = null;
            this.Comments = FakerHelper.FakeMarker;       
            return this;
        }
    }
}
