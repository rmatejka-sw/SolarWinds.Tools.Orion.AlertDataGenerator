using System;
using System.Collections.Generic;
using System.Linq;
using SolarWinds.Tools.CommandLineTool.Helpers;

namespace SolarWinds.Tools.CommandLineTool.Extensions
{
    public static class ListExtensions
    {

        public static T PickRandom<T>(this IList<T> list) => FakerHelper.Faker.PickRandom<T>(list);

        public static string ToStringList<T>(this IList<T> list, string delimiter = ",", string itemQuote="")
        {
            return String.Join(delimiter, list.Select(_ => $"{itemQuote}{_}{itemQuote}").ToArray());
        }
    }
}
