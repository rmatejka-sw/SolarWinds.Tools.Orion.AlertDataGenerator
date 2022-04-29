using CommandLine;

namespace SolarWinds.Tools.CommandLineTool.Options
{
    public interface IDatabaseOptions : ICommandLineOptions
    {
        [Option("server", Default = "localhost", HelpText = "Name of database server to which records will be added.")]
        string DbServerName { get; set; }

        [Option("db", Default = "SolarWindsOrion", HelpText = "Name of database to which records will be added.")]
        string DbName { get; set; }

        [Option('u', "username", Default = "SolarWindsOrionDatabaseUser ", HelpText = "Database user name")]
        string DbUserName { get; set; }

        [Option("pass", Default = "123", HelpText = "Database user password")]
        string DbPassword { get; set; }


    }
}
