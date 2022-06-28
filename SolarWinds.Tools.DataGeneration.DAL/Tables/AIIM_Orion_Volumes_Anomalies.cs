using System;
using System.ComponentModel.DataAnnotations.Schema;
using SolarWinds.Tools.DataGeneration.DAL.SwisEntities;
using SolarWinds.Tools.ModelGenerators.Fakes;
using SolarWinds.Tools.ModelGenerators.InternetGenerator;
using SolarWinds.Tools.ModelGenerators.Metrics;

namespace SolarWinds.Tools.DataGeneration.DAL.Tables
{
    /// <summary>
    /// Currently not used as these would have to be updated in Real-Time
    /// </summary>
    [Table("AIIM_Orion_Volumes_Anomalies")]
    public class AIIM_Orion_Volumes_Anomalies : TableBase<AIIM_Orion_Volumes_Anomalies>
    {
        public string SourceUri { get; set; }
        public string Orion_VolumeUsageHistory_PercentDiskUsedDisplayName { get; set; }
        public bool? Orion_VolumeUsageHistory_PercentDiskUsedIsAnomalous { get; set; }
        public string Orion_VolumeUsageHistory_PercentDiskUsedUnits { get; set; }
        public double? Orion_VolumeUsageHistory_PercentDiskUsedValue { get; set; }

        public AIIM_Orion_Volumes_Anomalies Populate(DateTime interval, Device device, System_ManagedEntity entityInstance, string metricID, MetricDataObservation observation, double metricValue)
        {
            var f = FakerHelper.Faker;
            this.SourceUri = entityInstance.Uri;
            return this;
        }
    }
}
