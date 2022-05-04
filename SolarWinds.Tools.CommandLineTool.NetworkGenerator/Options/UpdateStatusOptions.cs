using CommandLine;
using SolarWinds.Tools.CommandLineTool.Options;

namespace SolarWinds.Tools.NetworkGenerator.Options
{
    /// <summary>
    /// Called on an existing network of fakes. Updates status for all entities to new faked values
    /// </summary>
    [Verb("UpdateStatus")]
    public class UpdateStatusOptions : ICommandLineOptions
    {
 
    }
}
