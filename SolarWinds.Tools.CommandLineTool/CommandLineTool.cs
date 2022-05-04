using System;
using System.IO;
using System.Reflection;
using CommandLine;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Hosting;
using SolarWinds.Tools.CommandLineTool.Extensions;
using SolarWinds.Tools.CommandLineTool.Options;
using SolarWinds.Tools.DataGeneration.Helpers;

namespace SolarWinds.Tools.CommandLineTool
{
    /// <summary>
    /// Provides common support for command-line application with focus on data-generation for Orion.
     /// </summary>
    /// <typeparam name="TOptions">Option class that implement can implement IDatabaseOptions, ITimeRangeOptions, and IOrionOptions
    ///as required for your application. See AlertDataGeneratorOptions for example usage.
    /// </typeparam>
    public class CommandLineTool<TOptions> where TOptions : IDatabaseOptions, ITimeRangeOptions, IOrionOptions, new()
    {
        public string ContentDirectory { get; set; }
        public bool IsValid { get; set; }
        public TOptions Options { get; set; }
        public CommandLineTool(string[] args)
        {
            ContentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var builder = new ConfigurationBuilder()
                .SetBasePath(ContentDirectory)
                .AddJsonFile("appsettings.json");
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices(services => services.AddMemoryCache())
                .Build();
            CacheManager.Initialize(host.Services.GetRequiredService<IMemoryCache>());
            this.IsValid = ValidateArguments(args);

        }

        /// <summary>
        /// Called once per every interval as defined in ITimeRangeOptions. For example, -pastdays 5 and
        /// -PollingInterval 10 minutes would result in 5*24*60/10= 720 calls to this method with the time
        /// going from Now to 5 days in the past. Client should override to provide their implementation.
        /// </summary>
        /// <param name="intervalTime">DateTime for which data should be generated.</param>
        /// <returns>Integer as defined by the client.</returns>
        protected virtual int GenerateIntervalData(DateTime intervalTime)
        {
            return 0;
        }

        /// <summary>
        /// Validates command line options, connects to SQl Server, and then begins calling GenerateIntervalData
        /// for the total number of times determined from the ITimeRangeOptions.
        /// </summary>
        /// <returns>Status of run</returns>
        protected virtual RunStatus Run()
        {
            if (!this.IsValid) return RunStatus.ParameterValidationFailed;
            DbConnectionManager.ConnectToDatabase(this.Options.DbServerName, this.Options.DbUserName, this.Options.DbPassword, this.Options.DbName);
            try
            {
                var totalAlerts = 0;
                DateTime startTime = DateTime.MinValue;
                DateTime endTime = startTime;
                foreach (var intervalTime in this.Options.NextInterval())
                {
                    if (startTime == DateTime.MinValue)
                    {
                        startTime = intervalTime;
                    }
                    totalAlerts += this.GenerateIntervalData(intervalTime);
                    endTime = intervalTime;
                }
                ConsoleLogger.Success(new string('=',100));
                ConsoleLogger.Success($"Generated {totalAlerts} from {startTime} to {endTime}");
            }
            catch (Exception e)
            {
                ConsoleLogger.Error(e);
            }

            return RunStatus.CommandError;
        }

        protected bool ValidateArguments(string[] args)
        {
            var wasParsed = false;
            var nonNullArgs = args ?? new string[] { };
            Parser.Default.ParseArguments<TOptions>(nonNullArgs)
                .WithParsed<TOptions>(o =>
                {
                    this.Options = o;
                    wasParsed = true;
                });
            return wasParsed;
        }



    }
}
