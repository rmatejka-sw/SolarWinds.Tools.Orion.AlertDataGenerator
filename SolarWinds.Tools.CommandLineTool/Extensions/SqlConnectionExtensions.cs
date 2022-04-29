using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using Dapper;
using DapperExtensions;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Caching.Memory;
using SolarWinds.Tools.CommandLineTool.Helpers;

namespace SolarWinds.Tools.CommandLineTool.Extensions
{
    public static class SqlConnectionExtensions
    {
        public static TRecord GetRandomRecord<TRecord>(this SqlConnection dbConnection, Func<TRecord,bool> filter = null)
            where TRecord : class, new()
        {
            try
            {
                IEnumerable<TRecord> randomRecords = CacheManager.Cache.GetOrCreate(typeof(TRecord), entry => dbConnection.GetListAutoMap<TRecord>());
                if (filter != null)
                {
                    randomRecords = randomRecords.Where(_ => filter(_));
                }
                return FakerHelper.Faker.PickRandom<TRecord>(randomRecords);
            }
            catch (Exception e)
            {
                ConsoleLogger.Error(e);
            }

            return null;
        }

    }
}
