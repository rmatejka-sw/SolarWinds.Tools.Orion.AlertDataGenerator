using System;
using SolarWinds.Tools.DataGeneration.DAL.Tables.Orion.Core.Metrics.CPULoad_CS;

namespace OrionAlertDataGenerator.Models
{
    public class CPULoad_CS_Hourly_hist 
    {
        public int NodeID { get; set; }
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
