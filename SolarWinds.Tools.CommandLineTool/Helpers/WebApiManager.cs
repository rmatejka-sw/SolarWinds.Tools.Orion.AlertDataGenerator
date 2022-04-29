using System;
using SolarWinds.Tools.CommandLineTool.Options;
using SolarWinds.Tools.CommandLineTool.Service;
using SolarWinds.Tools.CommandLineTool.Service.MapsClient;
using SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient;
using SolarWinds.Tools.CommandLineTool.Service.PerfStackClient;

namespace SolarWinds.Tools.CommandLineTool.Helpers
{
    public static class WebApiManager
    {
        private static WebApiClients WebApi;
        public static SwisClient Swis => WebApi.SwisClient;
        public static PerfStackEntitiesClient PerfStackEntities => WebApi.PerfStackEntitiesClient;
        public static PerfStackMetadataClient PerfStackMetadata => WebApi.PerfStackMetadataClient;
        public static MapsEntitiesClient MapsEntities => WebApi.MapsEntitiesClient;
        public static MapsGraphClient MapsGraph => WebApi.MapsGraphClient;

        public static void InitializeWebApiClients(IOrionOptions options)
        {
            try
            {
                WebApi = new WebApiClients($"http://{options.OrionServerName}/",
                   new OrionCredentials(options.OrionServerName, options.OrionUserName, options.OrionPassword));
            }
            catch (Exception e)
            {
                ConsoleLogger.Error(e);
            }
        }
    }
}
