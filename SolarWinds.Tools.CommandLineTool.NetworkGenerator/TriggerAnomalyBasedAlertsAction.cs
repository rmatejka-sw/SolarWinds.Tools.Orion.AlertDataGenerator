using System;
using Bogus.DataSets;
using CommandLine;
using SolarWinds.Tools.CommandLineTool.Options;
using SolarWinds.Tools.DataGeneration.Helpers;
using SolarWinds.Tools.ModelGenerators.Metrics;

namespace SolarWinds.Tools.CommandLineTool.NetworkGenerator
{
    /// <summary>
    /// Called after using GenerateNetwork with the IncludeAiimAnomalies option to
    /// trigger the Anomaly Based Alerts based on the generated anomalies by populating
    /// the Entity Anomaly backing tables (AIIM_Orion_Nodes_Anomalies, AIIM_Orion_Volumes_Anomalies).
    /// Must be left running since it needs to update the  tables in real time!!!
    [Verb("TriggerAnomalyBasedAlerts", HelpText = "Called after using GenerateNetwork with the IncludeAiimAnomalies option to  trigger the Anomaly Based Alerts based on the generated anomalies. Must be left running since it needs to update the  tables in real time!!!")]
    public class TriggerAnomalyBasedAlertsAction : ActionBase, ICommandLineOptions, ICommandLineAction, IDatabaseOptions
    {
        public string DbServerName { get; set; }
        public string DbName { get; set; }
        public string DbUserName { get; set; }
        public string DbPassword { get; set; }

        [Option("PollingInterval", Default = 2, HelpText = "Time in minutes between checking if new alerts can be triggered.")]
        public int PollingInterval { get; set; }

        [Option("MaxRunTime", HelpText = "Maximum time to continue running in hours. Default is unlimited.")]
        public int? MaxRunTime { get; set; }


        [Option("MaxAlerts", Default = 5000, HelpText = "Specifies the maximum number alerts to generate before exiting.")]
        public int MaxAlerts { get; set; }

        public RunStatus Run(DateTime? timeInterval = null, TimeRange timeRange = null)
        {
            try
            {
                var startTime = DateTime.UtcNow;
                var endTime = startTime.AddHours(MaxRunTime ?? 1000);
                var pollingInterval = TimeSpan.FromMinutes(PollingInterval);
                this.NetworkGenerator.TriggerAnomalyBasedAlerts(new TimeRange(startTime,endTime, pollingInterval), MaxAlerts);
                return RunStatus.Success;
            }
            catch (Exception e)
            {
                ConsoleLogger.Error(e);
            }

            return RunStatus.CommandError;
        }

        public void AfterRun()
        {
        }

        public void BeforeRun(CommandLineTool commandLineTool)
        {
            this.NetworkGenerator = commandLineTool as NetworkGenerator;
        }
    }
}
