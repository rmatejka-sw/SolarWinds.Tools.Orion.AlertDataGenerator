using DapperExtensions.Mapper;

namespace SolarWinds.Tools.DataGeneration.DAL.Tables.Orion
{
    public sealed class NodesStatistics_ClassMapper : ClassMapper<NodesStatistics>
    {
        public NodesStatistics_ClassMapper()
        {
            Schema("dbo");
            Table("NodesStatistics");
            Map(p => p.NodeID).Key(KeyType.Assigned);
            AutoMap();
        }
    }
}
