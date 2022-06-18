using System;
using System.Linq;

namespace SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads
{
    public class WorkWeek
    {
        private NonWorkDay _nonWorkDay;
        private WorkDay _workDay;
        private DayOfWeek[] weekendDays = new[] {DayOfWeek.Saturday, DayOfWeek.Sunday};

        public WorkWeek(int minutesPerInterval = 10, double startPercent = 0)
        {
            this._nonWorkDay = new NonWorkDay(minutesPerInterval, startPercent);
            this._workDay = new WorkDay(minutesPerInterval, startPercent);
        }

        public double GetWorkLevelForInterval(DateTime interval, TimeSpan pollingInterval)
        {
            if (weekendDays.Contains(interval.DayOfWeek)) return this._nonWorkDay.GetWorkLevelForInterval(interval, pollingInterval);
            return this._workDay.GetWorkLevelForInterval(interval, pollingInterval);
        }

    }
}
