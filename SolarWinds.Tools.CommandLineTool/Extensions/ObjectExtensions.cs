using System;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;
using SolarWinds.Tools.CommandLineTool.Helpers;

namespace SolarWinds.Tools.CommandLineTool.Extensions
{
    public static class ObjectExtensions
    {
        public static T ToClass<T>(this object target, bool returnNewOnError=true) where T : class, new()
        {
            try
            {
                var json = JsonConvert.SerializeObject(target);
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception e)
            {
                ConsoleLogger.Error(e);
            }

            return returnNewOnError ? new T() : null;
        }
    }
}
