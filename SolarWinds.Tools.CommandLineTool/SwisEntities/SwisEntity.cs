using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Caching.Memory;
using SolarWinds.Tools.CommandLineTool.Extensions;
using SolarWinds.Tools.CommandLineTool.Helpers;

namespace SolarWinds.Tools.CommandLineTool.SwisEntities
{
    public abstract class SwisEntity
    {

        protected abstract string SwisEntityType { get; }
        
        public static IList<T> Get<T>() where T : class, new()
        {
            try
            {
                var query = @$"SELECT * FROM {(new T() as SwisEntity).SwisEntityType}";
                return CacheManager.Cache.GetOrCreate(
                    typeof(T),
                    cacheEntry => WebApiManager.Swis.QueryList<T>(query)
                );
            }
            catch (Exception e)
            {
                ConsoleLogger.Error(e);
            }

            return Enumerable.Empty<T>().ToList();
        }

        public static IList<System_ManagedEntity> GetManagedEntity( string query)
        {
            try
            {
               return CacheManager.Cache.GetOrCreate(
                    query,
                    cacheEntry => WebApiManager.Swis.QueryList<System_ManagedEntity>(query)
                );
            }
            catch (Exception e)
            {
                ConsoleLogger.Error(e);
            }

            return Enumerable.Empty<System_ManagedEntity>().ToList();
        }

        public static IList<System_ManagedEntity> GetManagedEntityByType( string entityType, int? entityId = null, string displayName="", int maxItems=100) 
        {
            try
            {
                var query = @$"SELECT TOP {maxItems} * FROM System.ManagedEntity WHERE InstanceType = '{entityType}'";
                if (entityId.HasValue)
                {
                    query += $" and Uri like '%={entityId}'";
                }
                if (!String.IsNullOrEmpty(displayName))
                {
                    query += $" and DisplayName = '{displayName}'";
                }

                return GetManagedEntity(query);
            }
            catch (Exception e)
            {
                ConsoleLogger.Error(e);
            }

            return Enumerable.Empty<System_ManagedEntity>().ToList();
        }

        public static IList<string> GetInstanceTypes(int maxItems=100)
        {
            return CacheManager.Cache.GetOrCreate(
                "GetInstanceTypes", cacheEntry =>
                    System_ManagedEntity.GetManagedEntity(
                            $"SELECT DISTINCT TOP {maxItems} InstanceType FROM System.ManagedEntity")
                        .Select(_ => _.InstanceType).ToList());
        }

        public static IList<System_ManagedEntity> GetInstanceEntities(int maxItems = 100)
        {
            return CacheManager.Cache.GetOrCreate(
                "GetInstanceEntities", cacheEntry =>
                    System_ManagedEntity.GetManagedEntity(
                            $"SELECT TOP {maxItems} * FROM System.ManagedEntity WHERE InstanceType in ({GetInstanceTypes().ToStringList<string>(",","'")})")
                        .ToList());
        }


    }
}
