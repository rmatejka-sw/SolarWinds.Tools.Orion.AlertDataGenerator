using System.Linq;

namespace SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads
{

    /// <summary>
    /// Temporary class that returns a WorkLevel based on time of day and day of week.
    /// This will be replaced/enhanced by BusinessProcess definitions at a future time
    /// </summary>
    public class NonWorkDay : WorkDay
    {
        public NonWorkDay(int minutesPerInterval=6, double startPercent = 0, WorkloadDefinition workloadDefinition=null) : base(minutesPerInterval, startPercent)
        {
            var intervalsPerHour = 60 / minutesPerInterval;
            // 10 minutes per interval = 6 intervals per hour
            // Assume first interval start at midnight
            this.workloadDefinition = workloadDefinition??new WorkloadDefinition(
                $"{5* intervalsPerHour}>5",     // 0-5am
                $"{3 * intervalsPerHour}>10",    // 5-8am 
                $"{2 * intervalsPerHour}>20",    // 8-10am
                $"{4 * intervalsPerHour}@0",    // 10am-2pm
                $"{3 * intervalsPerHour}>15",    // 2-5pm
                $"{3 * intervalsPerHour}>10",    // 5-8pm
                $"{4 * intervalsPerHour}>2"    // 8-12am
                );
            this._workLevels = this.workloadDefinition.WorkloadLevels(startPercent).ToList();
        }
    }
}
