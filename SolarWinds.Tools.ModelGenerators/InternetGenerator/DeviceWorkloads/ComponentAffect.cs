namespace SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads
{
    /// <summary>
    /// Describes the way a related DeviceWorkload affects the types of components given by ComponentTypes.
    /// The Behavior describes how the DeviceWorkload WorkLevel affects changes the component metrics.
    /// </summary>
    public class ComponentAffect
    {
        private DeviceWorkload _deviceWorkload;

        public ComponentAffect(ComponentType componentTypes, DeviceWorkload deviceWorkload)
        {
            this.ComponentTypes = componentTypes;
            this._deviceWorkload = deviceWorkload;
        }

        public ComponentType ComponentTypes { get; }

        public float AffectWeight { get; set; }

        /// <summary>
        /// Defines how the Device Workload WorkLevel changes the affected components. For example, when set to Linear,
        /// changes in the WorkLevel will alter the related component metrics in a linear manner. Other options
        /// include Exponential and Logarithmic.
        /// </summary>
        public AffectBehavior Behavior { get; set; }

    }
}
