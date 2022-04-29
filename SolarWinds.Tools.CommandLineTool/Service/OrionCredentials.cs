using System;
using System.Text.Json.Serialization;
using SolarWinds.Tools.CommandLineTool.Extensions;

namespace SolarWinds.Tools.CommandLineTool.Service
{
    public class OrionCredentials
    {
        private static readonly string SKey = "!z%C*F-J@NcRfUjXn2r5u8x/A?D(G+Kb";

        public OrionCredentials()
        {
        }

        public OrionCredentials(string server, string userName, string password)
        {
            this.Server = server;
            this.UserName = userName;
            this.Password = password;
        }

        public Uri ConnectionTestUri => new Uri($"{this.ServerUrl.TrimEnd('/')}/orion/admin/default_orion.aspx");
        public string ServerUrl => this.Server.IndexOf("http", StringComparison.CurrentCultureIgnoreCase) == -1 ? $"https://{this.Server}/" : this.Server;
        public string Server { get; set; }
        public string UserName { get; set; }

        [JsonIgnore]
        public string Password
        {
            get => this.PasswordEncrypted.Decrypt(SKey);
            set => this.PasswordEncrypted = value.Encrypt(SKey);
        }

        public string PasswordEncrypted { get; set; }
    }
}
