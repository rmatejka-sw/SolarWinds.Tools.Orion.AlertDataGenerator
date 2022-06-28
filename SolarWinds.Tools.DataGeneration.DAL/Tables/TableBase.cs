using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using AutoBogus;
using Dapper;
using DapperExtensions;
using Microsoft.Extensions.Caching.Memory;
using SolarWinds.Tools.DataGeneration.Helpers;
using SolarWinds.Tools.DataGeneration.Helpers.Extensions;
using TableAttribute = Dapper.Contrib.Extensions.TableAttribute;

namespace SolarWinds.Tools.DataGeneration.DAL.Tables
{
    public class TableBase<T> where T : class, new()
    {

        static TableBase()
        {
            Dapper.SqlMapper.SetTypeMap(
                typeof(T),
                new CustomPropertyTypeMap(
                    typeof(T),
                    (type, columnName) =>
                        type.GetProperties().FirstOrDefault(prop =>
                            prop.GetCustomAttributes(false)
                                .OfType<ColumnAttribute>()
                                .Any(attr => attr.Name == columnName))
                        ?? type.GetProperties().FirstOrDefault(_ => _.Name == columnName)
                        )
                );

        }

        public static IList<T> GetList(bool noCache = false)
        {
            try
            {
                return noCache
                    ? DbConnectionManager.DbConnection.GetList<T>().ToList()
                        : CacheManager.Cache.GetOrCreate<IList<T>>(typeof(IList<T>), ce => DbConnectionManager.DbConnection.GetList<T>().ToList());
            }
            catch (Exception e)
            {
                ConsoleLogger.Error(e);
            }

            return null;
        }

        public static IList<T> GetList(string query)
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

        public static int GetMaxId(string columnName)
        {
            try
            {
                var tableAttribute = typeof(T).GetCustomAttributes().FirstOrDefault(a => a.GetType() == typeof(TableAttribute)) as TableAttribute;
                var tableName = tableAttribute != null ? tableAttribute.Name : typeof(T).Name;
                return (int)DbConnectionManager.DbConnection.Query<int>($"SELECT MAX({columnName}) from {tableName}")
                    .FirstOrDefault();
            }
            catch (Exception e)
            {
                ConsoleLogger.Error(e);
            }

            return 0;
        }

        public virtual T Populate()
        {
            //new AutoFaker<T>().Populate(this as T);
            return this as T;
        }
        public virtual T Populate(long relatedId)
        {
            //new AutoFaker<T>().Populate(this as T);
            return this as T;
        }

    }
}
