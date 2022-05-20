using CommandLine;

namespace SolarWinds.Tools.CommandLineTool.Options
{
    public interface IOrionOptions : ICommandLineOptions
    {
        [Option("orionserver", Default = "localhost", HelpText = "Name of the orion server which will be used to generate data.")]
        public string OrionServerName { get; set; }
        
        [Option("https", Default = false, HelpText = "Specify is server uses HTTPS.")]
        public bool UseHttps { get; set; }
        
        [Option("orionuser", Default = "admin", HelpText = "Orion username for login")]
        public string OrionUserName { get; set; }

        [Option("orionpassword", Default = "1qazXSW@", HelpText = "Orion user password")]
        public string OrionPassword { get; set; }


    }
}
