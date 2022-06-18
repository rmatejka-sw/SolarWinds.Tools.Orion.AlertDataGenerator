using SolarWinds.Tools.DataGeneration.Helpers.Fakes;
using System;
using SolarWinds.Tools.CommandLineTool.Models;
using SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads;

namespace SolarWinds.Tools.ModelGenerators.InternetGenerator
{
    public class DeviceComponent<TMetricData> : IDeviceComponent<TMetricData> where TMetricData : IMetricData
    {
        public DeviceComponent(ComponentType componentType)
        {
            this.ComponentType = componentType;
        }

        public TMetricData MetricData { get; set; }

        public int DeviceIndex { get; set; }

        public ComponentType ComponentType { get; private set; }

        public void GenerateObservation(DateTime interval, TimeRange timeRange, WorkWeek workWeek)
        {
            var f = FakerHelper.Faker;
            double value = 0;
            // YOU ARE HERE - need optiosn to control:
            // Anomalies
            // Noise
            // %Scale Variability
            var workLevel = workWeek.GetWorkLevelForInterval(interval, timeRange.PollingInterval);
            var variability = 0.1 * this.MetricData.Span;
            value = this.MetricData.Span * workLevel/100.0 + f.Random.Double(-variability, variability);
            this.MetricData.RecordObservation(interval, value);
        }
    }
}
