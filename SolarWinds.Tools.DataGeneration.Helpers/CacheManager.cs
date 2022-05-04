using System.ComponentModel.Design;
using Microsoft.Extensions.Caching.Memory;

namespace SolarWinds.Tools.DataGeneration.Helpers
{
    public static class CacheManager
    {
        public static IMemoryCache Cache { get; internal set; }

        public static void Initialize(IMemoryCache cache) => Cache = cache; 
    }
}
