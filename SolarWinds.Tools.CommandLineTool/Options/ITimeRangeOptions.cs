using CommandLine;

namespace SolarWinds.Tools.CommandLineTool.Options
{
    public interface ITimeRangeOptions : ICommandLineOptions
    {

        [Option("pastDays", Default = 0, HelpText = "Total number of days into the past to generate data.")]
        int PastDays { get; set; }

        [Option("futureDays", Default = 0, HelpText = "Total number of days into the future to generate data.")]
        int FutureDays { get; set; }

        [Option("pollingIntervalMinutes", Default = 2, HelpText = "Polling interval in minutes.")]
        int PollingInterval { get; set; }
    }
}
