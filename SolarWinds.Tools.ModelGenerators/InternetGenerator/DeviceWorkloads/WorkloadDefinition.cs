using System.Collections.Generic;
using System.Linq;


namespace SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads
{
    public class WorkloadDefinition
    {
        /// <summary>
        /// Defines the workload response using multiple segments
        /// having the following format:
        /// TotalIntervals@Rate
        /// For example, 5@0.5 describes a segment that is 5 intervals long
        /// and increases at a rate of 0.5 percent per interval.
        /// Alternately, an absolute ending worklevel can be given using the syntax
        /// TotalIntervals>WorkLevel
        /// </summary>
        /// <param name="segmentDefinitions"></param>
        public WorkloadDefinition(params string[] segmentDefinitions)
        {
            foreach (var definition in segmentDefinitions)
            {
                Segments.Add(new WorkloadSegment(definition));
            }
        }

        private IList<WorkloadSegment> Segments { get; } = new List<WorkloadSegment>();

        /// <summary>
        /// Returns WorkLevel between 0 and 100
        /// </summary>
        /// <param name="startPercent"></param>
        /// <param name="repeat"></param>
        /// <param name="durationMultiplier"></param>
        /// <returns></returns>
        public IEnumerable<double> WorkloadLevels( double startPercent = 0, int? repeat = null, int durationMultiplier = 1)
        {
            var currentWorkLevel = startPercent;
            foreach (var segment in Segments)
            {
                var workLevels = segment.WorkloadLevels(currentWorkLevel).ToList();
                foreach (var workloadLevel in workLevels)
                {
                    currentWorkLevel = workloadLevel;
                    yield return currentWorkLevel;
                }
            }
        }


        /// <summary>
        /// Enumerable for WorkloadRates returning value between 0 and 100 representing workload rate of change for the interval
        /// </summary>
        /// <returns></returns>
        public IEnumerable<double> WorkloadRates(double startRate)
        {
            var currentWorkLevelRate = startRate;
            foreach (var segment in Segments)
            {
                var workRates = segment.WorkloadRates(currentWorkLevelRate).ToList();
                foreach (var workloadRate in workRates)
                {
                    currentWorkLevelRate += workloadRate;
                    yield return workloadRate;
                }
            }

        }
    }
}
