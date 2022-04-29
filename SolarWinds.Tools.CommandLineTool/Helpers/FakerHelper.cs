using Bogus;

namespace SolarWinds.Tools.CommandLineTool.Helpers
{
    public static class FakerHelper
    {
        public static string FakerMarker = "FAKE";
        private static Faker s_faker;

        public static Faker Faker => (s_faker ??= new Faker());
    }
}
