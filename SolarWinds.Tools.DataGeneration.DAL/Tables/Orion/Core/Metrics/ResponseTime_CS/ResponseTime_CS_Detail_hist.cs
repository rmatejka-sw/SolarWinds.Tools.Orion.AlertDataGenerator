using System;
using Dapper.Contrib.Extensions;

namespace OrionAlertDataGenerator.Models
{
    [Table("ResponseTime_CS_Detail_hist")]
    public class ResponseTime_CS_Detail_hist
    {
        [ExplicitKey]
        public long NodeID { get; set; }
        public DateTime Timestamp { get; set; }
        public short? ResponseTime { get; set; }
        public short? PercentLoss { get; set; }
        public Single? Availability { get; set; }
        public int Weight { get; set; }
    }
}
