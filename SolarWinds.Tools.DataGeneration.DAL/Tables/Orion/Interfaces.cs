using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SolarWinds.Tools.DataGeneration.DAL.Tables.Orion
{
    public class Interfaces : TableBase
    {
           //Since the OrionNodeID property is written on the Devices of the NetworkGenerator when the NodesData items are generated, we need to have an IEnumerable to NodesData
        //in our ctor even if we don't use it.
        public Interfaces()
        {
            //var interfaces = networkGenerator.Interfaces.OrderBy(i => i.DeviceIndex);
            //this.RowCount = interfaces.Count();
            //this.CurrentEntityId = networkGenerator.SqlProvider.ExecuteScalar<int>("SELECT ISNULL(MAX(InterfaceID),1) from Interfaces");
            //AddEnumeratedSource(interfaces);
            //this.allNodes = nodesData;
            //var devices = interfaces.Select(i => networkGenerator.Devices.FirstOrDefault(d => d.DeviceIndex == i.DeviceIndex));
            //AddEnumeratedSource(devices);
        }
        public int CurrentEntityId { get; set; }
        
        private static float StatusToInterfaceErrorsPerHour(Status status)
        {
            switch (status)
            {
                case Tables.Status.Down:
                    return 2600.0f;
                case Tables.Status.Up:
                    return 0.0f;
                case Tables.Status.Warning:
                    return 1002.0f;
            }

            return 0.0f;
        }

        public int NodeID { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int InterfaceID { get; set; }

        public string ObjectSubType { get; set; }

        public string InterfaceName { get; set; }

        public int? InterfaceIndex { get; set; }

        public int? InterfaceType { get; set; }

        public string InterfaceTypeName { get; set; }

        public string InterfaceTypeDescription { get; set; }

        public double? InterfaceSpeed { get; set; }

        public int? InterfaceMTU { get; set; }

        public DateTime? InterfaceLastChange { get; set; }

        public string PhysicalAddress { get; set; }

        public bool? UnManaged { get; set; }

        //Always a Null value.
        public DateTime? UnManageFrom { get; set; }

        //Always a Null value.
        public DateTime? UnManageUntil { get; set; }

        public short? AdminStatus { get; set; }

        public short? OperStatus { get; set; }

        public double? InBandwidth { get; set; }

        public double? OutBandwidth { get; set; }

        public string Caption { get; set; }

        public int? PollInterval { get; set; }

        public int? RediscoveryInterval { get; set; }

        public string FullName { get; set; }

        public string Status { get; set; }

        public string StatusLED { get; set; }

        public string AdminStatusLED { get; set; }

        public string OperStatusLED { get; set; }

        public string InterfaceIcon { get; set; }

        public Single? Outbps { get; set; }

        public Single? Inbps { get; set; }

        public Single? OutPercentUtil { get; set; }

        public Single? InPercentUtil { get; set; }

        public Single? OutPps { get; set; }

        public Single? InPps { get; set; }

        public short? InPktSize { get; set; }

        public short? OutPktSize { get; set; }

        public Single? OutUcastPps { get; set; }

        public Single? OutMcastPps { get; set; }

        public Single? InUcastPps { get; set; }

        public Single? InMcastPps { get; set; }

        public Single? InDiscardsThisHour { get; set; }

        public Single? InDiscardsToday { get; set; }

         public Single? InErrorsThisHour { get; set; }

        public Single? InErrorsToday { get; set; }

        public Single? OutDiscardsThisHour { get; set; }

        public Single? OutDiscardsToday { get; set; }

        public Single? OutErrorsThisHour { get; set; }

       public Single? OutErrorsToday { get; set; }

        public Single? MaxInBpsToday { get; set; }

        //Always a Null value.
        public DateTime? MaxInBpsTime { get; set; }

        public Single? MaxOutBpsToday { get; set; }

        //Always a Null value.
        public DateTime? MaxOutBpsTime { get; set; }

        public DateTime? NextRediscovery { get; set; }

        public DateTime? NextPoll { get; set; }

        public string Counter64 { get; set; }

        public short? StatCollection { get; set; }

        public DateTime? LastSync { get; set; }

        public string InterfaceAlias { get; set; }

        public string IfName { get; set; }

        public int? Severity { get; set; }

        public bool? CustomBandwidth { get; set; }

        public bool? UnPluggable { get; set; }

        public DateTime CustomPollerLastStatisticsPoll { get; set; }

        public int InterfaceSubType { get; set; }

        public bool? CollectAvailability { get; set; }

        public int DuplexMode { get; set; }

        public Single? LateCollisionsThisHour { get; set; }

        public Single? CRCAlignErrorsThisHour { get; set; }

        public Single? LateCollisionsToday { get; set; }

        public Single? CRCAlignErrorsToday { get; set; }

        //Always a Null value.
        public string CarrierName { get; set; }

        public string Comments { get; set; }

    }
}
