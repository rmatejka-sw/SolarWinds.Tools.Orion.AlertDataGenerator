using System;
using SolarWinds.Tools.DataGeneration.Helpers;
using SolarWinds.Tools.DataGeneration.Services.MapsClient;
using SolarWinds.Tools.DataGeneration.Services.OrionSWISQueryClient;
using SolarWinds.Tools.DataGeneration.Services.PerfStackClient;

namespace SolarWinds.Tools.DataGeneration.Services
{
    public static class WebApiManager
    {
        private static WebApiClients WebApi;
        public static SwisClient Swis => WebApi.SwisClient;
        public static PerfStackEntitiesClient PerfStackEntities => WebApi.PerfStackEntitiesClient;
        public static PerfStackMetadataClient PerfStackMetadata => WebApi.PerfStackMetadataClient;
        public static MapsEntitiesClient MapsEntities => WebApi.MapsEntitiesClient;
        public static MapsGraphClient MapsGraph => WebApi.MapsGraphClient;

        public static void InitializeWebApiClients(string orionServerName, string orionUserName, string orionPassword)
        {
            try
            {
                WebApi = new WebApiClients($"http://{orionServerName}/",
                   new OrionCredentials(orionServerName, orionUserName, orionPassword));
            }
            catch (Exception e)
            {
                ConsoleLogger.Error(e);
            }
        }
    }
}
