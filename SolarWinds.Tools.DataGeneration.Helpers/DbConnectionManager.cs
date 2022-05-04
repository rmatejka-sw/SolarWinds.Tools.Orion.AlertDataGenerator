using System;
using Microsoft.Data.SqlClient;

namespace SolarWinds.Tools.DataGeneration.Helpers
{
    public static class DbConnectionManager
    {

        public static SqlConnection DbConnection;

        public static SqlConnection ConnectToDatabase(string serverName, string userName, string password, string dbName)
        {

            try
            {
                var builder = new SqlConnectionStringBuilder
                {
                    DataSource = serverName,
                    InitialCatalog = dbName,
                    UserID = userName,
                    Password = password,
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
