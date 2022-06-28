
using System.ComponentModel.DataAnnotations.Schema;
using DapperExtensions.Mapper;

namespace SolarWinds.Tools.DataGeneration.DAL.Tables
{
    /// <summary>
    /// Currently not used as these would have to be updated in Real-Time
    /// </summary>
    [Dapper.Contrib.Extensions.Table("AIIM_Orion_Nodes_Anomalies")]
    public class AIIM_Orion_Nodes_Anomalies : TableBase<AIIM_Orion_Nodes_Anomalies>
    {
        public string SourceUri { get; set; }

        [Column("Orion_CPULoad_AvgLoadDisplayName")]
        public string OrionCPULoadAvgLoadDisplayName { get; set; } = "CPU AvgLoad";
        
        [Column("Orion_CPULoad_AvgLoadIsAnomalous")]
        public bool? OrionCPULoadAvgLoadIsAnomalous { get; set; }

        [Column("Orion_CPULoad_AvgLoadUnits")]
        public string OrionCPULoadAvgLoadUnits { get; set; } = "%";

        [Column("Orion_CPULoad_AvgLoadValue")]
        public double? OrionCPULoadAvgLoadValue { get; set; }

        [Column("Orion_CPULoad_AvgPercentMemoryUsedDisplayName")]
        public string OrionCPULoadAvgPercentMemoryUsedDisplayName { get; set; } = "CPU AvgPercentMemory";
        
        [Column("Orion_CPULoad_AvgPercentMemoryUsedIsAnomalous")]
        public bool? OrionCPULoadAvgPercentMemoryUsedIsAnomalous { get; set; }

        [Column("Orion_CPULoad_AvgPercentMemoryUsedUnits")]
        public string OrionCPULoadAvgPercentMemoryUsedUnits { get; set; } = "%";

        [Column("Orion_CPULoad_AvgPercentMemoryUsedValue")]
        public double? OrionCPULoadAvgPercentMemoryUsedValue { get; set; }

        [Column("Orion_ResponseTime_AvgResponseTimeDisplayName")]
        public string OrionResponseTimeAvgResponseTimeDisplayName { get; set; } = "AvgResponseTime";
        [Column("Orion_ResponseTime_AvgResponseTimeIsAnomalous")]
        public bool? OrionResponseTimeAvgResponseTimeIsAnomalous { get; set; }
        [Column("Orion_ResponseTime_AvgResponseTimeUnits")]
        public string OrionResponseTimeAvgResponseTimeUnits { get; set; } = "ms";
        [Column("Orion_ResponseTime_AvgResponseTimeValue")]
        public double? OrionResponseTimeAvgResponseTimeValue { get; set; }


        [Column("Orion_ResponseTime_PercentLossDisplayName")]
        public string OrionResponseTimePercentLossDisplayName { get; set; } = "PercentLoss";
        [Column("Orion_ResponseTime_PercentLossIsAnomalous")]
        public bool? OrionResponseTimePercentLossIsAnomalous { get; set; }
        [Column("Orion_ResponseTime_PercentLossUnits")] 
        public string OrionResponseTimePercentLossUnits { get; set; } = "%";
        [Column("Orion_ResponseTime_PercentLossValue")]
        public double? OrionResponseTimePercentLossValue { get; set; }


        public AIIM_Orion_Nodes_Anomalies Populate(AIIM_AnomalyHistory aiimAnomalyHistory)
        {
            this.SourceUri = aiimAnomalyHistory.SourceUri;
            switch (aiimAnomalyHistory.MetricId)
            {
                case "Orion.CPULoad.AvgLoad":
                    this.OrionCPULoadAvgLoadValue = aiimAnomalyHistory.MetricValue;
                    this.OrionCPULoadAvgLoadIsAnomalous = true;
                    break;
                case "Orion.CPULoad.AvgPercentMemoryUsed":
                    this.OrionCPULoadAvgPercentMemoryUsedValue = aiimAnomalyHistory.MetricValue;
                    this.OrionCPULoadAvgPercentMemoryUsedIsAnomalous = true; 
                    break;
                case "Orion.ResponseTime.AvgResponseTime":
                    this.OrionResponseTimeAvgResponseTimeValue = aiimAnomalyHistory.MetricValue;
                    this.OrionResponseTimeAvgResponseTimeIsAnomalous = true;
                    break;
                case "Orion.ResponseTime.PercentLoss":
                    this.OrionResponseTimePercentLossValue = aiimAnomalyHistory.MetricValue;
                    this.OrionResponseTimePercentLossIsAnomalous = true;
                    break;
            }

            return this;
        }
    }
}
