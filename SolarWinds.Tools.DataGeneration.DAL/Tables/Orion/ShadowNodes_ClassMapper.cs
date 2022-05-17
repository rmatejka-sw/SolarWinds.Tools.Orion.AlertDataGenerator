using DapperExtensions.Mapper;

namespace SolarWinds.Tools.DataGeneration.DAL.Tables.Orion
{
    public sealed class ShadowNodes_ClassMapper : ClassMapper<ShadowNodes>
    {
        public ShadowNodes_ClassMapper()
        {
            Schema("dbo");
            Table("ShadowNodes");
            Map(p => p.NodeId).Key(KeyType.Assigned);
            AutoMap();
        }
    }
}
