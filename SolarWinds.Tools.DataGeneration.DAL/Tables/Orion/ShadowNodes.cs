using System;
using System.ComponentModel.DataAnnotations;

namespace SolarWinds.Tools.DataGeneration.DAL.Tables.Orion
{
    public class ShadowNodes : TableBase
    {
        public ShadowNodes()
        {
        }

        [Key]
        // [FakeIntegerData(Min = 1, Distribution = FakeDataDistribustionType.Increasing)]
        public int NodeId { get; set; }

        public string IPAddress { get; set; }

        public string NodeName { get; set; }

        // [FakeMacAddressData]
        public string MACAddress { get; set; }

        // [FakeGuidData]
        public Guid? IPAddressGUID { get; set; }

 
    }
}
