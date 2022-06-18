using System;

namespace OrionAlertDataGenerator.Models
{
    public class ResponseTime_CS_cur
    {
        public int NodeID { get; set; }
        public DateTime Timestamp { get; set; }
        public short? ResponseTime { get; set; }
        public short? PercentLoss { get; set; }
        public Single? Availability { get; set; }
        public int Weight { get; set; }
    }
}
