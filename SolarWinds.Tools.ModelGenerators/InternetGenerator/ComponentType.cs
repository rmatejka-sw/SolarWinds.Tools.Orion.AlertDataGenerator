using System;

namespace SolarWinds.Tools.ModelGenerators.InternetGenerator
{
    [Flags]
    public enum ComponentType
    {
        /// <summary>
        /// Represents the base component device
        /// </summary>
        Device = 0,

        /// <summary>
        /// DeviceInterface type marker
        /// </summary>
        Interface = 1,

        /// <summary>
        /// DeviceVolume type marker
        /// </summary>
        Volume = 2,

        /// <summary>
        /// DeviceMemory type marker
        /// </summary>
        Memory = 4,

        /// <summary>
        /// DeviceCpu type marker
        /// </summary>
        Cpu = 8
    }
}
