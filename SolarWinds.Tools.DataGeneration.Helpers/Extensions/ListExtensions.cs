using System;
using System.Collections.Generic;
using System.Linq;
using SolarWinds.Tools.DataGeneration.Helpers.Fakes;

namespace SolarWinds.Tools.DataGeneration.Helpers.Extensions
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
