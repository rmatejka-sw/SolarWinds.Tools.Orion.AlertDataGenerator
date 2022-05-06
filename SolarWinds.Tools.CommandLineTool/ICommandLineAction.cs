using System;
using SolarWinds.Tools.CommandLineTool.Options;

namespace SolarWinds.Tools.CommandLineTool
{
    public interface ICommandLineAction : ICommandLineOptions
    {
        /// <summary>
        /// Called by CommandLineTool once per action with no arguments. If
        /// ITimeRangeOptions have been implemented, this will be called for
        /// every interval as defined in ITimeRangeOptions parameters and passed
        /// the timeInterval. For example, -pastdays 5 and -PollingInterval 10
        /// minutes would result in 5*24*60/10= 720 calls to this method with the time
        /// going from Now to 5 days in the past.
        /// </summary>
        /// <param name="timeInterval">Current time interval</param>
        /// <returns>Status of operation</returns>
        RunStatus Run(DateTime? timeInterval = null);

        /// <summary>
        /// Called by CommandLineTool prior to calling Run
        /// </summary>
        void AfterRun();

        /// <summary>
        /// Called by CommandLineTool after run has completed.
        /// </summary>
        void BeforeRun(CommandLineTool commandLineTool);
    }
}
