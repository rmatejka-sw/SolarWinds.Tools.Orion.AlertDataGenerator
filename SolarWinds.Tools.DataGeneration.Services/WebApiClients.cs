using SolarWinds.Tools.DataGeneration.Services.MapsClient;
using System;
using System.Net;
using System.Net.Http;
using SolarWinds.Tools.CommandLineTool.Service;
using SolarWinds.Tools.DataGeneration.Helpers;
using SolarWinds.Tools.DataGeneration.Services.OrionSWISQueryClient;

namespace SolarWinds.Tools.DataGeneration.Services
{
    public class WebApiClients : IDisposable
    {
        private string _serverUrl;

        public WebApiClients(string serverUrl, OrionCredentials credentials)
        {
            this._serverUrl = serverUrl;
            string serviceUrl = $"{serverUrl}/api2/";
            this.OrionCredentials = credentials;
            this.Authenticator = new OrionAuthenticator(serverUrl, credentials.UserName, credentials.Password);
            this.Authenticator.AuthenticateRestClient();
            this.PerfStackEntitiesClient = new PerfStackEntitiesClient(serviceUrl, this.Authenticator.HttpClient);
            this.PerfStackMetadataClient = new PerfStackMetadataClient(serviceUrl, this.Authenticator.HttpClient);
            this.PerfStackMetricsClient = new PerfStackMetricsClient(serviceUrl, this.Authenticator.HttpClient);
            this.MapsEntitiesClient = new MapsEntitiesClient(serviceUrl, this.Authenticator.HttpClient);
            this.MapsGraphClient = new MapsGraphClient(serviceUrl, this.Authenticator.HttpClient);
            this.SwisClient = new SwisClient(serviceUrl, this.Authenticator.HttpClient);
        }

        public bool KeepAlive()
        {
            try
            {
                var response = this.Authenticator.HttpClient.GetAsync(this._serverUrl, HttpCompletionOption.ResponseHeadersRead).Result;
                return response != null && response.StatusCode == HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                ConsoleLogger.Error(ex);
            }
            return false;
        }

        public OrionAuthenticator Authenticator { get; }
        public PerfStackEntitiesClient PerfStackEntitiesClient { get; }
        public PerfStackMetadataClient PerfStackMetadataClient { get; }
        public PerfStackMetricsClient PerfStackMetricsClient { get; }
        public MapsEntitiesClient MapsEntitiesClient { get; }
        public MapsGraphClient MapsGraphClient { get; set; }
        public SwisClient SwisClient { get; set; }

        public OrionCredentials OrionCredentials { get; set; }

        public void Dispose() => Authenticator?.Dispose();
    }
}
