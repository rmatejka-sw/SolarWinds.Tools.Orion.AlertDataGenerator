using DapperExtensions.Mapper;

namespace SolarWinds.Tools.DataGeneration.DAL.Tables.Orion
{
    public sealed class NodesData_ClassMapper : ClassMapper<NodesData>
    {
        public NodesData_ClassMapper()
        {
            Schema("dbo");
            Table("NodesData");
            Map(p => p.NodeID).Key(KeyType.Identity);
            Map(p => p.IPAddress).Column("IP_Address");
            Map(p => p.IPAddressType).Column("IP_Address_Type");
            AutoMap();
        }
    }
}
