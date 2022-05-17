namespace SolarWinds.Tools.DataGeneration.Helpers.Fakes
{
    public class CapacityUsageInfo
    {
        public CapacityUsageInfo(double capacity, int minPercentUsed = 5, int maxPercentUsed = 99)
        {
            var f = FakerHelper.Faker;
            this.PercentUsed = f.Random.Int(minPercentUsed, maxPercentUsed);
            this.Capacity = capacity;
            this.Used = this.Capacity * (this.PercentUsed/100.0);
            this.Available = this.Capacity - this.Used;
        }
        public double Capacity { get; }
        public double Available { get;  }
        public double Used { get; set; }
        public int PercentUsed { get; set; }
    }
}
