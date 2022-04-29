using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Dapper;
using DapperExtensions;
using Microsoft.Extensions.Caching.Memory;
using SolarWinds.Tools.CommandLineTool.Extensions;
using SolarWinds.Tools.CommandLineTool.Helpers;

namespace SolarWinds.Tools.CommandLineTool.SqlEntities
{
    public class SqlEntityBase
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
                return DbConnectionManager.DbConnection.Query<T>(query.Replace("*", typeof(T).GetPropertyList())).ToList();
            }
            catch (Exception e)
            {
                ConsoleLogger.Error(e);
            }

            return Enumerable.Empty<T>().ToList();
        }


    }
}
