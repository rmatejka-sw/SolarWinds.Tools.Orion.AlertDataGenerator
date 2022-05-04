using CommandLine;
using SolarWinds.Tools.CommandLineTool.Options;
using SolarWinds.Tools.ModelGenerators.InternetGenerator.Options;

namespace SolarWinds.Tools.NetworkGenerator.Options
{
    [Verb("GenerateNetwork")]
    public class NetworkGeneratorOptions : IInternetGeneratorOptions, IDatabaseOptions, ITimeRangeOptions, IOrionOptions
    {
        public int MaxHops { get; set; }
        public int MinNodes { get; set; }
        public int ShadowNodes { get; set; }
        public int MaxInternalNodes { get; set; }
        public int MaxConnectionsBetweenNodes { get; set; }
        public bool ExcludeIntranetDevices { get; set; }
        public string DbServerName { get; set; }
        public string DbName { get; set; }
        public string DbUserName { get; set; }
        public string DbPassword { get; set; }
        public int PastDays { get; set; }
        public int FutureDays { get; set; }
        public int PollingInterval { get; set; }
        public string OrionServerName { get; set; }
        public string OrionUserName { get; set; }
        public string OrionPassword { get; set; }
    }
}
