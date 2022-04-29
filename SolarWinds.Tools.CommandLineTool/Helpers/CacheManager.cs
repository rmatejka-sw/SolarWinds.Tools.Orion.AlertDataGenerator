using Microsoft.Extensions.Caching.Memory;

namespace SolarWinds.Tools.CommandLineTool.Helpers
{
    public static class CacheManager
    {
        public static IMemoryCache Cache { get; internal set; }
    }
}
