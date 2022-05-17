using DapperExtensions.Mapper;

namespace SolarWinds.Tools.DataGeneration.DAL.Tables.Orion
{
    public sealed class Volumes_ClassMapper : ClassMapper<Volumes>
    {
        public Volumes_ClassMapper()
        {
            Schema("dbo");
            Table("Volumes");
            Map(p => p.VolumeID).Key(KeyType.Identity);
            Map(p => p.NodeID).Key(KeyType.Assigned);
            AutoMap();
        }
    }
}
