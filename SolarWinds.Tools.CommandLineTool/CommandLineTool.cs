using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Reflection;
using CommandLine;
using Dapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Hosting;
using SolarWinds.Tools.CommandLineTool.Extensions;
using SolarWinds.Tools.CommandLineTool.Options;
using SolarWinds.Tools.DataGeneration.Helpers;
using SolarWinds.Tools.DataGeneration.Services;
using SolarWinds.Tools.ModelGenerators.Metrics;

namespace SolarWinds.Tools.CommandLineTool
{
    /// <summary>
    /// Provides common support for command-line application with focus on data-generation for Orion.
    /// </summary>
    public abstract class CommandLineTool
    {
        public abstract IList<ICommandLineAction> Actions { get; }

        protected ICommandLineOptions Options { get; private set; }
        protected IDatabaseOptions DatabaseOptions => this.Options as IDatabaseOptions;
        protected IOrionOptions OrionOptions => this.Options as IOrionOptions;
        protected ITimeRangeOptions TimeRangeOptions => this.Options as ITimeRangeOptions;
        protected ICommandLineAction Action { get; private set; }
        protected TimeRange TimeRange { get; private set; }
        public string ContentDirectory { get; set; }
        public bool IsValid { get; set; }

        /// <summary>
        /// Called before initializing services. Use to configure custom Dapper mappings.
        /// </summary>
        public virtual void PreInitializeServices()
        {
        }

        protected CommandLineTool()
        {
            ContentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        /// <summary>
        /// Validates command line options, connects to SQl Server, and then begins calling GenerateIntervalData
        /// for the total number of times determined from the ITimeRangeOptions.
        /// </summary>
        /// <returns>Status of run</returns>
        protected virtual int Run(string[] args)
        {
            try
            {
                if (!ValidateArguments(args)) return (int) RunStatus.ParameterValidationFailed;
                this.PreInitializeServices();
                if (!this.InitializeServices(args))
                {
                    return (int) RunStatus.ParameterValidationFailed;
                }

                if (this.TimeRangeOptions?.PastDays > 0 || this.TimeRangeOptions?.FutureDays > 0)
                {
                    this.TimeRange = this.TimeRangeOptions.TimeRange();
                }
                this.Action.BeforeRun(this);
                this.Action.Run(null, this.TimeRange);
                int totalIntervals = 0;
                if (this.TimeRange != null)
                {
                    foreach (var intervalTime in this.TimeRange.PollingIntervals())
                    {
                        this.Action.Run(intervalTime, this.TimeRange);
                        totalIntervals++;
                    }
                    ConsoleLogger.Success(new string('=', 100));
                    ConsoleLogger.Success($"Generated {this.TimeRangeOptions.PastDays + this.TimeRangeOptions.FutureDays} days ({totalIntervals} intervals) from {this.TimeRange.StartDate} to {this.TimeRange.EndDate}");
                }

                this.Action.AfterRun();
                return (int) RunStatus.Success;
            }
            catch (Exception e)
            {
                ConsoleLogger.Error(e);
            }

            return (int) RunStatus.CommandError;
        }

        /// <summary>
        /// Called after arguments are validated and before calling BeforeRun.
        /// </summary>
        /// <returns>Returns true if no errors, false otherwise.</returns>
        protected virtual bool InitializeServices(string[] args)
        {
            try
            {
                var host = Host.CreateDefaultBuilder(args)
                    .ConfigureServices(services => services.AddMemoryCache())
                    .Build();
                CacheManager.Initialize(host.Services.GetRequiredService<IMemoryCache>());
                if (this.DatabaseOptions != null)
                {
                    DbConnectionManager.ConnectToDatabase(this.DatabaseOptions.DbServerName,
                        this.DatabaseOptions.DbUserName, this.DatabaseOptions.DbPassword, this.DatabaseOptions.DbName);
                }

                if (this.OrionOptions != null)
                {
                    var initialized = WebApiManager.InitializeWebApiClients(this.OrionOptions.OrionServerName,
                        this.OrionOptions.OrionUserName, this.OrionOptions.OrionPassword, this.OrionOptions.UseHttps);
                    if (!initialized)
                    {
                        ConsoleLogger.Error($"Failed to login to Orion using supplied credentials: {WebApiManager.AuthenticationError}");
                        return false;
                    }
                }

                return true;
            }
            catch (Exception e)
            {
                ConsoleLogger.Error(e);
            }

            return false;
        }

        protected string DefaultVerb =>
            (this.Actions.FirstOrDefault().GetType().GetCustomAttributes(typeof(VerbAttribute))
                .FirstOrDefault() as VerbAttribute).Name;

        protected Type[] SupportedVerbs => this.Actions.Select(action => action.GetType()).ToArray();

        protected bool ValidateArguments(string[] args)
        {

            try
            {
                var wasParsed = false;
                if (this.Actions == null || this.Actions.Count == 0)
                {
                    ConsoleLogger.Error(">>>>>>>> Implementation Error <<<<<<<<<");
                    ConsoleLogger.Error("You must define Actions in your CommandLine class: Actions => new List<ICommandLineAction> { new YourAction() };");
                    return false;
                }
                var nonNullArgs = args?.Length == 0 ? new string[] { this.DefaultVerb } : args;
                Parser.Default.ParseArguments(nonNullArgs, this.SupportedVerbs)
                    .WithParsed(action =>
                    {
                        this.Options = action as ICommandLineOptions;
                        this.Action = action as ICommandLineAction;
                        wasParsed = true;
                    });
                return wasParsed;
            }
            catch (Exception e)
            {
                ConsoleLogger.Error(e);
            }

            return false;
        }

    }
}
