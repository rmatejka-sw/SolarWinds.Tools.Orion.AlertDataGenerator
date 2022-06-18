using System;

namespace OrionAlertDataGenerator.Models
{
    public class ResponseTime_CS_Daily_hist
    {
        public int NodeID { get; set; }
        public DateTime Timestamp { get; set; }
        public short? MinResponseTime { get; set; }
        public short? MaxResponseTime { get; set; }
        public short? AvgResponseTime { get; set; }
        public short? PercentLoss { get; set; }
        public Single? Availability { get; set; }
        public int Weight { get; set; }
    }
}
