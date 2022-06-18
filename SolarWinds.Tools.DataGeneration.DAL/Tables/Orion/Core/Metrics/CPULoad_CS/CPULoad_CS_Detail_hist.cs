using System;

namespace OrionAlertDataGenerator.Models
{
    public class CPULoad_CS_Detail_hist
    {
        public int NodeID { get; set; }
        public DateTime Timestamp { get; set; }
        public short? Load { get; set; }
        public long? TotalMemory { get; set; }
        public double? MemoryUsed { get; set; }
        public Single? PercentMemoryUsed { get; set; }
        public int Weight { get; set; }
    }
}
