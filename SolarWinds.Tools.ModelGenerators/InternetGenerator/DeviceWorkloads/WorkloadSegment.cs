
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using SolarWinds.Tools.ModelGenerators.Metrics;

namespace SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads
{
    /// <summary>
    /// Defines a single segment of a workload. The duration of the segment
    /// is defined in terms of polling intervals. 
    /// </summary>
    public class WorkloadSegment
    {
        private Regex rateDefinitionPattern = new Regex(@"(?<intervals>\d+)@(?<rate>-?\d+)");
        private Regex endPercentDefinitionPattern = new Regex(@"(?<intervals>\d+)>(?<endPercent>-?\d+)");
        private double? startPercent;
        private double? endPercent;
        private bool isEndPercent = false;

        /// <summary>
        /// Description of the segment having the following format:
        /// TotalIntervals@Rate
        /// For example, 5@0.5 describes a segment that is 5 intervals long
        /// and increases at a rate of 0.5 percent per interval.
        /// Alternately, an absolute ending worklevel can be given using the syntax
        /// TotalIntervals>WorkLevel
        /// </summary>
        /// <param name="definition"></param>
        public WorkloadSegment(string definition)
        {
            var groups = rateDefinitionPattern.Matches(definition).FirstOrDefault()?.Groups;
            if (groups == null)
            {
                groups = endPercentDefinitionPattern.Matches(definition).FirstOrDefault()?.Groups;
                if (groups == null)
                {
                    this.TotalIntervals = 1;
                    this.PercentChangePerInterval = 0;
                    return;
                }

                this.isEndPercent = true;
                this.EndPercent = double.TryParse(groups["endPercent"].Value, out double rate) ? rate : 0;
            }
            else
            {
                this.PercentChangePerInterval = double.TryParse(groups["rate"].Value, out double rate) ? rate : 0;
            }
            this.TotalIntervals = Int32.TryParse(groups["intervals"].Value, out int intervals) ? intervals : 1;
        }

        /// <summary>
        /// Defines a workload segment lasting totalIntervals and changing by
        /// percentChangePerInterval each interval.
        /// </summary>
        /// <param name="totalIntervals"></param>
        /// <param name="percentChangePerInterval"></param>
        public WorkloadSegment(int totalIntervals, double percentChangePerInterval)
        {
            this.TotalIntervals = totalIntervals;
            this.PercentChangePerInterval = percentChangePerInterval;
        }

        /// <summary>
        /// Defines a workload segment lasting totalIntervals and from startPercent
        /// to endPercent.
        /// </summary>
        /// <param name="totalIntervals"></param>
        /// <param name="startPercent"></param>
        /// <param name="endPercent"></param>
        public WorkloadSegment(int totalIntervals, double startPercent, double endPercent)
        {
            this.TotalIntervals = totalIntervals;
            this.StartPercent = startPercent;
            this.EndPercent = endPercent;
            this.PercentChangePerInterval = (this.EndPercent - this.StartPercent) / this.TotalIntervals;
        }

        public int TotalIntervals { get; }
        public double? PercentChangePerInterval { get; private set; }
        public double? EndPercent { get => endPercent; private set => endPercent = Math.Max(Math.Min(value ?? 0, 100.0), 0.0); }

        public double? StartPercent
        {
            get => startPercent;
            private set
            {
                startPercent = MetricData.Clamp(value ?? 0, 0, 100.0);
                if (this.isEndPercent)
                {
                    this.PercentChangePerInterval = (this.EndPercent - this.StartPercent) / this.TotalIntervals;
                }
                else
                {
                    this.EndPercent = value + this.TotalIntervals * PercentChangePerInterval;
                }
            }

        }
        

        /// <summary>
        /// Enumerable for WorkLevels returning value between 0 and 100 representing workload percentage
        /// </summary>
        /// <returns></returns>
        public IEnumerable<double> WorkloadLevels(double startPercent = 0, int? repeat = null, int durationMultiplier = 1)
        {
            StartPercent = startPercent;
            double currentPercent = startPercent;
            for (int interval = 1; interval <= TotalIntervals; interval++)
            {
                currentPercent = MetricData.Clamp(currentPercent + PercentChangePerInterval ?? 0, 0, 100);
                yield return currentPercent;
            }

        }


        /// <summary>
        /// Enumerable for WorkloadRates returning value between 0 and 100 representing workload rate of change for the interval
        /// </summary>
        /// <returns></returns>
        public IEnumerable<double> WorkloadRates(double currentWorkLevelRate)
        {
            StartPercent = currentWorkLevelRate;
            for (int interval = 1; interval <= TotalIntervals; interval++)
            {
                yield return PercentChangePerInterval??0;
            }

        }

    }
}
