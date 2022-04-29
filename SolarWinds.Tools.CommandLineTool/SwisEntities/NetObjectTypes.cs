using System.Collections.Generic;
using System.Linq;
using SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient;

namespace SolarWinds.Tools.CommandLineTool.SwisEntities
{
    public class NetObjectTypes : SwisEntity
    {
        private static char separator = ':';
        protected override string SwisEntityType => "Orion.NetObjectTypes";

        public string EntityType { get; set; }
        public string Name { get; set; }
        public string Prefix { get; set; }
        public string KeyProperty { get; set; }
        public string NameProperty { get; set; }
        public string KeyPropertyIndex { get; set; }

        public static string GetNetObjectId(SwisClient swisClient, string entityType, int entityId)
        {
            var netObjectType = SwisEntity.Get<NetObjectTypes>(swisClient).FirstOrDefault(_=>_.EntityType == entityType);
            return netObjectType.GetNetObjectId(entityId);
        }

        public string GetNetObjectId(int entityId) => $"{this?.Prefix ?? this.EntityType}{separator}{entityId}";

        public static NetObjectTypes Get(SwisClient swisClient, string entityType) => GetList(swisClient).FirstOrDefault(_ => _.EntityType == entityType);
        public static IList<NetObjectTypes> GetList(SwisClient swisClient) => SwisEntity.Get<NetObjectTypes>(swisClient).ToList();

    }
}
