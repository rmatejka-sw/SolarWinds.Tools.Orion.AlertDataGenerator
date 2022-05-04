using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using DapperExtensions;
using Microsoft.Extensions.Caching.Memory;
using SolarWinds.Tools.DataGeneration.Helpers;
using SolarWinds.Tools.DataGeneration.Helpers.Extensions;

namespace SolarWinds.Tools.DataGeneration.DAL.Tables
{
    public class TableBase
    {
        public static IList<T> GetList<T>() where T : class, new()
        {
            try
            {
                return CacheManager.Cache.GetOrCreate<IList<T>>(typeof(IList<T>), ce => DbConnectionManager.DbConnection.GetList<T>().ToList());
            }
            catch (Exception e)
            {
                ConsoleLogger.Error(e);
            }

            return null;
        }

        public static IList<T> GetList<T>(string query) where T : class, new()
        {
            try
            {
                return DbConnectionManager.DbConnection.Query<T>(query.ExpandAsteriskToPropList<T>()).ToList();
            }
            catch (Exception e)
            {
                ConsoleLogger.Error(e);
            }

            return Enumerable.Empty<T>().ToList();
        }

    }
}
