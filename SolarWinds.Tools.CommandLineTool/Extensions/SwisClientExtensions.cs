using System;
using System.Collections.Generic;
using System.Linq;
using SolarWinds.Tools.CommandLineTool.Helpers;
using SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient;
using SolarWinds.Tools.CommandLineTool.SwisEntities;

namespace SolarWinds.Tools.CommandLineTool.Extensions
{
    public static class SwisClientExtensions
    {

        public static IList<T> QueryList<T>(this SwisClient swisClient, string query) where T : class, new()
        {
            try
            {
                var records = new List<T>();
                var result = swisClient.QueryAsync(new QueryParam {Query = query.ExpandAsteriskToPropList<T>()}).Result.Result.ToList();
                foreach (object resultObject in result)
                {
                    records.Add(resultObject.ToClass<T>());
                }
                return records;
            }
            catch (Exception e)
            {
                ConsoleLogger.Error(e);
            }

            return Enumerable.Empty<T>().ToList();
        }

        private class IdResult
        {
            public int ID { get; set; }
        }
        public static IList<int> GetEntityIds(this SwisClient swisClient, string entityType, int maxRecords = 100)
        {
            try
            {
                var netObjectType = SwisEntity.Get<NetObjectTypes>().FirstOrDefault(_ => _.EntityType == entityType);
                string query = $"SELECT TOP {maxRecords} {netObjectType.KeyProperty} as ID from {entityType}";
                return swisClient.QueryList<IdResult>(query).Select(_ => _.ID).ToList();

            }
            catch (Exception e)
            {
                ConsoleLogger.Error(e);
            }

            return Enumerable.Empty<int>().ToList();
        }

    }
}
