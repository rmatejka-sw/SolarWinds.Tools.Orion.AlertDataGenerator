using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using SolarWinds.Tools.DataGeneration.DAL.Models;
using SolarWinds.Tools.DataGeneration.Helpers;
using SolarWinds.Tools.DataGeneration.Services.OrionSWISQueryClient;

namespace SolarWinds.Tools.DataGeneration.DAL.SwisEntities
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
            var netObjectType = SwisEntity.Get<NetObjectTypes>().FirstOrDefault(_=>_.EntityType == entityType);
            return netObjectType.GetNetObjectId(entityId);
        }

        public string GetNetObjectId(int entityId) => $"{this?.Prefix ?? this.EntityType}{separator}{entityId}";

        public static NetObjectTypes Get(string entityType) => GetList().FirstOrDefault(_ => _.EntityType == entityType);
        public static IList<NetObjectTypes> GetList() => SwisEntity.Get<NetObjectTypes>().ToList();

        public static IList<NetObjectTypes> GetInstances()
        {
            var instanceTypes = SwisEntity.GetInstanceTypes();
            return GetList().Where(_ => instanceTypes.Contains(_.EntityType)).ToList();
        }

        public static Opid NetObjectIdToOpid(string netObjectId, int siteId=0)
        {
            try
            {
                var prefix = netObjectId.Split(separator)[0];
                var entityId = Int32.Parse(netObjectId.Split(separator)[1]);
                var entityType = GetInstances().FirstOrDefault(_ => _.Prefix == prefix).EntityType;
                return new Opid
                {
                    SiteId = siteId,
                    EntityId = entityId,
                    EntityType = entityType
                };
            }
            catch (Exception e)
            {
                ConsoleLogger.Error(e);
            }

            return null;
        }
    }
}
