using System;
using Dapper.Contrib.Extensions;
using SolarWinds.Tools.ModelGenerators.Fakes;
using SolarWinds.Tools.ModelGenerators.Metrics;

namespace SolarWinds.Tools.DataGeneration.DAL.Tables.Orion
{
    [Table("NodesStatistics")]
    public class NodesStatistics : TableBase<NodesStatistics>
    {
        public NodesStatistics Populate(NodesData node)
        {
            var f = FakerHelper.Faker;
            base.Populate();
            this.NodeID = (int)node.NodeID;
            this.LastBoot = f.Date.Past();
            this.SystemUpTime = f.Random.Float(1, 30000);
            this.LastSystemUpTimePollUtc = f.Date.Recent();
            this.ResponseTime = f.Random.Short(1, 1000);
            this.PercentLoss = f.Random.Float(1, 100);
            this.AvgResponseTime = f.Random.Short(1, 1000);
            this.MinResponseTime = f.Random.Short(0, this.ResponseTime.Value);
            this.MaxResponseTime = f.Random.Short(this.ResponseTime.Value, 2000);
            this.NextPoll = f.Date.Soon();
            this.LastSync = f.Date.Recent();
            this.NextRediscovery = f.Date.Soon();
            this.CPUCount = f.Random.Short(1, 10);
            this.CPULoad = f.Random.Short(1, 100);
            this.PercentMemoryUsed = f.Random.Int(1, 80);
            this.MemoryUsed = node.TotalMemory * (this.PercentMemoryUsed / 100f);
            this.CustomPollerLastStatisticsPoll = f.Date.Recent();
            this.CustomPollerLastStatisticsPollSuccess = f.Date.Recent(); return this;
        }

        [ExplicitKey]
        public int NodeID { get; set; }

        public DateTime? LastBoot { get; set; }
        public Single? SystemUpTime { get; set; }
        public DateTime? LastSystemUpTimePollUtc { get; set; }
        public short? ResponseTime { get; set; }
        public Single? PercentLoss { get; set; }
        public short? AvgResponseTime { get; set; }
        public short? MinResponseTime { get; set; }
        public short? MaxResponseTime { get; set; }
        public DateTime? NextPoll { get; set; }
        public DateTime? LastSync { get; set; }
        public DateTime? NextRediscovery { get; set; }
        public short? CPUCount { get; set; }
        public short? CPULoad { get; set; }
        public Single? MemoryUsed { get; set; }
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
        public DateTime CustomPollerLastStatisticsPoll { get; set; }
        public DateTime CustomPollerLastStatisticsPollSuccess { get; set; }
    }
}
