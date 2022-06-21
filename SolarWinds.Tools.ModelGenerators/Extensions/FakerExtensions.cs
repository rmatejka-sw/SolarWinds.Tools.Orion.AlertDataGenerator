using SolarWinds.Tools.ModelGenerators.Fakes;

namespace SolarWinds.Tools.ModelGenerators.Extensions
{
    public static class FakerExtensions
    {
        private static readonly OrionFakes orionFakes = new OrionFakes();

        public static OrionFakes Orion(this Bogus.Faker faker) => orionFakes;
    }
}
