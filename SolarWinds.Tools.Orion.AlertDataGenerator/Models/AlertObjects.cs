using System;
using System.Collections.Generic;
using System.Linq;
using DapperExtensions;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.FSharp.Linq;
using SolarWinds.Tools.CommandLineTool.Helpers;
using SolarWinds.Tools.Orion.AlertDataGenerator;
using SolarWinds.Tools.Orion.AlertDataGenerator.Models;
using PerfStackEntity = SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.Entity;

namespace OrionAlertDataGenerator.Models
{
    public class AlertObjects
    {
        public int AlertObjectID { get; set; }
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
        public long? TriggeredCount { get; set; }
        public DateTime? LastTriggeredDateTime { get; set; }
        public string Context { get; set; }
        public string AlertNote { get; set; }

        public static IList<AlertObjects> Get()
        {
            try
            {
                return CacheManager.Cache.GetOrCreate(typeof(IList<AlertObjects>),ce=>AlertDataGenerator.DbConnection.GetList<AlertObjects>().ToList());
            }
            catch (Exception e)
            {
                ConsoleLogger.Error(e);
            }

            return null;
        }


        public static AlertObjects CreateOrUpdate(DateTime triggerDate, AlertConfigurations alert, PerfStackEntity entity)
        {
            try
            {
                var netObjectId = NetObjectType.GetNetObjectId(entity.InstanceType, new Opid(entity.Id).EntityId);
                if (entity.AncestorDisplayNames.Count > 1)
                {
                    var mapsEntities = AlertDataGenerator.WebApiClients.MapsEntitiesClient
                        .MapsGetAncestorsForEntityAsync(entity.Id).Result;
                }

                AlertObjects alertObjects =
                    Get().FirstOrDefault(_ => _.AlertID == alert.AlertID && _.EntityNetObjectId == netObjectId);
                if (alertObjects == null)
                {
                    alertObjects = new AlertObjects
                    {
                        AlertID = alert.AlertID,
                        AlertNote = FakerHelper.FakerMarker,
                        EntityType = entity.InstanceType,
                        EntityCaption = entity.DisplayName,
                        EntityDetailsUrl = entity.DetailsUrl,
                        EntityNetObjectId = netObjectId,
                        RelatedNodeCaption = "",
                        RelatedNodeUri = "",
                        RelatedNodeId = null,
                        RelatedNodeDetailsUrl = "",
                        RealEntityUri = "",
                        RealEntityType = entity.InstanceType,
                        TriggeredCount = 1
                    };
                    //var result = AlertDataGenerator.DbConnection.Insert<AlertObjects>(alertObjects);
                }
                else
                {
                    alertObjects.LastTriggeredDateTime = triggerDate;
                    alertObjects.TriggeredCount += 1;
                    AlertDataGenerator.DbConnection.Update(alertObjects);
                }
                // Create AlertHistory
                return alertObjects;
            }
            catch (Exception e)
            {
                ConsoleLogger.Error(e);
            }

            return null;
        }
    }
}
