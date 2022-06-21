using System;
using System.Linq;
using SolarWinds.Tools.ModelGenerators.Fakes;
using SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads;
using SolarWinds.Tools.ModelGenerators.Metrics;

namespace SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceComponents
{
    public class DeviceVolumeUsage : DeviceComponent<VolumeMetricData>
    {
        public DeviceVolumeUsage() : base(ComponentType.Volume)
        {
            this.MetricData = new VolumeMetricData();
        }

        public override double GenerateObservation(DateTime interval, TimeRange timeRange, WorkWeek workWeek, double workLevelAffect = 1)
        {
            var f = FakerHelper.Faker;
            double value = 0;
            double usageRate = 0.0001;
            var workLevel = workWeek.GetWorkLevelForInterval(interval, timeRange.PollingInterval);
            var variability = 0.001 * this.MetricData.Span;
            var increasePerInterval = usageRate * this.MetricData.Span;
            var shiftedWorkLevel = (workLevel - 49.0) / 100.0 * usageRate;
            var previousValue = this.MetricData.Observations.Count > 0 
                ? this.MetricData.Observations.Last().Value
                : FakerHelper.Faker.Random.Double(this.MetricData.Capacity*0.1, this.MetricData.Capacity *0.4);
            value = previousValue + increasePerInterval + this.MetricData.Span*shiftedWorkLevel + f.Random.Double(-previousValue*0.1, previousValue * 0.1) ;
            this.MetricData.RecordObservation(interval, value);
            return value;
        }
    }
}
