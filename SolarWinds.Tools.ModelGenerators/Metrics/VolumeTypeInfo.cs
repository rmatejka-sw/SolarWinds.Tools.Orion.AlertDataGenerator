using System;
using System.Linq;
using SolarWinds.Tools.ModelGenerators.Extensions;
using SolarWinds.Tools.ModelGenerators.Fakes;


namespace SolarWinds.Tools.ModelGenerators.Metrics
{
    public class VolumeTypeInfo
    {
        private readonly int firstDeviceId = (int)Char.GetNumericValue('C');

        public VolumeTypeInfo(int volumeIndex = 1)
        {
            this.VolumeIndex = volumeIndex;
            VolumeType = FakerHelper.Faker.Random.EnumValues<VolumeType>(1,  new [] {VolumeType.Unknown}).FirstOrDefault();
            this.Label = this.IsPhysicalDisk ? FakerHelper.Faker.Name.JobDescriptor() : null;
            this.SerialNumber = this.IsPhysicalDisk ? FakerHelper.Faker.System.AndroidId() : null;
            this.Caption = this.IsPhysicalDisk ? $"{DeviceId} Label: {FakerHelper.Faker.Name.JobDescriptor()} Serial Number {this.SerialNumber}" : this.TypeName;
            if (this.Caption.Length>75) this.Caption = this.Caption.Substring(0,75);
        }

        public int VolumeIndex { get; }
        /// <summary>
        /// Returns a Volume name based on VolumeType.
        /// </summary>
        public string Caption { get; }

        /// <summary>
        /// Returns random SerialNumber based on VolumeType
        /// </summary>
        public string SerialNumber { get; }

        /// <summary>
        /// Returns random Label based on VolumeType
        /// </summary>
        public string Label { get; }

        /// <summary>
        /// Randomly generate VolumeType
        /// </summary>
        public VolumeType VolumeType { get; }

        /// <summary>
        /// Volume type id for Type
        /// </summary>;
        public int TypeId => (int)this.VolumeType;

        /// <summary>
        /// Returns type name for Type
        /// </summary>
        public string TypeName => VolumeType.ToString().ToSentenceCase();

        /// <summary>
        /// Returns device id based on Type.
        /// </summary>
        public string DeviceId => this.IsPhysicalDisk ? $"{(char)(firstDeviceId + (VolumeIndex - 1))}:" : null;

        /// <summary>
        /// Returns true if the VolumeType represents a physical disk
        /// </summary>
        public bool IsPhysicalDisk =>
            this.VolumeType switch
            {
                VolumeType.RemovableDisk => true,
                VolumeType.FloppyDisk => true,
                VolumeType.FixedDisk => true,
                VolumeType.CompactDisk => true,
                _ => false
            };

      
        /// <summary>
        /// Image for VolumeType
        /// </summary>
        public string TypeIcon => $"{this.VolumeType.ToString()}.gif";


    }
}
