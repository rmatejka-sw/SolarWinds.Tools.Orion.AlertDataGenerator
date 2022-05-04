using System;
using SolarWinds.Tools.DataGeneration.DAL.Extensions;
using SolarWinds.Tools.DataGeneration.Helpers;

namespace SolarWinds.Tools.DataGeneration.DAL.Tables.Orion
{
    public class NodesCustomProperties : TableBase
    {
        public NodesCustomProperties()
        {
            var f = FakerHelper.Faker;
            this.City = f.City();
            this.Department = f.Department();
            this.Comments = f.Sentence(250);
            this.PurchasePrice = f.Random.Float(0, 1000F);
            this.PONumber = f.Finance.Iban();
            this.AssetTag = f.System.AndroidId();
        }

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
