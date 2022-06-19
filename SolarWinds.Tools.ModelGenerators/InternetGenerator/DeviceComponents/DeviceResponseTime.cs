using System;
using SolarWinds.Tools.DataGeneration.Helpers.Fakes;

namespace SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceComponents
{
    /// <summary>
    /// Represents memory for a device
    /// </summary>
    public class DeviceResponseTime : DeviceComponent<TimeMetricData>
    {
        /// <summary>
        /// The maximum response time for the device after which the device is considered
        /// down.
        /// </summary>
        public TimeSpan MaxResponseTime { get; }

        public DeviceResponseTime() : this(TimeSpan.FromSeconds(5))
        {

        }

        public DeviceResponseTime(TimeSpan maxResponseTime) : base(ComponentType.Device)
        {
            this.MaxResponseTime = maxResponseTime;
            this.MetricData = new TimeMetricData
            {
                Min = 0,
                Max = this.MaxResponseTime.TotalMilliseconds
            };
        }
    }
}
