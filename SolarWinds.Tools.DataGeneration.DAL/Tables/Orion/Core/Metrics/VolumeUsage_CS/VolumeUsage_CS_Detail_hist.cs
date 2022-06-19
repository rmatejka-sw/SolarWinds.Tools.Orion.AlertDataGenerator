using System;
using Dapper.Contrib.Extensions;

namespace OrionAlertDataGenerator.Models.VolumeUsage_CS
{
    [Table("VolumeUsage_CS_Detail_hist")]
    public class VolumeUsage_CS_Detail_hist
    {
        [ExplicitKey]
        public long VolumeID { get; set; }
        public long? NodeID { get; set; }
        [ExplicitKey]
        public DateTime Timestamp { get; set; }
        public double? DiskSize { get; set; }
        public double? DiskUsed { get; set; }
        public Single? PercentDiskUsed { get; set; }
        public long? AllocationFailures { get; set; }
        public int Weight { get; set; }
    }
}
