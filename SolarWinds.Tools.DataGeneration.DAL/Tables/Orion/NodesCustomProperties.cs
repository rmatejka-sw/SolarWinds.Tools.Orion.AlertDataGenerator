using System;
using Dapper.Contrib.Extensions;
using SolarWinds.Tools.DataGeneration.DAL.Extensions;
using SolarWinds.Tools.DataGeneration.Helpers.Fakes;

namespace SolarWinds.Tools.DataGeneration.DAL.Tables.Orion
{
    [Table("NodesCustomProperties")]
    public class NodesCustomProperties : TableBase<NodesCustomProperties>
    {
        public NodesCustomProperties()
        {
        }

        public NodesCustomProperties Populate(NodesData node)
        {
            base.Populate();
            var f = FakerHelper.Faker;
            this.NodeID = (int)node.NodeID;
            this.City = f.City();
            this.Department = f.Department();
            this.Comments = f.Sentence(250);
            this.PurchasePrice = f.Random.Float(0, 1000F);
            this.PONumber = f.Finance.Iban();
            this.AssetTag = f.System.AndroidId();
            return this;
        }

        [ExplicitKey]
        public int NodeID { get; set; }

        public string City { get; set; }

        public string Department { get; set; }

        public string Comments { get; set; }

        public Single? PurchasePrice { get; set; }

        public DateTime? PurchaseDate { get; set; }

        public DateTime? InServiceDate { get; set; }

        public string PONumber { get; set; }

        public string AssetTag { get; set; }
    }
}
