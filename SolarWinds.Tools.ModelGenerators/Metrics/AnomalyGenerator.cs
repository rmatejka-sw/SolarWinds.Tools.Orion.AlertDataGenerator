using System;
using System.Collections.Generic;
using SolarWinds.Tools.ModelGenerators.Fakes;
using SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads;

namespace SolarWinds.Tools.ModelGenerators.Metrics
{
    public class AnomalyGenerator
    {
        private IEnumerator<double> activeAnomaly;
        private IMetricData metricData;
        private double metricStartValue;

        public AnomalyGenerator(IMetricData metricData)
        {
            this.metricData = metricData;
            this.AnomalyDefinitions = new List<WorkloadDefinition>()
            {
                //new WorkloadDefinition(
                //    $"2>50",
                //    "2>0"
                //    )
                new WorkloadDefinition(
                    "1>80",
                    "2>0",
                    "1>-80"
                )

            };
        }

        public void Reset()
        {
            this.activeAnomaly = null;
        }

        public IList<WorkloadDefinition> AnomalyDefinitions { get; }

        /// <summary>
        /// Returns next anomalous value in a sequence. If sequence has completed and
        /// start is false, null is returned. Once the sequence has been started, start
        /// is ignored.
        /// </summary>
        /// <param name="start"></param>
        /// <returns></returns>
        public double? NextValue(bool start=false)
        {
            bool hasValue = activeAnomaly?.MoveNext() ?? false;
            if (activeAnomaly==null && start)
            {
                activeAnomaly = FakerHelper.Faker.PickRandom<WorkloadDefinition>(AnomalyDefinitions)
                    .WorkloadRates(0).GetEnumerator();
                hasValue = activeAnomaly.MoveNext();
                this.metricStartValue = this.metricData.Current;
            }

            if (activeAnomaly == null || !hasValue) return null;
            return this.metricStartValue = (this.metricStartValue + activeAnomaly.Current / 100f * metricData.Span);
        }

    }


}
