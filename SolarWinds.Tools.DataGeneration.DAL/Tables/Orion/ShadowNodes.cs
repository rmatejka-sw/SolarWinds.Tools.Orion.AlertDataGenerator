using System;
using Dapper.Contrib.Extensions;
using SolarWinds.Tools.ModelGenerators.Fakes;
using SolarWinds.Tools.ModelGenerators.Metrics;

namespace SolarWinds.Tools.DataGeneration.DAL.Tables.Orion
{
    [Table("ShadowNodes")]
    public class ShadowNodes : TableBase<ShadowNodes>
    {
        public ShadowNodes()
        {
        }

        public int NodeId { get; set; }

        public string IPAddress { get; set; }

        public string NodeName { get; set; }

        public string MACAddress { get; set; }

        public Guid? IPAddressGUID { get; set; }

        public override ShadowNodes Populate()
        {
            var f = FakerHelper.Faker;
            var domainName = f.Internet.DomainName();
            base.Populate();
            this.MACAddress = f.Internet.Mac();
            this.NodeName = $"{domainName}-{FakerHelper.FakeMarker}";
            this.IPAddress = f.Internet.Ip();
            return this;
        }
    }
}
