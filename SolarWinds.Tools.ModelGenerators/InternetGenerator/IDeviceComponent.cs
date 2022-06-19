using System;
using SolarWinds.Tools.DataGeneration.Helpers.Fakes;
using SolarWinds.Tools.DataGeneration.Helpers.Models;
using SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads;

namespace SolarWinds.Tools.ModelGenerators.InternetGenerator
{
    /// <summary>
    /// An entity that is part of a device
    /// </summary>
    public interface IDeviceComponent<TMetricData> where TMetricData : IMetricData
    {
        /// <summary>
        /// Returns the current reading for the MetricData. Equivalent to
        /// MetricData.Current
        /// </summary>
        double Current { get; }

        TMetricData MetricData { get; }
        /// <summary>
        /// Global index of device which the component is a part of
        /// </summary>
        int DeviceIndex { get; set; }

        /// <summary>
        /// Type of component
        /// </summary>
        ComponentType ComponentType { get; }

        /// <summary>
        /// Generates and records observation for the component based on the workWeek workLevel. WorkLevelAffect
        /// controls the degree to which the worklevel affects the metric
        /// </summary>
        double GenerateObservation(DateTime interval, TimeRange timaRange, WorkWeek workLevel, double workLevelAffect=1.0 );
    }
}
