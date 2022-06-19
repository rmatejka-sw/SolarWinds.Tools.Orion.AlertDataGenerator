using System;
using System.Collections.Generic;
using System.Linq;
using SolarWinds.Tools.DataGeneration.Helpers.Extensions;

namespace SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads
{

    /// <summary>
    /// Temporary class that returns a WorkLevel based on time of day and day of week.
    /// This will be replaced/enhanced by BusinessProcess definitions at a future time
    /// </summary>
    public class WorkDay
    {
        protected WorkloadDefinition workloadDefinition;
        protected IList<double> _workLevels;
        public WorkDay(int minutesPerInterval=10, double startPercent = 0, WorkloadDefinition workloadDefinition=null)
        {
            var intervalsPerHour = 60 / minutesPerInterval;
            // Assume first interval start at midnight
            this.workloadDefinition = workloadDefinition ?? new WorkloadDefinition(
                $"{5* intervalsPerHour}>5",     // 0-5am
                $"{3 * intervalsPerHour}>10",    // 5-8am 
                $"{2 * intervalsPerHour}>60",    // 8-10am
                $"{4 * intervalsPerHour}@0",    // 10am-2pm
                $"{3 * intervalsPerHour}>30",    // 2-5pm
                $"{3 * intervalsPerHour}>10",    // 5-8pm
                $"{4 * intervalsPerHour}>2"    // 8-12am
                );
            this._workLevels = this.workloadDefinition.WorkloadLevels(startPercent).ToList();
        }

        public IList<double> WorkLevels => _workLevels;
        public double GetWorkLevelForInterval(DateTime interval, TimeSpan pollingInterval)
        {
            return this._workLevels[interval.ToTimeIntervalIndex((int)pollingInterval.TotalMinutes)];
        }
    }
}
