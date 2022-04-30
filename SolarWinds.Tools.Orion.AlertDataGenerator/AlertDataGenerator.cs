using System;
using System.Collections.Generic;
using System.Linq;
using DapperExtensions;
using SolarWinds.Tools.CommandLineTool;
using SolarWinds.Tools.CommandLineTool.Extensions;
using SolarWinds.Tools.CommandLineTool.Helpers;
using SolarWinds.Tools.CommandLineTool.Service;
using SolarWinds.Tools.CommandLineTool.SwisEntities;
using SolarWinds.Tools.Orion.AlertDataGenerator.Models;


namespace SolarWinds.Tools.Orion.AlertDataGenerator
{
    public class AlertDataGenerator : CommandLineTool<AlertDataGeneratorOptions>
    {

        private IList<System_ManagedEntity> _managedEntityInstances;
        private IList<NetObjectTypes> _netObjectTypeInstances;

        public AlertDataGenerator(string[] args) : base(args)
        {
            WebApiManager.InitializeWebApiClients(this.Options);
            this._managedEntityInstances = SwisEntity.GetInstanceEntities();
            this._netObjectTypeInstances = NetObjectTypes.GetInstances();
        }

        protected override int GenerateIntervalData(DateTime intervalTime)
        {
            try
            {
                var totalAlerts = this.Options.AlertPerIntervalRandom;
                var alertsRemaining = totalAlerts;
                ConsoleLogger.Info($"Generating {totalAlerts} alerts for interval {intervalTime}");
                while (alertsRemaining > 0)
                {
                    var alert = DbConnectionManager.DbConnection.GetRandomRecord<AlertConfigurations>(
                        alert => alert.Enabled && this._netObjectTypeInstances.Any(_=>_.Name == alert.ObjectType));
                    var netObjectType = _netObjectTypeInstances.FirstOrDefault(ot => ot.Name == alert.ObjectType);
                    if (netObjectType == null) continue;
                    var entityType = netObjectType.EntityType;
                    var entity = _managedEntityInstances.PickRandom();
                    var alertObjects = AlertObjects.CreateOrUpdate(intervalTime, alert, netObjectType, entity);
                    var alertActive = AlertActive.CreateOrUpdate(intervalTime, (int)alertObjects.AlertObjectID);
                    CreateAlertHistories(intervalTime, alertObjects, alertActive);
                    alertsRemaining -= 1;
                }
                ConsoleLogger.Success($"Generated {totalAlerts} alerts for interval {intervalTime}");
                return totalAlerts;
            }
            catch (Exception e)
            {
                ConsoleLogger.Error(e);
            }

            return 0;
        }

        private void CreateAlertHistories(DateTime triggerDate, AlertObjects alertObjects, AlertActive alertActive)
        {
            var lastEventType = AlertHistory.GetList<AlertHistory>(
                $"SELECT TOP 1 EventType FROM AlertHistory WHERE AlertObjectID={alertObjects.AlertObjectID} and EventType in (0,1) order by TimeStamp DESC").FirstOrDefault()?.EventType ?? 0;
            var alertHistory = new AlertHistory
            {
                EventType = (short)(lastEventType == 0 ? 1 : 0),
                Message = FakerHelper.FakerMarker,
                TimeStamp = triggerDate,
                AlertActiveID = alertActive.AlertActiveID,
                AlertObjectID = (int)alertObjects.AlertObjectID
            };
            DbConnectionManager.DbConnection.Insert<AlertHistory>(alertHistory);
            if (lastEventType == 0)
            {
                alertHistory.EventType = 0;
                DbConnectionManager.DbConnection.Insert<AlertHistory>(alertHistory);
            }
        }
        private static int Main(string[] args)
        {
            var alertDataGenerator = new AlertDataGenerator(args);
            return (int)alertDataGenerator.Run();
        }


    }
}
