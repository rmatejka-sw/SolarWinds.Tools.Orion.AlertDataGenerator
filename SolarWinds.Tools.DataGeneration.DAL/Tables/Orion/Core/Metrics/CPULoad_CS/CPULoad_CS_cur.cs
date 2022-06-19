using System;
using Dapper.Contrib.Extensions;
using SolarWinds.Tools.DataGeneration.DAL.Tables.Orion.Core.Metrics.CPULoad_CS;

namespace OrionAlertDataGenerator.Models
{
    [Table("CPULoad_CS_cur")]
    public class CPULoad_CS_cur 
    {
        [ExplicitKey]
        public long NodeID { get; set; }
        public DateTime Timestamp { get; set; }
        public short? Load { get; set; }
        public long? TotalMemory { get; set; }
        public double? MemoryUsed { get; set; }
        public Single? PercentMemoryUsed { get; set; }
        public int Weight { get; set; }
    }
}
