using DapperExtensions.Mapper;

namespace SolarWinds.Tools.DataGeneration.DAL.Tables.Orion
{
    public sealed class NodesCustomProperties_ClassMapper : ClassMapper<NodesCustomProperties>
    {
        public NodesCustomProperties_ClassMapper()
        {
            Schema("dbo");
            Table("NodesCustomProperties");
            Map(p => p.NodeID).Key(KeyType.Assigned);
            AutoMap();
        }
    }
}
