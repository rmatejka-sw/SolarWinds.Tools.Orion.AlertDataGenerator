using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using DapperExtensions;
using SolarWinds.Tools.DataGeneration.Helpers;

namespace SolarWinds.Tools.DataGeneration.DAL.Tables.Orion
{
    [Table("AlertActive")]
    public class AlertActive : TableBase
    {
        [Key]
        public long AlertActiveID { get; set; }
        public byte? Acknowledged { get; set; }
        public string AcknowledgedBy { get; set; }
        public DateTime? AcknowledgedDateTime { get; set; }
        public string AcknowledgedNote { get; set; }
        public int AlertObjectID { get; set; }
        public DateTime? TriggeredDateTime { get; set; }
        public string TriggeredMessage { get; set; }
        public long? NumberOfNotes { get; set; }
        public int? LastExecutedEscalationLevel { get; set; }
        public DateTime? LastExecutedEscalationLevelTime { get; set; }


        public static AlertActive CreateOrUpdate(DateTime triggerDate, int alertObjectId)
        {
            AlertActive alertActive =
                AlertActive.GetList<AlertActive>().FirstOrDefault(_ => _.AlertObjectID == alertObjectId);
            if (alertActive == null)
            {
                alertActive = new AlertActive
                {
                    AlertObjectID = alertObjectId,
                    TriggeredDateTime = triggerDate,
                    TriggeredMessage = FakerHelper.FakeMarker,
                };
                var result = DbConnectionManager.DbConnection.Insert<AlertActive>(alertActive);
                alertActive.AlertActiveID = (long)result;
            }

            return alertActive;
        }
    }
}
