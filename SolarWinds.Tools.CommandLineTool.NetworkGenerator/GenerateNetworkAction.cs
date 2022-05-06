using System;
using CommandLine;
using SolarWinds.Tools.CommandLineTool.Options;
using SolarWinds.Tools.DataGeneration.Helpers;
using SolarWinds.Tools.ModelGenerators.InternetGenerator.Options;

namespace SolarWinds.Tools.CommandLineTool.NetworkGenerator.Options
{
    [Verb("GenerateNetwork")]
    public class GenerateNetworkAction : ActionBase, ICommandLineAction, IInternetGeneratorOptions, IDatabaseOptions, ITimeRangeOptions,
    IOrionOptions
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
        
        public RunStatus Run(DateTime? timeInterval = null)
        {
            try
            {
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
            if (this.NetworkGenerator == null)
            {
                ConsoleLogger.Error("BeforeRun failed to cast commandLineTool to NetworkGenerator");
                return;
            }
            this.NetworkGenerator.CreateNetworkElements(this);
        }
    }
}
