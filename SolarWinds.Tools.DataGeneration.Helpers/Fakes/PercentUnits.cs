namespace SolarWinds.Tools.DataGeneration.Helpers.Fakes
{
    public class PercentUnits : Units
    {
        public PercentUnits() : base("%", "%", "%")
        {
        }
        public MetricPrefix Prefix { get; }
        public string Singular { get;}

        public string Plural { get;  }
        public string Abbreviation { get; }
    }
}
