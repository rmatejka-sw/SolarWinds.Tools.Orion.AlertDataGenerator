using System;

namespace OrionAlertDataGenerator.Models
{
    public class LoadAverage_CS_Hourly_hist
    {
        public int NodeID { get; set; }
        public DateTime Timestamp { get; set; }
        public Single? MinLoadAverage1 { get; set; }
        public Single? MaxLoadAverage1 { get; set; }
        public Single? AvgLoadAverage1 { get; set; }
        public Single? MinLoadAverage5 { get; set; }
        public Single? MaxLoadAverage5 { get; set; }
        public Single? AvgLoadAverage5 { get; set; }
        public Single? MinLoadAverage15 { get; set; }
        public Single? MaxLoadAverage15 { get; set; }
        public Single? AvgLoadAverage15 { get; set; }
        public int Weight { get; set; }
    }
}
