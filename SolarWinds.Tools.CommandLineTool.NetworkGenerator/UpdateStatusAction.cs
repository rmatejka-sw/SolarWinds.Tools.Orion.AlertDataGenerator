using System;
using CommandLine;
using SolarWinds.Tools.CommandLineTool.Options;
using SolarWinds.Tools.DataGeneration.Helpers;

namespace SolarWinds.Tools.CommandLineTool.NetworkGenerator
{
    /// <summary>
    /// Called on an existing network of fakes. Updates status for all entities to new faked values
    /// </summary>
    [Verb("UpdateStatus")]
    public class UpdateStatusAction : ActionBase, ICommandLineOptions, ICommandLineAction
    {

        public RunStatus Run(DateTime? timeInterval = null)
        {
            try
            {
                this.NetworkGenerator.UpdateStatuses();
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
