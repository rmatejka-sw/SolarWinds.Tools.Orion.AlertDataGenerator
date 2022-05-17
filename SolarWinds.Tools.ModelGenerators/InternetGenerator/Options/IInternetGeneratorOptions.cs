using CommandLine;
using SolarWinds.Tools.CommandLineTool.Options;

namespace SolarWinds.Tools.ModelGenerators.InternetGenerator.Options
{
    /// <summary>
    /// Options for generating a topology typical of the Internet.
    /// </summary>
    public interface IInternetGeneratorOptions : ICommandLineOptions
    {

        [Option("MaxHops", Default=10, HelpText = "Specifies the maximum number of hops between a the start and ending node for a network path.")]
        public int MaxHops { get; set; }

        [Option("MinNodes", Default=100, HelpText = "Specifies the minimum number of total nodes to generate for the network. Actual total may be slightly higher.")]
        public int MinNodes { get; set; }

        [Option("ShadowNodes", Default = 0, HelpText = "Percentage of nodes from 0-100 that should be Shadow Nodes. Default is no shadow nodes.")]
        public int ShadowNodes { get; set; }

        [Option("MaxInternalNodes", Default = 0, HelpText = "The maximum number of nodes to generate for an internal subnet. Default is random up to 5.")]
        public int MaxInternalNodes { get; set; }

        [Option("MaxConnectionsBetweenNodes", Default = 1, HelpText = "Allows for generating multiple connections between nodes. Default is one connection between each node.")]
        public int MaxConnectionsBetweenNodes { get; set; }

        [Option("ExcludeIntranetDevices", Default = false, HelpText = "If true, subnets of nodes within the private Internet Ip Address ranges will be NOT created. Default is to create Intranet devices.")]
        public bool ExcludeIntranetDevices { get; set; }

    }
}
