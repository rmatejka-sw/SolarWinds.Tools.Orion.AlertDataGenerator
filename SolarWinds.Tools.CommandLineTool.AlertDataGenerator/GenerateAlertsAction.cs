using System;
using System.Collections.Generic;
using System.Linq;
using CommandLine;
using DapperExtensions;
using SolarWinds.Tools.CommandLineTool.Options;
using SolarWinds.Tools.DataGeneration.DAL.Tables.Orion;
using SolarWinds.Tools.DataGeneration.Helpers;
using SolarWinds.Tools.DataGeneration.Helpers.Extensions;
using SolarWinds.Tools.ModelGenerators.Fakes;
using SolarWinds.Tools.ModelGenerators.Metrics;

namespace SolarWinds.Tools.CommandLineTool.AlertDataGenerator
{
    [Verb("generateAlerts")]
    public class GenerateAlertsAction : IDatabaseOptions, ITimeRangeOptions, IOrionOptions, ICommandLineAction
    {
        private AlertDataGenerator AlertDataGenerator { get; set; }

        [Option("alertsPerHour", Default = 20000, HelpText = "Total number of alerts to generate per hour.")]
        public int AlertsPerHour { get; set; }
        [Option("alertIds", Separator = ',', HelpText = "Comma-delimited list of alert Ids to use. Default is random alerts.")]
        public IEnumerable<int> AlertIds { get; set; }
        public string DbServerName { get; set; }
        public string DbName { get; set; }
        public string DbUserName { get; set; }
        public string DbPassword { get; set; }
        public int PastDays { get; set; }
        public int FutureDays { get; set; }
        public int PollingInterval { get; set; }
        public string OrionServerName { get; set; }
        public bool UseHttps { get; set; }
        public string OrionUserName { get; set; }
        public string OrionPassword { get; set; }

        public int AlertPerInterval => this.AlertsPerHour / 60 / this.PollingInterval;

        public int AlertPerIntervalRandom =>
            FakerHelper.Faker.Random.Int(AlertPerInterval - AlertPerInterval / 2, AlertPerInterval + AlertPerInterval / 2);
        
        public TimeRange GeneratorTimeRange { get; private set; }

        public RunStatus Run(DateTime? timeInterval, TimeRange timeRange = null)
        {
            try
            {
                this.GeneratorTimeRange = timeRange; 
                if (!timeInterval.HasValue) return RunStatus.Success;
                var intervalTime = timeInterval.Value;
                var totalAlerts = this.AlertPerIntervalRandom;
                var alertsRemaining = totalAlerts;
                var alertIdCount = this.AlertIds?.Count();
                var alertConfigurations = DbConnectionManager.DbConnection.GetList<AlertConfigurations>().ToList();
                ConsoleLogger.Info($"Generating {totalAlerts} alerts for interval {intervalTime}");
                while (alertsRemaining > 0)
                {
                    AlertConfigurations alert = null;
                    if (alertIdCount > 0)
                    {
                        var alertId = FakerHelper.Faker.PickRandom(this.AlertIds);
                        alert = alertConfigurations.FirstOrDefault(_ => _.AlertID == alertId);
                    }
                    else
                    {
                        alert = FakerHelper.Faker.PickRandom( alertConfigurations.Where(
                            alert => alert.Enabled && this.AlertDataGenerator.NetObjectTypeInstances.Any(_ => _.Name == alert.ObjectType)));
                    }
                    var netObjectType = this.AlertDataGenerator.NetObjectTypeInstances.FirstOrDefault(ot => ot.Name == alert.ObjectType);
                    if (netObjectType == null) continue;
                    var entityType = netObjectType.EntityType;
                    var entity = this.AlertDataGenerator.ManagedEntityInstances.PickRandom();
                    var alertObjects = AlertObjects.CreateOrUpdate(intervalTime, alert, netObjectType, entity);
                    var alertActive = AlertActive.CreateOrUpdate(intervalTime, (int)alertObjects.AlertObjectID);
                    this.AlertDataGenerator.CreateAlertHistories(intervalTime, alertObjects, alertActive);
                    alertsRemaining -= 1;
                }
                ConsoleLogger.Success($"Generated {totalAlerts} alerts for interval {intervalTime}");
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
            this.AlertDataGenerator = commandLineTool as AlertDataGenerator;
            ;
        }
    }
}
