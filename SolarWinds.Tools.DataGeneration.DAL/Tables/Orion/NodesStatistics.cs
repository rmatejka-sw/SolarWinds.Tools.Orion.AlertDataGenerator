using System;
using System.Linq;

namespace SolarWinds.Tools.DataGeneration.DAL.Tables.Orion
{
    public class NodesStatistics : TableBase
    {
        public NodesStatistics()
        {
        }
        public int NodeID { get; set; }

        // [FakeDateTimeData(DaysFromNow = 365)]
        public DateTime? LastBoot { get; set; }

        // [FakeFloatingPointData(Min = 1, Max = 30000)]
        public Single? SystemUpTime { get; set; }

        // [FakeDateTimeData(DaysFromNow = 1)]
        public DateTime? LastSystemUpTimePollUtc { get; set; }

        // [FakeIntegerData(Min = 1, Max = 1000)]
        public short? ResponseTime { get; set; }

        // [FakeIntegerData(Min = 1, Max = 100)]
        public Single? PercentLoss { get; set; }

        // [FakeIntegerData(Min = 1, Max = 1000)]
        public short? AvgResponseTime { get; set; }

        // [FakeIntegerFromProperties(MinConst = 0, Max = nameof(ResponseTime))]
        public short? MinResponseTime { get; set; }

        // [FakeIntegerFromProperties(Min = nameof(ResponseTime), MaxConst = 2000)]
        public short? MaxResponseTime { get; set; }

        // [FakeDateTimeData(DaysBeyondNow = 1)]
        public DateTime? NextPoll { get; set; }

        // [FakeDateTimeData(DaysFromNow = 1)]
        public DateTime? LastSync { get; set; }

        // [FakeDateTimeData(DaysBeyondNow = 1)]
        public DateTime? NextRediscovery { get; set; }

        // [FakeIntegerData(Min = 1, Max = 10)]
        public short? CPUCount { get; set; }

        // [FakeIntegerData(Min = 1, Max = 100)]
        public short? CPULoad { get; set; }

        // [FakeIntegerData(Min = NetworkGenerator.GigaBytes, Max = 999 * NetworkGenerator.GigaBytes)]
        public Single? MemoryUsed { get; set; }

        // [FakeIntegerData(Min = 1, Max = 80)]
        public int? PercentMemoryUsed { get; set; }

        public Single? BufferNoMemThisHour { get; set; }
        public Single? BufferNoMemToday { get; set; }
        public Single? BufferSmMissThisHour { get; set; }
        public Single? BufferSmMissToday { get; set; }
        public Single? BufferMdMissThisHour { get; set; }
        public Single? BufferMdMissToday { get; set; }
        public Single? BufferBgMissThisHour { get; set; }
        public Single? BufferBgMissToday { get; set; }
        public Single? BufferLgMissThisHour { get; set; }
        public Single? BufferLgMissToday { get; set; }
        public Single? BufferHgMissThisHour { get; set; }
        public Single? BufferHgMissToday { get; set; }
        public Single? LoadAverage1 { get; set; }
        public Single? LoadAverage5 { get; set; }
        public Single? LoadAverage15 { get; set; }

        // [FakeDateTimeData(DaysFromNow = 1)]
        public DateTime CustomPollerLastStatisticsPoll { get; set; }

        // [FakeDateTimeData(DaysFromNow = 1)]
        public DateTime CustomPollerLastStatisticsPollSuccess { get; set; }
    }
}
