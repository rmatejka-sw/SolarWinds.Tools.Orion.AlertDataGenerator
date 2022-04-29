using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using DapperExtensions;
using Microsoft.Extensions.Caching.Memory;
using SolarWinds.Tools.CommandLineTool.Helpers;
using SolarWinds.Tools.CommandLineTool.SqlEntities;
using SolarWinds.Tools.CommandLineTool.SwisEntities;

namespace SolarWinds.Tools.Orion.AlertDataGenerator.Models
{
    [Table("AlertObjects")]
    public class AlertObjects : SqlEntityBase
    {
        [Key]
        public long AlertObjectID { get; set; }
        public int AlertID { get; set; }
        public string EntityUri { get; set; }
        public string EntityType { get; set; }
        public string EntityCaption { get; set; }
        public string EntityDetailsUrl { get; set; }
        public string EntityNetObjectId { get; set; }
        public string RelatedNodeCaption { get; set; }
        public string RelatedNodeUri { get; set; }
        public int? RelatedNodeId { get; set; }
        public string RelatedNodeDetailsUrl { get; set; }
        public string RealEntityUri { get; set; }
        public string RealEntityType { get; set; }
        public long TriggeredCount { get; set; }
        public DateTime? LastTriggeredDateTime { get; set; }
        public string Context { get; set; }
        public string AlertNote { get; set; }

        public static IList<AlertObjects> GetList()
        {
            try
            {
                return CacheManager.Cache.GetOrCreate(typeof(IList<AlertObjects>), ce => DbConnectionManager.DbConnection.GetList<AlertObjects>().ToList());
            }
            catch (Exception e)
            {
                ConsoleLogger.Error(e);
            }

            return null;
        }


        public static AlertObjects CreateOrUpdate(DateTime triggerDate, AlertConfigurations alert, System_ManagedEntity entity)
        {
            try
            {
                var netObjectType = NetObjectTypes.Get(AlertDataGenerator.WebApiClients.SwisClient, entity.InstanceType);
                var entityId = entity.GetEntityId();
                var netObjectId = netObjectType.GetNetObjectId(entityId);
                AlertObjects alertObjects =
                    AlertObjects.GetList().FirstOrDefault(_ => _.AlertID == alert.AlertID && _.EntityNetObjectId == netObjectId);
                if (alertObjects == null)
                {
                    var relatedNode = GetRelatedNode(entity);
                    alertObjects = new AlertObjects
                    {
                        AlertID = alert.AlertID,
                        AlertNote = FakerHelper.FakerMarker,
                        EntityType = entity.InstanceType,
                        EntityCaption = entity.DisplayName,
                        EntityDetailsUrl = entity.DetailsUrl,
                        EntityNetObjectId = netObjectId,
                        RelatedNodeCaption = relatedNode?.DisplayName,
                        RelatedNodeUri = relatedNode?.Uri,
                        RelatedNodeId = relatedNode?.GetEntityId(),
                        RelatedNodeDetailsUrl = relatedNode?.DetailsUrl,
                        RealEntityUri = relatedNode?.Uri,
                        RealEntityType = entity.InstanceType,
                        TriggeredCount = 1
                    };
                    var result = DbConnectionManager.DbConnection.Insert<AlertObjects>(alertObjects);
                    alertObjects.AlertObjectID = (long)result;
                }
                else
                {
                    alertObjects.LastTriggeredDateTime = triggerDate;
                    alertObjects.TriggeredCount += 1;
                    DbConnectionManager.DbConnection.Update(alertObjects);
                }
                AlertActive alertActive =
                    AlertActive.GetList<AlertActive>().FirstOrDefault(_ => _.AlertObjectID == alertObjects.AlertObjectID);
                if (alertActive == null)
                {
                    alertActive = new AlertActive
                    {
                        AlertObjectID = (int)alertObjects.AlertObjectID,
                        TriggeredDateTime = triggerDate,
                        TriggeredMessage = FakerHelper.FakerMarker,
                    };
                    var result = DbConnectionManager.DbConnection.Insert<AlertActive>(alertActive);
                    alertActive.AlertActiveID = (long)result;
                }
                CreateAlertHistories(triggerDate, alertObjects, alertActive);
                return alertObjects;
            }
            catch (Exception e)
            {
                ConsoleLogger.Error(e);
            }

            return null;
        }

        private static void CreateAlertHistories(DateTime triggerDate, AlertObjects alertObjects, AlertActive alertActive)
        {
            var lastEventType = AlertHistory.GetList<AlertHistory>(
                $"SELECT TOP 1 EventType FROM AlertHistory WHERE AlertObjectID={alertObjects.AlertObjectID} and EventType in (0,1) order by TimeStamp DESC").FirstOrDefault()?.EventType??0;
            var alertHistory = new AlertHistory
            {
                EventType = (short) (lastEventType == 0 ? 1 : 0),
                Message = FakerHelper.FakerMarker,
                TimeStamp = triggerDate,
                AlertActiveID = alertActive.AlertActiveID,
                AlertObjectID = (int) alertObjects.AlertObjectID
            };
            DbConnectionManager.DbConnection.Insert<AlertHistory>(alertHistory);
            if (lastEventType == 0)
            {
                alertHistory.EventType = 0;
                DbConnectionManager.DbConnection.Insert<AlertHistory>(alertHistory);
            }
        }

        private static System_ManagedEntity GetRelatedNode(System_ManagedEntity entity)
        {
            var nodeName = entity.AncestorDisplayNames.Last();
            var node = SwisEntity
                        .GetManagedEntity(AlertDataGenerator.WebApiClients.SwisClient, "Orion.Nodes", null, nodeName)
                        .FirstOrDefault();
            return node;
        }
    }
}
