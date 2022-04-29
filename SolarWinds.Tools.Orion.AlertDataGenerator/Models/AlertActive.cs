using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SolarWinds.Tools.CommandLineTool.SqlEntities;

namespace SolarWinds.Tools.Orion.AlertDataGenerator.Models
{
    [Table("AlertActive")]
    public class AlertActive : SqlEntityBase
    {
        [Key]
        public long AlertActiveID { get; set; }
        public byte? Acknowledged { get; set; }
        public string AcknowledgedBy { get; set; }
        public DateTime? AcknowledgedDateTime { get; set; }
        public string AcknowledgedNote { get; set; }
        public int AlertObjectID { get; set; }
        public DateTime? TriggeredDateTime { get; set; }
        public string TriggeredMessage { get; set; }
        public long? NumberOfNotes { get; set; }
        public int? LastExecutedEscalationLevel { get; set; }
        public DateTime? LastExecutedEscalationLevelTime { get; set; }
    }
}
