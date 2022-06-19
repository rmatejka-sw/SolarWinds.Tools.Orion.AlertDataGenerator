using System;
using Dapper.Contrib.Extensions;
using OrionAlertDataGenerator.Models;
using SolarWinds.Tools.DataGeneration.Helpers;
using SolarWinds.Tools.DataGeneration.Helpers.Models;
using SolarWinds.Tools.ModelGenerators.InternetGenerator;

namespace SolarWinds.Tools.DataGeneration.DAL.Tables.Orion.Core.Metrics.ResponseTime_CS
{
    public class ResponseTime_CS : MetricTableBase
    {
        public static void Populate(DateTime interval, TimeRange timeRange, Device device)
        {
            var cur = new ResponseTime_CS_cur();
            var detail = new ResponseTime_CS_Detail_hist();
            device.Availability.MetricData.RestoreTo(interval, timeRange);
            device.ResponseTime.MetricData.RestoreTo(interval, timeRange);
            detail.NodeID = cur.NodeID = (long)device.OrionNodeID;
            detail.Timestamp = cur.Timestamp = interval;
            detail.Availability = cur.Availability = (float)device.Availability.Current;
            detail.ResponseTime = cur.ResponseTime = (short) device.ResponseTime.Current;
            detail.Weight = cur.Weight = (int)WeightType.Detail;
            DbConnectionManager.DbConnection.Insert<ResponseTime_CS_cur>(cur);
            DbConnectionManager.DbConnection.Insert<ResponseTime_CS_Detail_hist>(detail);
            device.Availability.MetricData.RestoreToLatest();
            device.ResponseTime.MetricData.RestoreToLatest();
        }
    }
}
