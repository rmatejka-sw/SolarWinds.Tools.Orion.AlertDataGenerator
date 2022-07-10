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
        
        [Column("Orion_VolumeUsageHistory_PercentDiskUsedDisplayName")]
        public string OrionVolumeUsageHistoryPercentDiskUsedDisplayName { get; set; }

        [Column("Orion_VolumeUsageHistory_PercentDiskUsedIsAnomalous")]
        public bool? OrionVolumeUsageHistoryPercentDiskUsedIsAnomalous { get; set; }

        [Column("Orion_VolumeUsageHistory_PercentDiskUsedUnits")]
        public string OrionVolumeUsageHistoryPercentDiskUsedUnits { get; set; }
        
        [Column("Orion_VolumeUsageHistory_PercentDiskUsedValue")]
        public double? OrionVolumeUsageHistoryPercentDiskUsedValue { get; set; }

        public AIIM_Orion_Volumes_Anomalies Populate(AIIM_AnomalyHistory aiimAnomalyHistory)
        {
            this.SourceUri = aiimAnomalyHistory.SourceUri;
            switch (aiimAnomalyHistory.MetricId)
            {
                case "Orion.Volume.PercentDiskUsedValue":
                    this.OrionVolumeUsageHistoryPercentDiskUsedValue = aiimAnomalyHistory.MetricValue;
                    this.OrionVolumeUsageHistoryPercentDiskUsedIsAnomalous = true;
                    break;
            }

            return this;
        }
    }
}
