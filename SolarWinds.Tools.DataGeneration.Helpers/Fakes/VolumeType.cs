namespace SolarWinds.Tools.DataGeneration.Helpers.Fakes
{
    public enum VolumeType
    {
        /// <summary>
        /// Unknown volume type
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Know volume type but not one of listed here
        /// </summary>
        Other = 1,

        /// <summary>
        /// RAM
        /// </summary>
        RAM = 2,

        /// <summary>
        /// Virtual memory
        /// </summary>
        VirtualMemory = 3,

        /// <summary>
        /// Fixed disk
        /// </summary>
        FixedDisk = 4,

        /// <summary>
        /// Removable disk
        /// </summary>
        RemovableDisk = 5,

        /// <summary>
        /// Floppy disk
        /// </summary>
        FloppyDisk = 6,

        /// <summary>
        /// Compact disk
        /// </summary>
        CompactDisk = 7,

        /// <summary>
        /// RAM disk
        /// </summary>
        RAMDisk = 8,

        /// <summary>
        /// Flash memory
        /// </summary>
        FlashMemory = 9,

        /// <summary>
        /// Network disk
        /// </summary>
        NetworkDisk = 10,

        /// <summary>
        /// Mount point
        /// </summary>
        MountPoint = 100
    }
}
