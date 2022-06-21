using System;
using System.Collections.Generic;
using System.Linq;
using SolarWinds.Tools.ModelGenerators.Metrics;

namespace SolarWinds.Tools.ModelGenerators.Fakes
{
    public class OrionFakes
    {
        private static readonly Dictionary<string, MemoryMetricData> MemoryDataCache =
            new Dictionary<string, MemoryMetricData>();

        internal OrionFakes()
        {

        }

        private readonly string[] vendors =
            ("3Com|Adtran|Agile Storage, Inc.|American Power Conversion Corp.|APC NetBotz|Aruba Networks Inc|" +
            "Avaya Communication|Brocade Communications Systems, Inc.|Cisco|Compatible Systems Corp.|" +
            "Dell Computer Corporation|External|Extreme Networks|F5 Networks, Inc.|" +
            "FlowPoint Corporation|Fore Systems, Inc.|Foundry Networks, Inc.|H3C|HP|" +
            "HUAWEI Technology Co.,Ltd|IBM|Juniper Networks, Inc.|Juniper Networks/NetScreen|Linksys|" +
            "Linux|Meraki Networks, Inc.|Meru Networks|Multi-Tech Systems, Inc.|net-snmp|" +
            "Network Appliance Corporation|Northern Telecom|Palo Alto Networks|Riverbed|Ruckus Wireless Inc|" +
            "Samsung Group|Sun Microsystems|Symbol Technologies, Inc.|Synoptics|U.S. Robotics, Inc.|Unknown|" +
            "VMware Inc.|Windows|ZyXEL Communications Corp.").Split('|');

        private readonly string[] machineTypes = ("3Com Hub|Adtran|Agile Storage, Inc.|Amazon Linux AMI|American Power Conversion Corp.|AP6511|Aruba Networks Inc|" +
                                            "Avaya Communication|BIG-IP Virtual Edition|Brocade Communications Systems, Inc.|Catalyst 3560G 48T|Catalyst 37xx Stack|" +
                                            "centos|Cisco|Cisco 1200 Access Point|Cisco 2501|Cisco 2505|Cisco 2511|Cisco 2610 XM|Cisco 2621 XM|Cisco 2651 XM|" +
                                            "Cisco 2811|Cisco 2821|Cisco 2851|Cisco 2951K9|Cisco 3640|Cisco 3725|Cisco 7120 T3|Cisco 7206 VXR|Cisco AirCt2504K9|" +
                                            "Cisco ASA 5510SC|Cisco Catalyst 2948|Cisco Catalyst 3548 XL|Cisco Catalyst 3560-E24PD|Cisco Catalyst 4506-E|" +
                                            "Cisco Catalyst 6000|Cisco Catalyst 6009|Cisco Catalyst 6506|Cisco CSR 1000V|Cisco MDS-9120|Cisco UCS|" +
                                            "Cisco Unified Communications Manager|Cisco Wireless Controller|Compatible Systems Corp.|Dell Computer Corporation|" +
                                            "Dell PowerConnect 3424|Dell Switch|ERS 5520-48T-PWR|Extreme Networks Alpine 3804|Extreme Networks Alpine 3808|" +
                                            "Extreme Networks Summit 24|F5|FlowPoint Corporation|Fore Systems, Inc.|Foundry Networks, Inc.|H3C|HP|" +
                                            "HP Jet-Direct Print Server|HP Switch|HUAWEI Technology Co., Ltd|Hyper-V Server|IBM PowerPC|Juniper J2320 Router|" +
                                            "Juniper Networks/NetScreen|Juniper SRX100 Firewall|Juniper Switch|Linksys|Meraki Networks Cloud WLC|Meru Networks|" +
                                            "Multi-Tech Systems, Inc.|NetApp Clustered Filer|NetApp Filer|NetBotz 355 Wall|net-snmp|net-snmp - Linux|" +
                                            "Network Plotter|Northern Telecom|Palo Alto Networks|ProCurve Switch 4204vl J8770A|ProCurve Switch 5406zl J8697A|" +
                                            "Raspbian|Red Hat|RFS4000|Samsung Group|Steelhead 1020|Sun Microsystems SunOS|SuSE|U.S.Robotics, Inc.|Ubuntu|Unknown|" +
                                            "VMware ESX Server|VMware Inc.|VMware vCenter Server|Windows 2000 Domain Controller|Windows 2000 Server|" +
                                            "Windows 2003 Domain Controller|Windows 2003 Server|Windows 2003 Server / XP x64|Windows 2008 Domain Controller|" +
                                            "Windows 2008 R2 Domain Controller|Windows 2008 R2 Server|Windows 2008 Server|Windows 2012 R2 Server|" +
                                            "Windows 2012 Server|Windows 8.1 Workstation|ZoneDirector 1000|ZyXEL Communications Corp.").Split('|');


        /// <summary>
        /// Returns a random size for a disk volume based on standard sizes currently available.
        /// </summary>
        public float VolumeSize => (float)FakerHelper.Faker.PickRandom(new VolumeMetricData().PhysicalCapacities);

        /// <summary>
        /// Returns a random Orion Vendor
        /// </summary>
        public string Vendor => FakerHelper.Faker.PickRandom<string>(vendors);

        /// <summary>
        /// Returns a random Orion Vendor icon image name
        /// </summary>
        public string VendorIcon => $"{FakerHelper.Faker.Random.Int(1, 800)}.gif";

        /// <summary>
        /// Returns a fake Orion status based on the supplied percentages
        /// </summary>
        /// <param name="percentDown">Percent of time Down (2) will be generated. Default is 2%.</param>
        /// <param name="percentWarning">Percent of time Warning (3) will be generated. Default is 10%.</param>
        /// <param name="percentOther">Percent of time a status between 4 and 30 will be generated. Default is 20%.</param>
        /// <returns>Orion integer status</returns>
        public OrionStatusInfo Status(int percentDown = 2, int percentWarning = 10, int percentOther = 20)
        {
            var pick = FakerHelper.Faker.Random.Int(1, 100);
            if (pick <= percentDown)
            {
                return OrionStatusInfo.Down;
            }

            if (pick <= percentWarning)
            {
                return OrionStatusInfo.Warning;
            }
            if (pick <= percentOther)
            {
                // Orion Statuses
                return FakerHelper.Faker.PickRandom(OrionStatusInfo.StatusInfos.Where(_ =>
                    _ != OrionStatusInfo.Down && _ != OrionStatusInfo.Up && _ != OrionStatusInfo.Warning));
            }
            return OrionStatusInfo.Up;
        }

        /// <summary>
        /// Orion status image filename based on existing status if fromStatus passed or random by default.
        /// </summary>
        /// <param name="fromStatus">Pass to get image for existing status</param>
        /// <returns>Filename for image status</returns>
        public string StatusImage(int? fromStatus = null) => $"{((fromStatus.HasValue? OrionStatusInfo.StatusIdToStatusInfo((int)fromStatus.Value) : this.Status()).IconPostfix)}.gif";


        /// <summary>
        /// Returns a random Orion machine type
        /// </summary>
        public string MachineType => FakerHelper.Faker.PickRandom<string>(machineTypes);

        /// <summary>
        /// Returns CapacityMetricData representing machine memory. Value will be unique if machineId is null.
        /// If machineId is passed, previous value will be returned with updated values for MetricData while
        /// Capacity will remain unchanged. If a pollingInterval is included, new data will be generated on first call
        /// but subsequent calls for the same interval will return the data unchanged.
        /// </summary>
        /// <param name="machineId">Unique identifier for machine for which faked memory is used.</param>
        /// <param name="pollingInterval">Polling interval for data. If called again with same machineId and pollingInterval, no changes will be made to previous data.</param>
        /// <returns>CapacityMetricData with faked, consistent values.</returns>
        public MemoryMetricData Memory(string machineId = null, DateTime? pollingInterval = null)
        {
            string key = GetCacheKey(machineId, pollingInterval);
            if (!MemoryDataCache.TryGetValue(key, out MemoryMetricData value))
            {
                MemoryDataCache.Add(key, value = new MemoryMetricData());
            }
            return value;
        }

        private string GetCacheKey(string machineId, DateTime? pollingInterval = null) => $"{machineId}|{pollingInterval ?? DateTime.MinValue}";
    }
}
