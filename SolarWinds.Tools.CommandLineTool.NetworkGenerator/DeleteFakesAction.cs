using System;
using CommandLine;
using SolarWinds.Tools.CommandLineTool.Options;
using SolarWinds.Tools.DataGeneration.Helpers;

namespace SolarWinds.Tools.CommandLineTool.NetworkGenerator
{
    /// <summary>
    /// Deletes any fake data generated from previous runs.
    /// </summary>
    [Verb("DeleteFakes")]
    public class DeleteFakesAction : ICommandLineOptions, ICommandLineAction
    {
        protected NetworkGenerator NetworkGenerator { get; set; }

        public RunStatus Run(DateTime? timeInterval = null)
        {
            try
            {
                this.NetworkGenerator.DeleteFakes();
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
