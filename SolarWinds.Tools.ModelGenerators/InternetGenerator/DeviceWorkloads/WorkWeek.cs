﻿using System;
using System.Linq;

namespace SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads
{
    public class WorkWeek
    {
        private DayOfWeek[] weekendDays = new[] { DayOfWeek.Saturday, DayOfWeek.Sunday };
        public NonWorkDay NonWorkDay { get; set; }
        public WorkDay WorkDay { get; set; }


        public WorkWeek(int minutesPerInterval = 10, double startPercent = 0)
        {
            this.NonWorkDay = new NonWorkDay(minutesPerInterval, startPercent);
            this.WorkDay = new WorkDay(minutesPerInterval, startPercent);
        }

        public double GetWorkLevelForInterval(DateTime interval, TimeSpan pollingInterval)
        {
            if (weekendDays.Contains(interval.DayOfWeek)) return this.NonWorkDay.GetWorkLevelForInterval(interval, pollingInterval);
            return this.WorkDay.GetWorkLevelForInterval(interval, pollingInterval);
        }

    }
}
