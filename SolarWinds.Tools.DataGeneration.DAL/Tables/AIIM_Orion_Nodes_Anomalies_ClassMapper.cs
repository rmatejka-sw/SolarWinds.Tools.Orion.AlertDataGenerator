using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using DapperExtensions.Mapper;

namespace SolarWinds.Tools.DataGeneration.DAL.Tables.Orion
{
    public sealed class AIIM_Orion_Nodes_Anomalies_ClassMapper : ClassMapper<AIIM_Orion_Nodes_Anomalies>
    {
        public AIIM_Orion_Nodes_Anomalies_ClassMapper()
        {
            Schema("dbo");
            Table("AIIM_Orion_Nodes_Anomalies");

            Map(p => p.SourceUri).Key(KeyType.Assigned);
            foreach (var propertyInfo in typeof(AIIM_Orion_Nodes_Anomalies).GetProperties())
            {
                var columnAttribute = propertyInfo.GetCustomAttribute(typeof(ColumnAttribute)) as ColumnAttribute;
                if (columnAttribute == null) continue;
                Map(propertyInfo).Column(columnAttribute.Name);
            }
            AutoMap();
        }
    }
}
