
using System;
using SolarWinds.Tools.ModelGenerators.Fakes;
using SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads;
using SolarWinds.Tools.ModelGenerators.Metrics;

namespace SolarWinds.Tools.ModelGenerators.InternetGenerator
{
    public class DeviceComponent<TMetricData> : IDeviceComponent<TMetricData> where TMetricData : IMetricData
    {
        private DateTime? lastAnomaly;
        private TMetricData metricData;
        private int deviceIndex;
        private ComponentType componentType;

        protected AnomalyGenerator AnomalyGenerator { get; private set; }

        public DeviceComponent(ComponentType componentType)
        {
            this.ComponentType = componentType;
        }

        public double Current => this.MetricData.Current;

        public TMetricData MetricData
        {
            get => metricData;
            set
            {
                metricData = value;
                this.AnomalyGenerator = new AnomalyGenerator(this.MetricData);
            }
        }

        public int DeviceIndex
        {
            get => deviceIndex;
            set => deviceIndex = value;
        }

        public ComponentType ComponentType
        {
            get => componentType;
            private set => componentType = value;
        }

        public virtual double GenerateObservation(DateTime interval, TimeRange timeRange, WorkWeek workWeek, double workLevelAffect=1.0)
        {
            var f = FakerHelper.Faker;
            double value = 0;
            // YOU ARE HERE - need options to control:
            // Anomalies
            // Noise
            // %Scale Variability
            var workLevel = workWeek.GetWorkLevelForInterval(interval, timeRange.PollingInterval);
            var variability = 0.1 * this.MetricData.Span;
            value = this.MetricData.Span * (workLevel / 100.0 * workLevelAffect) + f.Random.Double(-variability, variability);
            bool createAnomaly = (interval > timeRange.StartDate.AddDays(3) && FakerHelper.Faker.Random.Bool(0.5f));
            double? anomalousValue = this.AnomalyGenerator.NextValue(createAnomaly);
            value += anomalousValue ?? 0;
            if (anomalousValue.HasValue)
            {
                lastAnomaly = interval;
            }
            else if (lastAnomaly.HasValue && interval > lastAnomaly.Value.AddHours(FakerHelper.Faker.Random.Double(5,15)))
            {
                this.AnomalyGenerator.Reset();
            }
            this.MetricData.RecordObservation(interval, value, anomalousValue.HasValue);
            return value;
        }

    }
}
