using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolarWinds.Tools.DataGeneration.DAL.Tables.Orion
{
    public class NodesData : TableBase
    {

        public NodesData()
        {
            //networkGenerator.SqlProvider = sqlProvider;
            //var nodes = networkGenerator.Devices.Where(d => !d.IsShadowNode);
            //this.CurrentEntityId = networkGenerator.SqlProvider.ExecuteScalar<int>("SELECT ISNULL(MAX(NodeID),1) from NodesData");
            //this.RowCount = nodes.Count();
            //AddEnumeratedSource(nodes);
        }

        public int CurrentEntityId { get; set; }

        [Key]
        public int NodeID { get; set; }

        public string ObjectSubType { get; set; }

        public string IP_Address { get; set; }

        public string IP_Address_Type { get; set; }

        //Always a Null value.
        public bool? DynamicIP { get; set; }

        public bool? UnManaged { get; set; }

        //Always a Null value.
        public DateTime? UnManageFrom { get; set; }

        //Always a Null value.
        public DateTime? UnManageUntil { get; set; }

        public string Caption { get; set; }

        public string DNS { get; set; }

        public string Community { get; set; }

        public string RWCommunity { get; set; }

        public string SysName { get; set; }

        public string Vendor { get; set; }

        public string SysObjectID { get; set; }

        //[FormattedString("{0}-{1}", nameof(DeviceNodeName), nameof(DeviceNetworkId))]
        public string Description { get; set; }

        //[FakeAddressCityData]
        public string Location { get; set; }

        //[FakeEmailAddressData]
        public string Contact { get; set; }

        //Always a Null value.
        public int? RediscoveryInterval { get; set; }

        //[FakeIntegerData(Min = short.MaxValue, Max = short.MaxValue)]
        public short? PollInterval { get; set; }

        //[FormattedString("{0}.gif", nameof(VendorIconIdGen))]
        public string VendorIcon { get; set; }

        //[FakeStringData(Const = NetworkGenerator.FakeMarker)]
        public string IOSImage { get; set; }

        //[FakeStringData(Const = stringEmpty)]
        public string IOSVersion { get; set; }

        //[FormattedString("{0}.gif", nameof(StatusEnumValue))]
        public string GroupStatus { get; set; }

        //[FormattedString("Node is {0}", nameof(Status))]
        public string StatusDescription { get; set; }

        //[FakeNetworkStatus]
        public string Status { get; set; }

        //[CopiedFromProperty(PropertyName = nameof(GroupStatus), Order = 10)]
        public string StatusLED { get; set; }

        //[FakeIntegerData(Const = 1)]
        public int? PolledStatus { get; set; }

        // [FakeNetworkStatus]
        public int ChildStatus { get; set; }

        // [FakeIntegerData(Const = 1)]
        public int? EngineID { get; set; }

        // [FakeMachineTypeData]
        public string MachineType { get; set; }

        public bool? IsServer { get; set; }

        // [FakeIntegerData(Const = 0)]
        public int? Severity { get; set; }

        // [FakeIntegerData(Const = 10)]
        public short? StatCollection { get; set; }

        // [FakeBooleanData(Const = true)]
        public bool? Allow64BitCounters { get; set; }

        // [FakeBooleanData(Const = false)]
        public bool? SNMPV2Only { get; set; }

        // [FakeStringData(Const = stringEmpty)]
        public string AgentPort { get; set; }

        // [FakeIntegerData(Const = 2)]
        public byte? SNMPVersion { get; set; }

        // [FakeFloatingPointData(Min = 4e9f, Max = 64e9f)]
        public Single? TotalMemory { get; set; }

        // [FakeBooleanData(Const = false)]
        public bool? External { get; set; }

        // [FakeStringData(Const = "Orion.Nodes")]
        public string EntityType { get; set; }

        // [FakeStringData(Const = "N")]
        public string CMTS { get; set; }

        // [FakeDateTimeData(Const = nullDate)]
        public DateTime BlockUntil { get; set; }

        //Always a Null value.
        public Guid? IPAddressGUID { get; set; }

        // [FakeBooleanData(Const = false)]
        public bool CustomStatus { get; set; }

        public int? Category { get; set; }

        //Always a Null value.
        public int? CustomCategory { get; set; }

        //Always a Null value. Computer column - not needed
        // public int? EffectiveCategory { get; set; }

        //////////
        //Properties below this point, aren't stored into the database.
        //////////

        [NotMapped]
        // [FakeDomainNameData]
        public string DomainName { get; set; }

        [NotMapped]
        // [FakeIntegerData(Min = 1, Max = 800)]
        public int VendorIconIdGen { get; set; }

    }
}
