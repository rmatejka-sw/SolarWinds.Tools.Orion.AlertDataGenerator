using System.Collections.Generic;
using System.Linq;

namespace SolarWinds.Tools.DataGeneration.DAL.SwisEntities
{
    public class AIIM_AlertConditionEntityProperty : SwisEntity
    {
        protected override string SwisEntityType => "Orion.AIIM.AlertConditionEntityProperty";
        public int AlertId { get; set; }

        public string EntityType { get; set; }
        public string EntityProperty { get; set; }
        public string AnomalyEntityType { get; set; }
        public string AnomalyEntityProperty { get; set; }
        public bool IsAnomalyCondition { get; set; }
        public static IList<AIIM_AlertConditionEntityProperty> GetList() => SwisEntity.Get<AIIM_AlertConditionEntityProperty>().ToList();
    }
}
