using System;
using Dapper.Contrib.Extensions;
using SolarWinds.Tools.DataGeneration.Helpers.Extensions;
using SolarWinds.Tools.ModelGenerators.Extensions;
using SolarWinds.Tools.ModelGenerators.Fakes;
using SolarWinds.Tools.ModelGenerators.InternetGenerator;
using SolarWinds.Tools.ModelGenerators.Metrics;

namespace SolarWinds.Tools.DataGeneration.DAL.Tables.Orion
{
    [Table("Volumes")]
    public class Volumes : TableBase<Volumes>
    {

        public Volumes()
        {
        }

        [ExplicitKey]
        public long VolumeID { get; set; }
        [ExplicitKey]
        public long NodeID { get; set; }
        public DateTime? LastSync { get; set; }
        public bool? UnManaged { get; set; }
        public DateTime? UnManageFrom { get; set; }
        public DateTime? UnManageUntil { get; set; }
        public int? VolumeIndex { get; set; }
        public string Caption { get; set; }
        public int? PollInterval { get; set; }
        public int? StatCollection { get; set; }
        public int? RediscoveryInterval { get; set; }
        public string VolumeDescription { get; set; }
        public int? VolumeTypeID { get; set; }
        public string VolumeType { get; set; }
        public string VolumeTypeIcon { get; set; }
        public Single? VolumePercentUsed { get; set; }
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
        public double? DiskQueueLength { get; set; }
        public double? DiskTransfer { get; set; }
        public double? DiskReads { get; set; }
        public double? DiskWrites { get; set; }
        public double? TotalDiskIOPS { get; set; }
        public string DeviceId { get; set; }
        public string DiskSerialNumber { get; set; }
        public string InterfaceType { get; set; }
        public int? SCSITargetId { get; set; }
        public int? SCSILunId { get; set; }
        public int? SCSIPortId { get; set; }
        public string SCSIControllerId { get; set; }
        public int? SCSIPortOffset { get; set; }

        public Volumes Populate(Device device, DeviceVolume deviceVolume)
        {
            var f = FakerHelper.Faker;
            var statusInfo = f.Orion().Status();
            base.Populate();
            this.NodeID = device.OrionNodeID;
            this.VolumeIndex = deviceVolume.VolumeIndex;
            this.Caption = $"Volume {deviceVolume.VolumeIndex}";
            this.PollInterval = 2*60;
            this.StatCollection = 15;
            this.RediscoveryInterval = 30;
            this.VolumeDescription = deviceVolume.VolumeType.Caption;
            this.VolumeTypeID = deviceVolume.VolumeType.TypeId; 
            this.VolumeType = deviceVolume.VolumeType.TypeName;
            this.VolumeTypeIcon = deviceVolume.VolumeType.TypeIcon;
            this.VolumeSize = deviceVolume.VolumeUsage.MetricData.Capacity;
            this.DiskSerialNumber = FakerHelper.FakeMarker;
            this.Status = statusInfo.StatusId;
            this.StatusLED = statusInfo.StatusLED;
            this.InterfaceType = null;
            this.UnManageFrom = null;
            this.UnManageUntil = null;
            this.UnManaged = false;
            this.NextPoll = DateTime.UtcNow.AddDays(7);
            this.LastSync = DateTime.UtcNow;
            this.NextRediscovery = DateTime.UtcNow.AddDays(7);
            this.VolumeResponding = f.Random.Bool(0.9f) ? "Y" : "N";
            this.VolumeAllocationFailuresThisHour = f.Random.Bool(0.9f) ? 0 : f.Random.Int(1, 10);
            this.VolumeAllocationFailuresToday = this.VolumeAllocationFailuresThisHour * f.Random.Int(1, 3);
            this.FullName = $"{device.NodeName}-{deviceVolume.VolumeType.Caption}";
            this.VolumeSize = deviceVolume.VolumeUsage.MetricData.Capacity;
            this.VolumePercentUsed = (float)deviceVolume.VolumeUsage.MetricData.PercentUsed;
            this.VolumeSpaceAvailable = deviceVolume.VolumeUsage.MetricData.Available;
            this.VolumeSpaceUsed = deviceVolume.VolumeUsage.MetricData.Used;
            this.DeviceId = deviceVolume.VolumeType.DeviceId;
            // TODO - Add Metrics
            this.DiskQueueLength = f.Random.Double(0, 5);
            this.DiskReads =  f.Random.Double(0, 1); // OperationsPerSecond
            this.DiskWrites = f.Random.Double(0, 1); // OperationsPerSecond
            this.DiskTransfer = f.Random.Double(0, 1); // OperationsPerSecond
            this.TotalDiskIOPS = f.Random.Double(0, 4); // OperationsPerSecond
            if (FullName.Length > 255) this.FullName = FullName.Substring(0, 255);
            return this;
        }
    }
}
