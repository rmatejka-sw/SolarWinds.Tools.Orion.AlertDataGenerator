
namespace SolarWinds.Tools.DataGeneration.Helpers.Fakes
{
    /// <summary>
    /// Used to represent faked metric data for a single point in time. All values will be consistent
    /// (Current and average will never be greater or less than max and min respectively).
    /// </summary>
    public class MetricData
    {

        public MetricData()
        {

        }
        public double Current { get; set; }
        // We need to set these via some scale (time, voltage, temp) or physical capacity
        public double Min { get; set; }
        public double Max { get; set; }
        public double Average { get; set; }
        public virtual void UpdateValues()
        {

        }
    }
}
