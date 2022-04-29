using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using ScrapySharp.Extensions;
using SolarWinds.Tools.CommandLineTool.Helpers;

namespace SolarWinds.Tools.CommandLineTool.Service
{
    /// <summary>
    /// Class that will do authentication against Orion.
    /// </summary>
    public class OrionAuthenticator : IDisposable
    {
        private static readonly Regex SFormRegex = new Regex(@"<form[\S\s]*</form>", RegexOptions.Compiled | RegexOptions.Multiline);
        private static readonly Regex STargetRegex = new Regex(@"WebForm_PostBackOptions\s*\(\s*""\s*(?<target>.*?)\s*""", RegexOptions.Compiled);
        private const string LoginSegment = "Orion/Login.aspx";
        private readonly string password;
        private readonly string userName;
        private readonly string orionUrl;
        private readonly string xfsrToken = "XSRF-TOKEN";

        public HttpClient HttpClient { get; set; }

        //private class UntrustedCertClientFactory : DefaultHttpClientFactory
        //{

        //    public override HttpMessageHandler CreateMessageHandler()
        //    {
        //        s_httpClientMessageHandler = base.CreateMessageHandler() as HttpClientHandler;
        //        //s_httpClientMessageHandler.CookieContainer = new CookieContainer(10);
        //        s_httpClientMessageHandler.ServerCertificateCustomValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
        //        return s_httpClientMessageHandler;
        //    }
        //}

        public OrionAuthenticator(string orionUrl, string userName, string password)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException(nameof(userName));
            }

            //this.Client = new FlurlClient().Configure(s =>
            //{
            //    s.HttpClientFactory = new UntrustedCertClientFactory();
            //});
            this.HttpClient = new HttpClient();
            this.HttpClient.DefaultRequestHeaders.Add("Connection", "close");
            this.orionUrl = orionUrl;
            this.userName = userName;
            this.password = password ?? string.Empty;
        }

        public void AuthenticateRestClient(bool reauthenticate = false)
        {
            // we need shared cookies since the authentication token is stored as a cookie between request
            this.HttpClient.BaseAddress = new Uri(this.orionUrl);
            if (!reauthenticate && this.HttpClient.DefaultRequestHeaders.Contains(".ASPXAUTH"))
            {
                // authentication cookie already exists
                return;
            }

            LogIntoOrion();
            //this.HttpClient.BaseAddress = new Uri($"{this.orionUrl}/api2");
        }

        private void LogIntoOrion()
        {
            try
            {
                var loginUrl = $"{this.orionUrl}{LoginSegment}";
                var loginResponse = this.HttpClient.GetStringAsync(new Uri(loginUrl)).Result;
                Dictionary<string, string> parameters = ParseLoginPage(loginResponse);
                PostLoginAsync(parameters);
                //var uri = new Uri(this.orionUrl);
                //foreach (var cookie in cookies)
                //{
                //    var cookieName = cookie.Name;// == xfsrToken ? $"X-{xfsrToken}" : xfsrToken;
                //    var httpClientCookie = new Cookie(cookieName, cookie.Value);
                //    httpClientCookie.Domain = uri.Host;
                //}
            }
            catch (Exception e)
            {
                ConsoleLogger.Error(e);
            }
        }

        private static Dictionary<string, string> ParseLoginPage(string response)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            // the html returned is not valid xml so we cannot convert the whole response. Find the form data and work with that.
            Match match = SFormRegex.Match(response);
            if (match.Success)
            {
                var form = new HtmlDocument();
                form.LoadHtml(match.Value);
                var inputElements = form.DocumentNode.CssSelect("input");
                foreach (var inputElement in inputElements)
                {
                    parameters[inputElement.GetAttributeValue("name")] = inputElement.GetAttributeValue("value");
                }

                var loginLink = form.DocumentNode.CssSelect("a[automation='Login']").FirstOrDefault();
                match = STargetRegex.Match(loginLink?.GetAttributeValue("href").Replace("&quot;", "\"") ?? "");
                if (match.Success)
                {
                    parameters["__EVENTTARGET"] = match.Groups["target"].Value;
                }
            }

            return parameters;
        }

        private void PostLoginAsync(Dictionary<string, string> parameters)
        {
            try
            {
                IList<KeyValuePair<string, string>> postParameters = new List<KeyValuePair<string, string>>();

                // use the parameters retrieved from the form, setting username and password as needed
                foreach (KeyValuePair<string, string> parameter in parameters)
                {
                    string value = parameter.Value;
                    if (parameter.Key.IndexOf("password", StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        value = this.password;
                    }

                    if (parameter.Key.IndexOf("username", StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        value = this.userName;
                    }
                    postParameters.Add(new KeyValuePair<string, string>(parameter.Key, value));
                }

                //var request = this.Client.Request(LoginSegment).WithCookies(out CookieJar cookies);
                //var loginResponse = request.PostUrlEncodedAsync(postParameters).Result;
                var url = $"{this.orionUrl}{LoginSegment}";
                var loginResponse = this.HttpClient
                    .PostAsync(url, new FormUrlEncodedContent(postParameters)).Result;
                if (loginResponse.RequestMessage.RequestUri.AbsoluteUri == url)
                {
                    throw new WebException("Incorrect credentials for log in.");
                }
            }
            catch (Exception ex)
            {
                ConsoleLogger.Error(ex);
            }
        }

        public void Dispose() => HttpClient?.Dispose();
    }
}
