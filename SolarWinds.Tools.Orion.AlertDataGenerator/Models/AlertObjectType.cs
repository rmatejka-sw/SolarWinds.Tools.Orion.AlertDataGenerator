using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Caching.Memory;
using SolarWinds.Tools.CommandLineTool.Helpers;

namespace SolarWinds.Tools.Orion.AlertDataGenerator.Models
{
    public class AlertObjectType
    {
        public string ObjectType { get; set; }
        public string EntityType { get; set; }


        public static IList<AlertObjectType> Get()
        {
            try
            {
                return CacheManager.Cache.GetOrCreate(typeof(AlertObjectType), entry =>
                    AlertDataGenerator.DbConnection.Query<AlertObjectType>(
                        "SELECT DISTINCT ObjectType, RealEntityType as EntityType FROM [SolarWindsOrion].[dbo].[AlertHistoryView]").ToList());
            }
            catch (Exception e)
            {
                ConsoleLogger.Error(e);
            }

            return new List<AlertObjectType>
            {
                new AlertObjectType{ ObjectType="Node",EntityType="Orion.Nodes"},
                new AlertObjectType{ ObjectType="Volume",EntityType="Orion.Volumes"},
                new AlertObjectType{ ObjectType="Interface",EntityType="Orion.NPM.Interface"},
            };
        }
    }
}
