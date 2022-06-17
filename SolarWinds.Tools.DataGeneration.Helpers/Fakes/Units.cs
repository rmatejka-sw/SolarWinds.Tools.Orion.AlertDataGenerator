namespace SolarWinds.Tools.DataGeneration.Helpers.Fakes
{
    public class Units
    {
        public Units(string singular, string plural="", string abbreviation="", MetricPrefix prefix = MetricPrefix.Unit)
        {
            Singular = singular;
            Plural = plural ?? singular;
            Abbreviation = abbreviation ?? singular;
        }
        public MetricPrefix Prefix { get; }
        public string Singular { get;}

        public string Plural { get;  }
        public string Abbreviation { get; }

    }
}
