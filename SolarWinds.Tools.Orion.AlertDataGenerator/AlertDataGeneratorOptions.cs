using Bogus;
using CommandLine;
using SolarWinds.Tools.CommandLineTool;
using SolarWinds.Tools.CommandLineTool.Helpers;
using SolarWinds.Tools.CommandLineTool.Options;


namespace SolarWinds.Tools.Orion.AlertDataGenerator
{
    public class AlertDataGeneratorOptions : IDatabaseOptions, ITimeRangeOptions, IOrionOptions
    {
        [Option("alertsPerHour", Default = 10000, HelpText = "Total number of alerts to generate per hour.")]
        public int AlertsPerHour { get; set; }
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

        public int AlertPerInterval => this.AlertsPerHour * 60 / this.PollingInterval;

        public int AlertPerIntervalRandom =>
            FakerHelper.Faker.Random.Int(1, AlertPerInterval);

    }
}
