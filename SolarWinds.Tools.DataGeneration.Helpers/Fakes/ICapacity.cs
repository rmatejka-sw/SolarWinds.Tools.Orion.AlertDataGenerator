using System.Collections.Generic;

namespace SolarWinds.Tools.DataGeneration.Helpers.Fakes
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
