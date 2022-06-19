﻿using SolarWinds.Tools.DataGeneration.Helpers.Fakes;

namespace SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceComponents
{
    /// <summary>
    /// Represents memory for a device
    /// </summary>
    public class DeviceAvailability : DeviceComponent<UtilizationMetricData>
    {

        public DeviceAvailability() : base(ComponentType.Device)
        {
            this.MetricData = new UtilizationMetricData();
        }

    }
}
