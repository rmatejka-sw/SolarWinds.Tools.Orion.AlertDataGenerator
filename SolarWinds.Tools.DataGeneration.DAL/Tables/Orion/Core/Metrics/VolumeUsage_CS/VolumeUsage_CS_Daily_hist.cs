using System;

namespace OrionAlertDataGenerator.Models.VolumeUsage_CS
{
    public class VolumeUsage_CS_Daily_hist
    {
        public int VolumeID { get; set; }
        public DateTime Timestamp { get; set; }
        public int? NodeID { get; set; }
        public double? DiskSize { get; set; }
        public double? MinDiskUsed { get; set; }
        public double? MaxDiskUsed { get; set; }
        public double? AvgDiskUsed { get; set; }
        public Single? PercentDiskUsed { get; set; }
        public long? AllocationFailures { get; set; }
        public int Weight { get; set; }
    }
}
