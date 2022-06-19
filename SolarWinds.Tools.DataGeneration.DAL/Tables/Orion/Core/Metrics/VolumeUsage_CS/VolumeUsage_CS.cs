using System;
using Dapper.Contrib.Extensions;
using OrionAlertDataGenerator.Models.VolumeUsage_CS;
using SolarWinds.Tools.DataGeneration.Helpers;
using SolarWinds.Tools.DataGeneration.Helpers.Models;
using SolarWinds.Tools.ModelGenerators.InternetGenerator;

namespace SolarWinds.Tools.DataGeneration.DAL.Tables.Orion.Core.Metrics.ResponseTime_CS
{
    public class VolumeUsage_CS : MetricTableBase
    {
        public static void Populate(DateTime interval, TimeRange timeRange, Device device, DeviceVolume deviceVolume)
        {
            var cur = new VolumeUsage_CS_cur();
            var detail = new VolumeUsage_CS_Detail_hist();
            deviceVolume.VolumeUsage.MetricData.RestoreTo(interval, timeRange);
            device.ResponseTime.MetricData.RestoreTo(interval, timeRange);
            detail.NodeID = cur.NodeID = (long)device.OrionNodeID;
            detail.VolumeID = cur.VolumeID = deviceVolume.OrionVolumeId;
            detail.Timestamp = cur.Timestamp = interval;
            detail.Weight = cur.Weight = (int)WeightType.Detail;
            detail.AllocationFailures = 0;
            detail.DiskSize = deviceVolume.VolumeUsage.MetricData.Capacity;
            detail.DiskUsed = deviceVolume.VolumeUsage.MetricData.Used;
            detail.PercentDiskUsed = (float)deviceVolume.VolumeUsage.MetricData.PercentUsed;
            DbConnectionManager.DbConnection.Insert<VolumeUsage_CS_cur>(cur);
            DbConnectionManager.DbConnection.Insert<VolumeUsage_CS_Detail_hist>(detail);
            deviceVolume.VolumeUsage.MetricData.RestoreToLatest();
        }
    }
}
