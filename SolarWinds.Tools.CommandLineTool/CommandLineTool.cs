﻿using System;
using System.IO;
using System.Reflection;
using System.Security.Authentication.ExtendedProtection;
using Bogus;
using CommandLine;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Hosting;
using SolarWinds.Tools.CommandLineTool.Extensions;
using SolarWinds.Tools.CommandLineTool.Helpers;
using SolarWinds.Tools.CommandLineTool.Options;
using SolarWinds.Tools.CommandLineTool.Service;
using SolarWinds.Tools.CommandLineTool.SwisEntities;

namespace SolarWinds.Tools.CommandLineTool
{
    public class CommandLineTool<TOptions> where TOptions : IDatabaseOptions, ITimeRangeOptions, new()
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
            CacheManager.Cache =
                host.Services.GetRequiredService<IMemoryCache>(); 
            this.IsValid = ValidateArguments(args);

        }

        protected virtual int GenerateIntervalData(DateTime intervalTime)
        {
            return 0;
        }

        protected virtual RunStatus Run()
        {
            if (!this.IsValid) return RunStatus.ParameterValidationFailed;
            DbConnectionManager.ConnectToDatabase(this.Options);
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
