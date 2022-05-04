using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SolarWinds.Tools.DataGeneration.DAL.Tables.Orion
{
     public class Volumes : TableBase
    {
        private readonly IQueryable<NodesData> allNodes;
        private static readonly Dictionary<int, int> volumeCountByNodeId = new Dictionary<int, int>();

        public Volumes()
        {
        }
        public int CurrentEntityId { get; set; }


        [Key]
        public int VolumeID { get; set; }

        // [EnumeratedSourceValue(SourceType = typeof(NodesData), SourcePropertyName = nameof(NodesData.NodeID))]
        public int NodeID { get; set; }

        // [FakeDateTimeData(Const = "NOW")]
        public DateTime LastSync { get; set; }

        // [FakeIntegerData(Min = 1, Max = 3, Distribution = FakeDataDistribustionType.Increasing)]
        public int VolumeIndex { get; set; }

        public string Caption { get; set; }

        // [FakeIntegerData(Const = 10)]
        public int? PollInterval { get; set; }

        // [FakeIntegerData(Const = 10)]
        public int? StatCollection { get; set; }

        // [FakeIntegerData(Const = 10)]
        public int? RediscoveryInterval { get; set; }

        // [FakeStringData(Const = NetworkGenerator.FakeMarker)]
        public string VolumeDescription { get; set; }

        // [FakeIntegerData(Const = 4)]
        public int? VolumeTypeID { get; set; }

        // [FakeStringData(Const = @"Fixed Disk")]
        public string VolumeType { get; set; }

        // [FakeStringData(Const = @"FixedDisk.gif")]
        public string VolumeTypeIcon { get; set; }

        // [FakeFloatingPointData(Const = 51.0)]
        public float VolumePercentUsed { get; set; }

        // [FakeFloatingPointData(Const = 119551217664)]
        public double? VolumeSpaceUsed { get; set; }

        // [FakeFloatingPointData(Const = 130439684096)]
        public double? VolumeSpaceAvailable { get; set; }

        // [FakeFloatingPointData(Const = 249990901760)]
        public double? VolumeSize { get; set; }

        // [FakeDataFromValues(FromArray = new object[] { 1, 1, 1, 2, 0 })]
        public int? Status { get; set; }

        public string StatusLED { get; set; }

        // [FakeDataFromValues(FromValues = "Y|N")]
        public string VolumeResponding { get; set; }

        // [FakeIntegerData(Const = 0)]
        public int? VolumeAllocationFailuresThisHour { get; set; }

        // [FakeIntegerData(Const = 0)]
        public int? VolumeAllocationFailuresToday { get; set; }

        // [FakeDateTimeData(Const = "NOW")]
        public DateTime? NextPoll { get; set; }

        // [FakeDateTimeData(Const = "NOW")]
        public DateTime? NextRediscovery { get; set; }

        public string FullName { get; set; }

        [NotMapped]
        public string NodeCaption { get; set; }
        
        [NotMapped]
        public double MaxDiskUsed { get; set; }

        [NotMapped]
        public double MinDiskUsed { get; set; }

      }
}
