using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using SolarWinds.Tools.CommandLineTool.Extensions;
using SolarWinds.Tools.CommandLineTool.Helpers;

namespace SolarWinds.Tools.Orion.AlertDataGenerator.Models
{
    public class NetObjectType
    {
        private static char separator = ':';

        public string EntityType { get; set; }
        public string Name { get; set; }
        public string Prefix { get; set; }
        public string KeyProperty { get; set; }
        public string NameProperty { get; set; }
        public string KeyPropertyIndex { get; set; }

        public static string GetNetObjectId(string entityType, int entityId)
        {
            var netObjectType = Get().FirstOrDefault(_=>_.EntityType == entityType);
            return $"{netObjectType?.Prefix?? entityType}{separator}{entityId}";
        }
        public static IList<NetObjectType> Get()
        {
            try
            {
                var query = @"SELECT EntityType, Name, Prefix, KeyProperty, NameProperty, KeyPropertyIndex
                FROM Orion.NetObjectTypes
                ";
                return CacheManager.Cache.GetOrCreate(
                    typeof(NetObjectType), 
                    cacheEntry=>AlertDataGenerator.WebApiClients.SwisClient.QueryList<NetObjectType>(query)
                    );
            }
            catch (Exception e)
            {
                ConsoleLogger.Error(e);
            }

            return Enumerable.Empty<NetObjectType>().ToList();
        }
    }
}
