using DapperExtensions.Mapper;

namespace SolarWinds.Tools.DataGeneration.DAL.Tables.Orion
{
    public sealed class Interfaces_ClassMapper : ClassMapper<Interfaces>
    {
        public Interfaces_ClassMapper()
        {
            Schema("dbo");
            Table("Interfaces");
            Map(p => p.InterfaceID).Key(KeyType.Identity);
            Map(p => p.NodeID).Key(KeyType.Assigned);
            AutoMap();
        }
    }
}
