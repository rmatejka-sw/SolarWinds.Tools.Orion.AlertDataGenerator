using System;
using System.Linq;
using SolarWinds.Tools.DataGeneration.DAL.Models;
using SolarWinds.Tools.DataGeneration.Helpers;

namespace SolarWinds.Tools.DataGeneration.DAL.SwisEntities
{
    public class System_ManagedEntity : SwisEntity
    {
        protected override string SwisEntityType => "System.ManagedEntity";
        public string[] AncestorDetailsUrls { get; set; }
        public string[] AncestorDisplayNames { get; set; }
        public string Description { get; set; }
        public string DetailsUrl { get; set; }
        public string DisplayName { get; set; }
        public string Image { get; set; }
        public int InstanceSiteId { get; set; }
        public string InstanceType { get; set; }
        public int Status { get; set; }
        public string StatusDescription { get; set; }
        public string StatusIconHint { get; set; }
        public string StatusLED { get; set; }
        public bool? UnManaged { get; set; }
        public DateTime? UnManageFrom { get; set; }
        public DateTime? UnManageUntil { get; set; }
        public string Uri { get; set; }
        public int GetEntityId()
        {

            try
            {
                if (Int32.TryParse(this.Uri.Substring(this.Uri.LastIndexOf('=') + 1), out int result))
                {
                    return result;
                }
            }
            catch (Exception e)
            {
               ConsoleLogger.Error(e);
            }

            return 0;
        }

        public static System_ManagedEntity GetByOpid(string entityOpid)
        {
            var opid = new Opid(entityOpid);
            return System_ManagedEntity.GetManagedEntity(
                $"SELECT * FROM System.ManagedEntity where InstanceType='{opid.EntityType}' AND Uri like '%={opid.EntityId}'").FirstOrDefault();
        }
        public string GetOpid() => $"{InstanceSiteId}_{InstanceType}_{GetEntityId()}";
    }


}
