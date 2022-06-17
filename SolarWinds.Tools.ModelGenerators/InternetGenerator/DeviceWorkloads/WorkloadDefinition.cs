using System.Collections.Generic;
using System.Linq;
using SolarWinds.Tools.DataGeneration.Helpers.Fakes;

namespace SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads
{
    public class WorkloadDefinition
    {

        public WorkloadDefinition(params string[] segmentDefinitions)
        {
            foreach (var definition in segmentDefinitions)
            {
                Segments.Add(new WorkloadSegment(definition));
            }
        }

        private IList<WorkloadSegment> Segments { get; } = new List<WorkloadSegment>();

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

    }
}
