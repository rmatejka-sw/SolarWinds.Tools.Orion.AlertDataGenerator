using System;

namespace OrionAlertDataGenerator.Models
{
    public class AlertHistory
    {
        public int AlertHistoryID { get; set; }
        public short EventType { get; set; }
        public string Message { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string AccountID { get; set; }
        public long? AlertActiveID { get; set; }
        public int AlertObjectID { get; set; }
        public int? ActionID { get; set; }
    }
}
