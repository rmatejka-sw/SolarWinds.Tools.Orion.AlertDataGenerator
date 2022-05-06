﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using CommandLine;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Hosting;
using SolarWinds.Tools.CommandLineTool.Extensions;
using SolarWinds.Tools.CommandLineTool.Options;
using SolarWinds.Tools.DataGeneration.Helpers;
using SolarWinds.Tools.DataGeneration.Services;

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

        public string ContentDirectory { get; set; }
        public bool IsValid { get; set; }
        
        public CommandLineTool()
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
                if (!ValidateArguments(args)) return (int)RunStatus.ParameterValidationFailed;
                this.InitializeServices(args);
                this.Action.BeforeRun(this);
                this.Action.Run();
                int totalIntervals = 0;
                if (this.TimeRangeOptions != null)
                {
                    DateTime startTime = DateTime.MinValue;
                    DateTime endTime = startTime;
                    foreach (var intervalTime in this.TimeRangeOptions.NextInterval())
                    {
                        if (startTime == DateTime.MinValue)
                        {
                            startTime = intervalTime;
                        }
                        this.Action.Run(intervalTime);
                        endTime = intervalTime;
                        totalIntervals++;
                    }
                    ConsoleLogger.Success(new string('=', 100));
                    ConsoleLogger.Success($"COMPLETED {totalIntervals} intervals from {startTime} to {endTime}");
                }
                this.Action.AfterRun();
                return (int)RunStatus.Success;
            }
            catch (Exception e)
            {
                ConsoleLogger.Error(e);
            }

            return (int)RunStatus.CommandError;
        }

        /// <summary>
        /// Called after arguments are validated and before calling BeforeRun.
        /// </summary>
        /// <returns>Returns true if no errors, false otherwise.</returns>
        protected virtual bool InitializeServices(string[] args)
        {
            try
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(ContentDirectory)
                    .AddJsonFile("appsettings.json");
                var host = Host.CreateDefaultBuilder(args)
                    .ConfigureServices(services => services.AddMemoryCache())
                    .Build();
                CacheManager.Initialize(host.Services.GetRequiredService<IMemoryCache>());
                if (this.DatabaseOptions != null)
                {
                    DbConnectionManager.ConnectToDatabase(this.DatabaseOptions.DbServerName, this.DatabaseOptions.DbUserName, this.DatabaseOptions.DbPassword, this.DatabaseOptions.DbName);
                }
                if (this.OrionOptions != null)
                {
                    WebApiManager.InitializeWebApiClients(this.OrionOptions.OrionServerName, this.OrionOptions.OrionUserName, this.OrionOptions.OrionPassword);
                }

                return true;
            }
            catch (Exception e)
            {
                ConsoleLogger.Error(e);
            }

            return false;
        }

        protected Type[] SupportedVerbs => this.Actions.Select(action => action.GetType()).ToArray();

        protected bool ValidateArguments(string[] args)
        {

            try
            {
                var wasParsed = false;
                var nonNullArgs = args ?? new string[] { };
                Parser.Default.ParseArguments(args, this.SupportedVerbs)
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
