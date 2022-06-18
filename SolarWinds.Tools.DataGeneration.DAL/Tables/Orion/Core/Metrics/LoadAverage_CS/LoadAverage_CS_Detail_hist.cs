using System;

namespace OrionAlertDataGenerator.Models
{
    public class LoadAverage_CS_Detail_hist
    {
        public int NodeID { get; set; }
        public DateTime Timestamp { get; set; }
        public Single? LoadAverage1 { get; set; }
        public Single? LoadAverage5 { get; set; }
        public Single? LoadAverage15 { get; set; }
        public int Weight { get; set; }
    }
}
