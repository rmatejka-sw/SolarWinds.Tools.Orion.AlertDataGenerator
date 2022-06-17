using System;
using Dapper.Contrib.Extensions;
using SolarWinds.Tools.DataGeneration.Helpers.Extensions;
using SolarWinds.Tools.DataGeneration.Helpers.Fakes;

namespace SolarWinds.Tools.DataGeneration.DAL.Tables.Orion
{
    [Table("Volumes")]
    public class Volumes : TableBase<Volumes>
    {

        public Volumes()
        {
        }

        [System.ComponentModel.DataAnnotations.Key]
        public long VolumeID { get; set; }
        public long NodeID { get; set; }
        public DateTime LastSync { get; set; }
        public int VolumeIndex { get; set; }
        public string Caption { get; set; }
        public int? PollInterval { get; set; }
        public int? StatCollection { get; set; }
        public int? RediscoveryInterval { get; set; }
        public string VolumeDescription { get; set; }
        public int? VolumeTypeID { get; set; }
        public string VolumeType { get; set; }
        public string VolumeTypeIcon { get; set; }
        public float VolumePercentUsed { get; set; }
        public double? VolumeSpaceUsed { get; set; }
        public double? VolumeSpaceAvailable { get; set; }
        public double? VolumeSize { get; set; }
        public int? Status { get; set; }
        public string StatusLED { get; set; }
        public string VolumeResponding { get; set; }
        public int? VolumeAllocationFailuresThisHour { get; set; }
        public int? VolumeAllocationFailuresToday { get; set; }
        public DateTime? NextPoll { get; set; }
        public DateTime? NextRediscovery { get; set; }
        public string FullName { get; set; }


        public Volumes Populate(string nodeName, long nodeId, int volumeIndex)
        {
            var f = FakerHelper.Faker;
            var statusInfo = f.Orion().Status();
            var volumeTypeInfo = new VolumeTypeInfo(volumeIndex);
            var volumeUsage = new VolumeMetricData();
            base.Populate();
            this.NodeID = nodeId;
            this.VolumeIndex = volumeIndex;
            this.Caption = $"Volume {volumeIndex}";
            this.PollInterval = 10;
            this.StatCollection = 10;
            this.RediscoveryInterval = 10;
            this.VolumeDescription = FakerHelper.FakeMarker;
            this.VolumeTypeID = volumeTypeInfo.TypeId;
            this.VolumeType = volumeTypeInfo.TypeName;
            this.VolumeTypeIcon = volumeTypeInfo.TypeIcon;
            this.Status = statusInfo.StatusId;
            this.StatusLED = statusInfo.StatusLED;
            this.VolumeResponding = f.Random.Bool(0.9f) ? "Y" : "N";
            this.VolumeAllocationFailuresThisHour = f.Random.Bool(0.9f) ? 0 : f.Random.Int(1, 10);
            this.VolumeAllocationFailuresToday = this.VolumeAllocationFailuresThisHour * f.Random.Int(1, 3);
            this.FullName = $"{nodeName}-{volumeTypeInfo.Caption}";
            this.VolumeSize = volumeUsage.Capacity;
            this.VolumePercentUsed = (float)volumeUsage.PercentUsed;
            this.VolumeSpaceAvailable = volumeUsage.Available;
            this.VolumeSpaceUsed = volumeUsage.Used;
            if (FullName.Length > 255) this.FullName = FullName.Substring(0, 255);
            return this;
        }
    }
}
