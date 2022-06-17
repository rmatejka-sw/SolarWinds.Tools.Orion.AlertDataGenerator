namespace SolarWinds.Tools.DataGeneration.Helpers.Fakes
{
    public class BytesMetricData : MetricData
    {
        public override Units Units => new Units("byte", "bytes", "B");
    }
}
