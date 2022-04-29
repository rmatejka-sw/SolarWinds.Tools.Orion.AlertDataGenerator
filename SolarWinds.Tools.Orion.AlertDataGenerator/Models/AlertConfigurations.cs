using System;
using System.Linq;
using Microsoft.Extensions.Caching.Memory;
using SolarWinds.Tools.CommandLineTool.Extensions;
using SolarWinds.Tools.CommandLineTool.Helpers;
using SolarWinds.Tools.Orion.AlertDataGenerator;
using SolarWinds.Tools.Orion.AlertDataGenerator.Models;
using PerfStackEntity =  SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.Entity;
using System.Collections.Generic;

namespace OrionAlertDataGenerator.Models
{
    public class AlertConfigurations
    {
        
        public int AlertID { get; set; }
        public string AlertMessage { get; set; }
        public Guid AlertRefID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Enabled { get; set; }
        public string ObjectType { get; set; }
        public long Frequency { get; set; }
        public DateTime BlockUntil { get; set; }
        public string Trigger { get; set; }
        public string Reset { get; set; }
        public int Severity { get; set; }
        public bool NotifyEnabled { get; set; }
        public string NotificationSettings { get; set; }
        public DateTime LastEdit { get; set; }
        public string CreatedBy { get; set; }
        public string Category { get; set; }
        public bool Canned { get; set; }
        public bool Hidden { get; set; }
        public string LicenseFeatureName { get; set; }

        public static bool GenerateAlert(DateTime intervalDateTime)
        {
            try
            {
                var objectTypes = AlertObjectType.Get();
                var alert = AlertDataGenerator.DbConnection.GetRandomRecord<AlertConfigurations>(
                    alert=>alert.Enabled && objectTypes.Any( ot=> ot.ObjectType == alert.ObjectType));
                var entityType = objectTypes.FirstOrDefault(ot => ot.ObjectType == alert.ObjectType)?.EntityType ?? null;
                if (entityType == null) return false;
                var entity = CacheManager.Cache.GetOrCreate<IList<PerfStackEntity>>(entityType,
                    cacheEntry => AlertDataGenerator.WebApiClients.PerfStackEntitiesClient
                        .GetManagedEntitiesAsync(entityType, 100).Result.Data
                        .ToList<PerfStackEntity>()).PickRandom();
                var alertObject = AlertObjects.CreateOrUpdate(intervalDateTime, alert, entity);
                // Create AlertObject
                // Create AlertHistory
                return true;
            }
            catch (Exception e)
            {
                ConsoleLogger.Error(e);;
            }

            return false;
        }
    }
}
