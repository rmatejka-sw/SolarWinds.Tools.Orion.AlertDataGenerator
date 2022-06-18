using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Bogus;
using Bogus.DataSets;
using Dates.Recurring;
using Dates.Recurring.Type;
using SolarWinds.Tools.CommandLineTool.Models;
using SolarWinds.Tools.DataGeneration.Helpers.Fakes;
using SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads;

namespace SolarWinds.Tools.ModelGenerators.InternetGenerator.BusinessProcesses
{
    /// <summary>
    /// A business process represents a collection of work that happens over time. The work is measured
    /// as a WorkLevel ranging from 0 to 100%. The cycle is used to schedule DeviceWorkloads to specific devices
    /// over time to represent activity on devices.
    /// </summary>
    public class BusinessProcess
    {

        public BusinessProcess()
        { 
        }

        /// <summary>
        /// Describes the pattern in time for the Business Process to reoccur. 
        /// </summary>
        public RecurrenceType Frequency { get; set; }

        /// <summary>
        /// List of devices that will be used when scheduling DeviceWorkloads
        /// </summary>
        public IList<Device> Devices { get;} = new List<Device>();

        public IList<DeviceWorkload> DeviceWorkloads { get; } = new List<DeviceWorkload>();
        
        /// <summary>
        /// The work cycle defined for the business process based on typical work week. Also affected by holidays.
        /// </summary>
        public UtilizationMetricData WorkLevel { get; }

        /// <summary>
        /// Any date listed will result in the WorkLevel for that day being reduced for any DeviceWorkload
        /// that is affected by people. Automated tasks will not be affected.
        /// </summary>
        public IList<DateTime> Holidays { get; set; }

          

        public IEnumerable<MetricDataObservation> WorkloadLevelObservations(TimeRange timeRange)
        {
            IList<IEnumerator<double>> workLoadIterators = new List<IEnumerator<double>>();
            this.SelectWorkloadDefinitions(workLoadIterators);
            foreach (var interval in timeRange.PollingIntervals())
            {
                double intervalTotal = 0;
                foreach (var iterator in workLoadIterators)
                {
                    intervalTotal += iterator.Current;
                }

                workLoadIterators = workLoadIterators.Where(iterator => iterator.MoveNext()).ToList();
                this.SelectWorkloadDefinitions(workLoadIterators);
                yield return new MetricDataObservation(interval, intervalTotal);
            }

            foreach (var iterator in workLoadIterators)
            {
                iterator.Dispose();
            }
        }

        private void SelectWorkloadDefinitions(IList<IEnumerator<double>> workLoadIterators)
        {
            if (workLoadIterators.Count == 0)
            {
                foreach (var workload in DeviceWorkloads)
                {
                    workLoadIterators.Add(workload.Definition.WorkloadLevels().GetEnumerator());
                }
            }
        }
    }
}
