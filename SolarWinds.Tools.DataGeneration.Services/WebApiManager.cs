using System;
using SolarWinds.Tools.CommandLineTool.Service;
using SolarWinds.Tools.DataGeneration.Helpers;
using SolarWinds.Tools.DataGeneration.Services.MapsClient;
using SolarWinds.Tools.DataGeneration.Services.OrionSWISQueryClient;

namespace SolarWinds.Tools.DataGeneration.Services
{
    public static class WebApiManager
    {
        private static WebApiClients WebApi;
        public static SwisClient Swis => WebApi.SwisClient;
        public static PerfStackEntitiesClient PerfStackEntities => WebApi.PerfStackEntitiesClient;
        public static PerfStackMetadataClient PerfStackMetadata => WebApi.PerfStackMetadataClient;
        public static PerfStackMetricsClient PerfStackMetrics => WebApi.PerfStackMetricsClient;
        public static MapsEntitiesClient MapsEntities => WebApi.MapsEntitiesClient;
        public static MapsGraphClient MapsGraph => WebApi.MapsGraphClient;

        public static bool IsAuthenticated => WebApi.Authenticator.IsAuthenticated;
        public static string AuthenticationError => WebApi.Authenticator.AuthenticationError;
            
        public static bool InitializeWebApiClients(string orionServerName, string orionUserName, string orionPassword, bool useHttps)
        {
            try
            {
                WebApi = new WebApiClients($"http{(useHttps? "s" : "")}://{orionServerName}/",
                   new OrionCredentials(orionServerName, orionUserName, orionPassword));
                return WebApi.Authenticator.IsAuthenticated;
            }
            catch (Exception e)
            {
                ConsoleLogger.Error(e);
            }

            return false;
        }
    }
}
