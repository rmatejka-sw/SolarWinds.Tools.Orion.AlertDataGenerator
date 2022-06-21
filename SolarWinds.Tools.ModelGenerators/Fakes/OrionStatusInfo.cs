using System.Collections.Generic;
using System.Linq;
using AutoBogus;
using AutoBogus.Templating;
using SolarWinds.Tools.ModelGenerators.Extensions;

namespace SolarWinds.Tools.ModelGenerators.Fakes
{
    public class OrionStatusInfo
    {
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public int Ranking { get; set; }
        public string Color { get; set; }
        public string IconPostfix { get; set; }

        public static IList<OrionStatusInfo> StatusInfos = new AutoFaker<OrionStatusInfo>().GenerateWithTemplate(@"
StatusId|StatusName|Ranking|Color|IconPostfix
2|Down|110|#950000|down
8|LowerLayerDown|130|#FF00A3|updown
12|Unreachable|150|#111111|unreachable
36|Off|160|#A31770|shutdown
14|Critical|210|#DD2C00|critical
3|Warning|220|#FEC405|warning
15|PartlyAvailable|230|#BCBD22|warning
16|Misconfigured|240|#C2C2C2|unknown
17|Undefined|250|#C2C2C2|unknown
19|Unconfirmed|270|#BCBD22|unknown
32|OnBattery|280|#BCBD22|warning
33|OnSmartBoost|281|#BCBD22|warning
37|Rebooting|282|#BCBD22|warning
41|OnSmartTrim|283|#BCBD22|warning
34|TimedSleeping|420|#A6DBF8|sleep
35|SoftwareBypass|421|#A6DBF8|unplugged
38|SwitchedBypass|422|#A6DBF8|unplugged
39|HardwareFailureBypass|423|#A6DBF8|unplugged
40|SleepingUntilPowerReturn|424|#A6DBF8|sleep
44|OnBatteryTest|425|#C2C2C2|testing
11|External|440|#9954D4|external
26|MonitoringDisabled|450|#C2C2C2|unknown
27|Disabled|460|#C2C2C2|disabled
7|NotPresent|470|#C2C2C2|blank
5|Testing|480|#C2C2C2|testing
28|NotLicensed|490|#C2C2C2|unknown
0|Unknown|495|#999999|unknown
4|Shutdown|496|#707070|shutdown
29|OtherCategory|497|#C2C2C2|other
30|NotRunning|498|#A6DBF8|notrunning
10|Unplugged|498|#A6DBF8|unplugged
42|EcoMode|499|#A6E7DE|up
43|HotStandBy|499|#A6E7DE|up
31|Online|499|#B8D757|up
9|Unmanaged|499|#176998|unmanaged
1|Up|500|#B8D757|up
22|Active|540|#00A753|up
6|Dormant|560|#C2C2C2|unknown
24|Inactive|570|#C2C2C2|unknown
25|Expired|580|#C2C2C2|unknown");


        public static OrionStatusInfo Down => StatusInfos.FirstOrDefault(_ => _.StatusName == "Down");
        public static OrionStatusInfo Up => StatusInfos.FirstOrDefault(_ => _.StatusName == "Up");
        public static OrionStatusInfo Warning => StatusInfos.FirstOrDefault(_ => _.StatusName == "Warning");
        public static OrionStatusInfo Critical => StatusInfos.FirstOrDefault(_ => _.StatusName == "Critical");

        public static OrionStatusInfo StatusIdToStatusInfo(int statusId) => StatusInfos.FirstOrDefault(_ => _.StatusId == statusId);
        public string StatusText => this.StatusId.ToString();
        public string StatusLED => FakerHelper.Faker.Orion().StatusImage(this.StatusId);
    }


}
