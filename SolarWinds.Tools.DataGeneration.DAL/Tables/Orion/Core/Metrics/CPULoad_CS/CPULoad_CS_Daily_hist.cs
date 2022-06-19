using System;
using Dapper.Contrib.Extensions;

namespace OrionAlertDataGenerator.Models
{
    public class CPULoad_CS_Daily_hist 
    {
        [Key]
        public long NodeID { get; set; }
        public DateTime Timestamp { get; set; }
        public short? MinLoad { get; set; }
        public short? MaxLoad { get; set; }
        public short? AvgLoad { get; set; }
        public long? TotalMemory { get; set; }
        public double? MinMemoryUsed { get; set; }
        public double? MaxMemoryUsed { get; set; }
        public double? AvgMemoryUsed { get; set; }
        public Single? PercentMemoryUsed { get; set; }
        public int Weight { get; set; }
    }
}
