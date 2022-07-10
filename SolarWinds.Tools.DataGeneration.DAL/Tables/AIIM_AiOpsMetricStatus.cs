using System;
using Dapper.Contrib.Extensions;
using SolarWinds.Tools.DataGeneration.DAL.Models;
using SolarWinds.Tools.ModelGenerators.Fakes;

namespace SolarWinds.Tools.DataGeneration.DAL.Tables
{
    [Table("AIIM_AiOpsMetricStatus")]
    public class AIIM_AiOpsMetricStatus
    {
        public string SourceUri { get; set; }
        public string MetricName { get; set; }
        public DateTime TimeStampUtc { get; set; }
        public DateTime MeasurementTimeUtc { get; set; }
        public int Status { get; set; }

        public AIIM_AiOpsMetricStatus Populate(AIIM_AnomalyHistory aiimAnomalyHistory)
        {
            this.SourceUri = aiimAnomalyHistory.SourceUri;
            this.MetricName = aiimAnomalyHistory.MetricId;
            this.MeasurementTimeUtc = aiimAnomalyHistory.MeasurementTimeUtc;
            this.TimeStampUtc = aiimAnomalyHistory.TimeStampUtc;
            this.Status = (int)AiOpsMetricStatusEnum.AnomalyDetected;
            return this;
        }

        public AIIM_AiOpsMetricStatus Populate(DateTime interval, string sourceUri, string metricId)
        {
            var f = FakerHelper.Faker;
            this.SourceUri = sourceUri;
            this.MetricName = metricId;
            this.MeasurementTimeUtc = interval;
            this.TimeStampUtc = interval;
            this.Status = (int) f.Random.WeightedRandom(
                new[] { AiOpsMetricStatusEnum.Down, AiOpsMetricStatusEnum.Untrained, AiOpsMetricStatusEnum.NotDetected },
                new float[] { 0.1f, 0.2f, 0.7f }
            );
            return this;
        }

    }
}
