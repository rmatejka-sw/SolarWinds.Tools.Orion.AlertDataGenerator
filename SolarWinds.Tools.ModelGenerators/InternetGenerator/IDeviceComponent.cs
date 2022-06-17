using SolarWinds.Tools.DataGeneration.Helpers.Fakes;

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

    }
}
