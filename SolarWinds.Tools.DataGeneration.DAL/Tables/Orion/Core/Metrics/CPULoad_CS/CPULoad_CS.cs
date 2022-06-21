using System;
using System.Linq;
using Dapper.Contrib.Extensions;
using OrionAlertDataGenerator.Models;
using SolarWinds.Tools.DataGeneration.Helpers;
using SolarWinds.Tools.ModelGenerators.InternetGenerator;
using SolarWinds.Tools.ModelGenerators.Metrics;

namespace SolarWinds.Tools.DataGeneration.DAL.Tables.Orion.Core.Metrics.CPULoad_CS
{
    public class CPULoad_CS : MetricTableBase
    {
        public static void Populate(DateTime interval, TimeRange timeRange, Device device)
        {
            var cur = new CPULoad_CS_cur();
            var detail = new CPULoad_CS_Detail_hist();
            var memoryDevice = device.MemoryDevices.FirstOrDefault();
            memoryDevice.MetricData.RestoreTo(interval, timeRange);
            device.Load.MetricData.RestoreTo(interval, timeRange);
            detail.NodeID = cur.NodeID = (long)device.OrionNodeID;
            detail.Timestamp = cur.Timestamp = interval.ToLocalTime();
            detail.Load = cur.Load = (short)device.Load.Current;
            detail.TotalMemory = cur.TotalMemory = (long)memoryDevice.MetricData.Capacity;
            detail.MemoryUsed = cur.MemoryUsed = memoryDevice.MetricData.Used;
            detail.PercentMemoryUsed = cur.PercentMemoryUsed = (float)memoryDevice.MetricData.PercentUsed;
            detail.Weight = cur.Weight = (int)WeightType.Detail;
            DbConnectionManager.DbConnection.Insert<CPULoad_CS_cur>(cur);
            DbConnectionManager.DbConnection.Insert<CPULoad_CS_Detail_hist>(detail);
            memoryDevice.MetricData.RestoreToLatest();
            device.Load.MetricData.RestoreToLatest();
        }
    }
}
