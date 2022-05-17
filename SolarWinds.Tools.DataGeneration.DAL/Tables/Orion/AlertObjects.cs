using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using DapperExtensions;
using Microsoft.Extensions.Caching.Memory;
using SolarWinds.Tools.DataGeneration.DAL.SwisEntities;
using SolarWinds.Tools.DataGeneration.Helpers;
using SolarWinds.Tools.DataGeneration.Helpers.Fakes;

namespace SolarWinds.Tools.DataGeneration.DAL.Tables.Orion
{
    [Table("AlertObjects")]
    public class AlertObjects : TableBase<AlertObjects>
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


        public static AlertObjects CreateOrUpdate(DateTime triggerDate, AlertConfigurations alert, NetObjectTypes netObjectType, System_ManagedEntity entity)
        {
            try
            {
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
                        AlertNote = FakerHelper.FakeMarker,
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
                return alertObjects;
            }
            catch (Exception e)
            {
                ConsoleLogger.Error(e);
            }

            return null;
        }


        private static System_ManagedEntity GetRelatedNode(System_ManagedEntity entity)
        {
            var nodeName = entity.AncestorDisplayNames.Last();
            var node = SwisEntity
                        .GetManagedEntityByType("Orion.Nodes", null, nodeName)
                        .FirstOrDefault();
            return node;
        }
    }
}
