using System;
using Newtonsoft.Json;

namespace SolarWinds.Tools.DataGeneration.Helpers.Extensions
{
    public static class ObjectExtensions
    {
        public static T ToClass<T>(this object target, bool returnNewOnError=true) where T : class, new()
        {
            try
            {
                var json = JsonConvert.SerializeObject(target);
                return JsonConvert.DeserializeObject<T>(json,new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }
            catch (Exception e)
            {
                ConsoleLogger.Error(e);
            }

            return returnNewOnError ? new T() : null;
        }
    }
}
