using System;
using System.Collections.Generic;
using System.Linq;

namespace SolarWinds.Tools.DataGeneration.DAL.Tables.Orion
{
    public class TopologyConnections : TableBase<TopologyConnections>
    {
        public TopologyConnections()
        {
        }


        // [FakeIntegerData(Const = 0)]
        public int DiscoveryProfileID { get; set; }

        public int SourceNodeID { get; set; }

        public int? SourceInterfaceID { get; set; }

        // [EnumeratedSourceValue(SourceType = typeof(TopologyConnectionsInfo), SourcePropertyName = nameof(TopologyConnectionsInfo.MappedNodeID))]
        public int MappedNodeID { get; set; }

        // [EnumeratedSourceValue(SourceType = typeof(TopologyConnectionsInfo), SourcePropertyName = nameof(TopologyConnectionsInfo.MappedInterfaceID))]
        public int? MappedInterfaceID { get; set; }

        // [EnumeratedSourceValue(SourceType = typeof(TopologyConnectionsInfo), SourcePropertyName = nameof(TopologyConnectionsInfo.SrcType))]
        public string SrcType { get; set; }

        // [EnumeratedSourceValue(SourceType = typeof(TopologyConnectionsInfo), SourcePropertyName = nameof(TopologyConnectionsInfo.DestType))]
        public string DestType { get; set; }

        // [EnumeratedSourceValue(SourceType = typeof(TopologyConnectionsInfo), SourcePropertyName = nameof(TopologyConnectionsInfo.SourceNodeID))]
        public int? DataSourceNodeID { get; set; }

        // [FakeDateTimeData(DaysFromNow = 1000)]
        public DateTime? LastUpdateUtc { get; set; }

        // [FakeStringData(Const = "L2")]
        public string Layer_Type { get; set; }

        // [FakeStringData(Const = "IP to IP (cdp, lldp)")]
        public string LinkType { get; set; }

        private class TopologyConnectionsInfo
        {
            public int SourceNodeID { get; set; }

            public int? SourceInterfaceID { get; set; }

            public int MappedNodeID { get; set; }

            public int? MappedInterfaceID { get; set; }

            public string SrcType { get; set; }
            public string DestType { get; set; }
        }

    }
}
