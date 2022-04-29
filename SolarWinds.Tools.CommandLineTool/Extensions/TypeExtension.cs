using System;
using System.Collections.Generic;
using System.Reflection;

namespace SolarWinds.Tools.CommandLineTool.Extensions
{
    public static class TypeExtension
    {
        public static string GetPropertyList(this Type type, string listDelimiter = ",")
        {
            var propertyNames = new List<string>();
            foreach (var propertyInfo in type.GetProperties(BindingFlags.DeclaredOnly |
                                                            BindingFlags.Public |
                                                            BindingFlags.Instance))
            {
                propertyNames.Add(propertyInfo.Name);
            }

            return String.Join(listDelimiter, propertyNames.ToArray());
        }
    }
}
