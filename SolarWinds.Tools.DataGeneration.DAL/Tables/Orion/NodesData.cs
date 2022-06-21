using System;
using Dapper.Contrib.Extensions;
using SolarWinds.Tools.DataGeneration.Helpers.Extensions;
using SolarWinds.Tools.ModelGenerators.Extensions;
using SolarWinds.Tools.ModelGenerators.Fakes;
using SolarWinds.Tools.ModelGenerators.Metrics;

namespace SolarWinds.Tools.DataGeneration.DAL.Tables.Orion
{
    [Table("NodesData")]
    public class NodesData : TableBase<NodesData>
    {

        public NodesData()
        {
        }

        public override NodesData Populate()
        {
            var f = FakerHelper.Faker;
            var domainName = f.Internet.DomainName();
            var status = f.Orion().Status();
            var memory = f.Orion().Memory();
            base.Populate();
            this.ObjectSubType = "ICMP";
            this.IPAddress = f.Internet.Ip();
            this.IPAddressType = "IPV4";
            this.UnManaged = false;
            this.UnManageFrom = null;
            this.UnManageUntil = null;
            this.Caption = $"{domainName}-{FakerHelper.FakeMarker}";
            this.SysName = $"{domainName}";
            this.Community = "public";
            this.RWCommunity = String.Empty;
            this.Vendor = f.Orion().Vendor;
            this.Description = this.Caption;
            this.Location = f.Address.City();
            this.Contact = f.Internet.Email(provider: domainName);
            this.RediscoveryInterval = null;
            this.PollInterval = short.MaxValue;
            this.VendorIcon = f.Orion().VendorIcon;
            this.IOSImage = FakerHelper.FakeMarker;
            this.IOSVersion = String.Empty;
            this.Status = $"{status.StatusId}";
            this.GroupStatus = f.Orion().StatusImage(status.StatusId);
            this.StatusDescription = $"Node is {status.StatusName}";
            this.StatusLED = this.GroupStatus;
            this.PolledStatus = 1;
            this.ChildStatus = f.Orion().Status().StatusId;
            this.EngineID = 1;
            this.MachineType = f.Orion().MachineType;
            this.IsServer = f.Random.Bool();
            this.Severity = 0;
            this.StatCollection = 10;
            this.Allow64BitCounters = true;
            this.SNMPV2Only = false;
            this.SNMPVersion = 2;
            this.AgentPort = String.Empty;
            this.TotalMemory = (float?) memory.Capacity;
            this.External = false;
            this.EntityType = "Orion.Nodes";
            this.CMTS = "N";
            this.BlockUntil = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
            this.IPAddressGUID = null;
            this.CustomStatus = false;
            this.Category = f.Random.Int(1, 2);
            return this as NodesData;
        }

        [Key]
        public long NodeID { get; set; }

        public string ObjectSubType { get; set; }

        public string IPAddress { get; set; }

        public string IPAddressType { get; set; }

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

        public string Description { get; set; }

        public string Location { get; set; }

        public string Contact { get; set; }

        public int? RediscoveryInterval { get; set; }

        public short? PollInterval { get; set; }

        public string VendorIcon { get; set; }

        public string IOSImage { get; set; }

        public string IOSVersion { get; set; }

        public string GroupStatus { get; set; }

        public string StatusDescription { get; set; }

        public string Status { get; set; }

        public string StatusLED { get; set; }

        public int? PolledStatus { get; set; }

        public int ChildStatus { get; set; }

        public int? EngineID { get; set; }

        public string MachineType { get; set; }

        public bool? IsServer { get; set; }

        public int? Severity { get; set; }

        public short? StatCollection { get; set; }

        public bool? Allow64BitCounters { get; set; }

        public bool? SNMPV2Only { get; set; }

        public string AgentPort { get; set; }

        public byte? SNMPVersion { get; set; }

        public Single? TotalMemory { get; set; }

        public bool? External { get; set; }

        public string EntityType { get; set; }

        public string CMTS { get; set; }

        public DateTime BlockUntil { get; set; }

        public Guid? IPAddressGUID { get; set; }

        public bool CustomStatus { get; set; }

        public int? Category { get; set; }

        public int? CustomCategory { get; set; }

    }
}
