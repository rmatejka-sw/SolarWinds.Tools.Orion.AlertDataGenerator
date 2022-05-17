using SolarWinds.Tools.DataGeneration.Helpers.Fakes;

namespace SolarWinds.Tools.DataGeneration.Helpers.Extensions
{
    public static class FakerExtensions
    {
        private static readonly OrionFakes orionFakes = new OrionFakes();

        public static OrionFakes Orion(this Bogus.Faker faker) => orionFakes;
    }
}
