using Bogus;

namespace SolarWinds.Tools.DataGeneration.Helpers
{
    public static class FakerHelper
    {
        public static string FakeName = "FAKE";
        public static string FakeMarker = "__FAKED__";
        private static Faker s_faker;

        public static Faker Faker => (s_faker ??= new Faker());
    }
}
