using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolarWinds.Tools.DataGeneration.DAL.Tables.Orion
{
    [Table("AlertHistory")]
    public class AlertHistory : TableBase
    {
        [Key]
        public long AlertHistoryID { get; set; }
        public short EventType { get; set; }
        public string Message { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string AccountID { get; set; }
        public long? AlertActiveID { get; set; }
        public int AlertObjectID { get; set; }
        public int? ActionID { get; set; }
    }
}
