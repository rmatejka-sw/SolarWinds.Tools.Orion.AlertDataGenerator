using System;
using SolarWinds.Tools.CommandLineTool.Models;
using SolarWinds.Tools.DataGeneration.Helpers.Fakes;
using SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads;

namespace SolarWinds.Tools.ModelGenerators.InternetGenerator
{
    /// <summary>
    /// An entity that is part of a device
    /// </summary>
    public interface IDeviceComponent<TMetricData> where TMetricData : IMetricData
    {

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
        /// Generates and records observation for the component based on the workWeek workLevel
        /// </summary>
        void GenerateObservation(DateTime interval, TimeRange timaRange, WorkWeek workLevel );
    }
}
