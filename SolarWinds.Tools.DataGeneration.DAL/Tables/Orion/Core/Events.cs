using System;
using System.ComponentModel.DataAnnotations.Schema;
using SolarWinds.Tools.DataGeneration.Helpers;

namespace SolarWinds.Tools.DataGeneration.DAL.Tables.Orion.Core
{
    [Table("Events")]
    public class Events : TableBase
    {

        public const short AnomalyDetectedTypeId = 9000;

        public Events()
        {
            var f = FakerHelper.Faker;
            this.EventType = AnomalyDetectedTypeId;
        }

        public int CurrentEntityId { get; set; }

        public int EventID { get; set; }

        public DateTime? EventTime { get; set; }

        public int? NetworkNode { get; set; }

        public int? NetObjectID { get; set; }

        public int? NetObjectID2 { get; set; }

        public string NetObjectValue { get; set; }

        public short? EventType { get; set; }

        public string Message { get; set; }

        public bool Acknowledged { get; set; }

        public int? EngineID { get; set; }

        public string NetObjectType { get; set; }

        public byte[] TimeStamp { get; set; }

    }
}
