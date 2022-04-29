using System;
using Microsoft.Data.SqlClient;
using SolarWinds.Tools.CommandLineTool.Options;

namespace SolarWinds.Tools.CommandLineTool.Helpers
{
    public static class DbConnectionManager
    {

        public static SqlConnection DbConnection;

        public static SqlConnection ConnectToDatabase(IDatabaseOptions options)
        {

            try
            {
                var builder = new SqlConnectionStringBuilder
                {
                    DataSource = options.DbServerName,
                    InitialCatalog = options.DbName,
                    UserID = options.DbUserName,
                    Password = options.DbPassword,
                    Encrypt = false
                };

                var connectionString = builder.ToString();

                return DbConnection = new SqlConnection(connectionString);

            }
            catch (Exception e)
            {
                ConsoleLogger.Error(e);
            }

            return null;
        }
    }
}
