using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using SolarWinds.Tools.DataGeneration.DAL.SwisEntities;
using SolarWinds.Tools.DataGeneration.DAL.Tables.Orion.Core;
using SolarWinds.Tools.ModelGenerators.Fakes;
using SolarWinds.Tools.ModelGenerators.InternetGenerator;
using SolarWinds.Tools.ModelGenerators.Metrics;

namespace SolarWinds.Tools.DataGeneration.DAL.Tables
{
    public class AIIM_AnomalyHistory : TableBase<AIIM_AnomalyHistory>
    {
       
        private static Regex eventDetails = new Regex(@"on node \((?<nodeId>[0-9]+)\)", RegexOptions.Compiled);
        private string machineName;

        private IList<Events> allEvents;
        public long AnomalyHistoryId { get; set; }
        public DateTime TimeStampUtc { get; set; }
        public DateTime MeasurementTimeUtc { get; set; }
        public DateTime ValidUntilUtc { get; set; }
        public string MetricId { get; set; }
        public string MetricDisplayName { get; set; }
        public string SourceOpid { get; set; }
        public int SourceId { get; set; }
        public string SourceInstanceType { get; set; }
        public string SourceUri { get; set; }
        public string SourceDisplayName { get; set; }
        public string SourceDetailsUrl { get; set; }
        public string SourceStatusIcon { get; set; }
        public string SourceIcon { get; set; }
        public double MetricValue { get; set; }
        public string Units { get; set; }
        public double AnomalyScore { get; set; }

        public AIIM_AnomalyHistory Populate(DateTime interval, Device device, System_ManagedEntity entityInstance, string metricID, MetricDataObservation observation, double metricValue)
        {
            var f = FakerHelper.Faker;
            this.SourceInstanceType = $"{entityInstance.InstanceType}";
            this.MetricId = metricID;
            this.SourceId = entityInstance.GetEntityId();
            this.SourceOpid = entityInstance.GetOpid();
            this.SourceUri = entityInstance.Uri;
            this.TimeStampUtc = interval;
            this.MeasurementTimeUtc = interval;
            this.ValidUntilUtc = this.TimeStampUtc + TimeSpan.FromMinutes(10);
            this.SourceDetailsUrl = entityInstance.DetailsUrl;
            this.SourceDisplayName = entityInstance.DisplayName;
            this.SourceIcon = "network-device";
            this.SourceStatusIcon = entityInstance.StatusLED.Replace(".gif","").ToLower();
            this.MetricDisplayName = metricID;
            this.MetricValue = metricValue;
            this.Units = "";
            return this;
        }
    }
}
