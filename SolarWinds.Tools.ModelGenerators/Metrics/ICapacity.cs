using System.Collections.Generic;

namespace SolarWinds.Tools.ModelGenerators.Metrics
{
    public interface ICapacity 
    {
        IList<double> PhysicalCapacities { get; }
        double Capacity { get; set; }
        double PercentUsed { get; } 
        public double Available { get; } 
        public double Used { get; } 

    }
}
