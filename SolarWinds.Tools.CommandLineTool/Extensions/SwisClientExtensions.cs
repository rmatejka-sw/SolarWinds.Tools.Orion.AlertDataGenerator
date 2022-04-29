using System;
using System.Collections.Generic;
using System.Linq;
using SolarWinds.Tools.CommandLineTool.Helpers;
using SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient;

namespace SolarWinds.Tools.CommandLineTool.Extensions
{
    public static class SwisClientExtensions
    {

        public static IList<T> QueryList<T>(this SwisClient swisClient, string query) where T : class, new()
        {
            try
            {
                var records = new List<T>();
                var result = swisClient.QueryAsync(new QueryParam {Query = query}).Result.Result.ToList();
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
    }
}
