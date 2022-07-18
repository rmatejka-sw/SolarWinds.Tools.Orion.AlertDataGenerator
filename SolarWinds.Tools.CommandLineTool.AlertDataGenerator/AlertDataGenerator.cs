using System;
using System.Collections.Generic;
using System.Linq;
using DapperExtensions;
using SolarWinds.Tools.DataGeneration.DAL.SwisEntities;
using SolarWinds.Tools.DataGeneration.DAL.Tables.Orion;
using SolarWinds.Tools.DataGeneration.Helpers;
using SolarWinds.Tools.ModelGenerators.Fakes;


namespace SolarWinds.Tools.CommandLineTool.AlertDataGenerator
{
    public class AlertDataGenerator : CommandLineTool
    {
        private IList<System_ManagedEntity> managedEntityInstances;
        private IList<NetObjectTypes> netObjectTypeInstances;

        private static int Main(string[] args)
        {
            return (int)new AlertDataGenerator().Run(args);
        }

        public override IList<ICommandLineAction> Actions => new List<ICommandLineAction>
        {
            new GenerateAlertsAction()
        };

        public AlertDataGenerator() 
        {
        }

        public IList<System_ManagedEntity> ManagedEntityInstances =>
            managedEntityInstances ??= SwisEntity.GetInstanceEntities();
        public IList<NetObjectTypes> NetObjectTypeInstances => netObjectTypeInstances ??= NetObjectTypes.GetInstances();


        public void CreateAlertHistories(DateTime triggerDate, AlertObjects alertObjects, AlertActive alertActive)
        {
            var lastEventType = AlertHistory.GetList(
                $"SELECT TOP 1 EventType FROM AlertHistory WHERE AlertObjectID={alertObjects.AlertObjectID} and EventType in (0,1) order by TimeStamp DESC").FirstOrDefault()?.EventType ?? 0;
            var alertHistory = new AlertHistory
            {
                EventType = (short)(lastEventType == 0 ? 1 : 0),
                Message = FakerHelper.FakeMarker,
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

 

    }
}
