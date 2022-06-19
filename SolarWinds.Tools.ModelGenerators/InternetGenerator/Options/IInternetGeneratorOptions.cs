
namespace SolarWinds.Tools.ModelGenerators.InternetGenerator.Options
{
    /// <summary>
    /// Options for generating a topology typical of the Internet.
    /// </summary>
    public interface IInternetGeneratorOptions 
    {
        public int MaxHops { get; set; }
        public int MinNodes { get; set; }
        public int ShadowNodes { get; set; }
        public int MaxInternalNodes { get; set; }
        public int MaxConnectionsBetweenNodes { get; set; }
        public bool ExcludeIntranetDevices { get; set; }

    }
}
