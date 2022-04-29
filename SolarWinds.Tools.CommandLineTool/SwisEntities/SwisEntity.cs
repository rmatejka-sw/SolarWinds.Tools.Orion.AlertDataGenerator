using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DapperExtensions.Mapper;
using Microsoft.Extensions.Caching.Memory;
using SolarWinds.Tools.CommandLineTool.Extensions;
using SolarWinds.Tools.CommandLineTool.Helpers;
using SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient;

namespace SolarWinds.Tools.CommandLineTool.SwisEntities
{
    public abstract class SwisEntity
    {

        protected abstract string SwisEntityType { get; }
        
        public static IList<T> Get<T>(SwisClient swisClient) where T : class, new()
        {
            try
            {
                var query = @$"SELECT {typeof(T).GetPropertyList()} FROM {(new T() as SwisEntity).SwisEntityType}";
                return CacheManager.Cache.GetOrCreate(
                    typeof(T),
                    cacheEntry => swisClient.QueryList<T>(query)
                );
            }
            catch (Exception e)
            {
                ConsoleLogger.Error(e);
            }

            return Enumerable.Empty<T>().ToList();
        }


        public static IList<System_ManagedEntity> GetManagedEntity(SwisClient swisClient, string entityType, int? entityId = null, string displayName="", int maxItems=100) 
        {
            try
            {
                var query = @$"SELECT TOP {maxItems} {typeof(System_ManagedEntity).GetPropertyList()} FROM System.ManagedEntity WHERE InstanceType = '{entityType}'";
                if (entityId.HasValue)
                {
                    query += $" and Uri like '%={entityId}'";
                }
                if (!String.IsNullOrEmpty(displayName))
                {
                    query += $" and DisplayName = '{displayName}'";
                }
                return CacheManager.Cache.GetOrCreate(
                    query,
                    cacheEntry => swisClient.QueryList<System_ManagedEntity>(query)
                );
            }
            catch (Exception e)
            {
                ConsoleLogger.Error(e);
            }

            return Enumerable.Empty<System_ManagedEntity>().ToList();
        }
    }
}
