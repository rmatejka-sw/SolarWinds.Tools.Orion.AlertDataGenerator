using System;
using System.Linq;
using SolarWinds.Tools.CommandLineTool.Extensions;
using SolarWinds.Tools.CommandLineTool.Helpers;
using SolarWinds.Tools.CommandLineTool.SqlEntities;
using SolarWinds.Tools.CommandLineTool.SwisEntities;

namespace SolarWinds.Tools.Orion.AlertDataGenerator.Models
{
    public class AlertConfigurations : SqlEntityBase
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

     }
}
