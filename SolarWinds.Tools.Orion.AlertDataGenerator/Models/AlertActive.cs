using System;

namespace OrionAlertDataGenerator.Models
{
    public class AlertActive
    {
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
