using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using SolarWinds.Tools.DataGeneration.DAL.Tables.Orion.Core;

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

        public string SourceOpid { get; set; }

        public int SourceId { get; set; }

        public string SourceInstanceType { get; set; }

        public string SourceUri { get; set; }

        public double MetricValue { get; set; }

        public double AnomalyScore { get; set; }

        public double Threshold { get; set; }

        public bool? Ignore { get; set; }

        public bool? IsValid { get; set; }

        public int? Duration { get; set; }

        public string SourceDisplayName { get; set; }
        public string SourceDetailsUrl { get; set; }
        public string SourceStatusIcon { get; set; }
        public string SourceIcon { get; set; }

        public string MetricDisplayName { get; set; }

        public AIIM_AnomalyHistory()
        {
            //var eventData = this.allEvents[(int)recordIndex];
            //var eventInfos = eventData.Message.Split(':');
            //var instance = eventInfos[0];
            //this.SourceInstanceType = $"Orion.{instance}s";
            //this.MetricId = eventInfos[1];
            //this.SourceId = eventData.NetObjectID ?? 0;
            //this.SourceOpid = $"1_{this.SourceInstanceType}_{this.SourceId}";
            //this.SourceUri = GetSourceUri(eventData.Message, machineName, instance);
            //this.TimeStampUtc = (eventData.EventTime ?? DateTime.Now).ToUniversalTime();
            //this.MeasurementTimeUtc = this.TimeStampUtc;
            //this.ValidUntilUtc = this.TimeStampUtc + TimeSpan.FromMinutes(10);
            //this.SourceDetailsUrl = "#";
            //this.SourceDisplayName = "";
            //this.SourceIcon = "network-device";
            //this.SourceStatusIcon = "up";
            //this.MetricDisplayName = this.MetricId.Replace("_", " ");
            //this.MetricValue = double.Parse(eventData.Message.Split(new string[] { "value=" }, StringSplitOptions.None)[1]);
        }

        private string GetSourceUri(string eventMessage, string machineName, string instance)
        {
            if (instance != "Node")
            {
                // For child: anomaly for Volume 2 on node to-23.alessandro.name-FAKE10 on node (12) to-23.alessandro.name-FAKE10 value=100
                var eventInfo = eventMessage.Split(':')[1];
                var match = eventDetails.Match(eventInfo);
                if (match.Success)
                {
                    // SAMPLE: swis://ENG-AUS-COR-055./Orion/Orion.Nodes/NodeID=2/Volumes/VolumeID=3
                    return  $"swis://{machineName}/Orion/Orion.Nodes/NodeID={match.Groups["nodeId"].Value}/{this.SourceInstanceType.Split('.')[1]}/{instance}ID={this.SourceId}";
                }

            }
            return  $"swis://{machineName}/Orion/{this.SourceInstanceType}/{instance}ID={this.SourceId}";
        }
    }
}
