using System.Collections.Generic;
using SolarWinds.Tools.CommandLineTool.Helpers;

namespace SolarWinds.Tools.CommandLineTool.Extensions
{
    public static class ListExtensions
    {

        public static T PickRandom<T>(this IList<T> list) => FakerHelper.Faker.PickRandom<T>(list);
    }
}
