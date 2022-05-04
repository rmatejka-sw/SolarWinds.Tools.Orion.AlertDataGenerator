namespace SolarWinds.Tools.DataGeneration.DAL.Extensions
{
    public static class FakerExtensions
    {
        /// <summary>
        /// Returns fake company department
        /// </summary>
        public static string Department(this Bogus.Faker faker) => faker.Commerce.Department();
        
        /// <summary>
        /// Returns fake city
        /// </summary>
        public static string City(this Bogus.Faker faker) => faker.Address.City();

        /// <summary>
        /// Returns fake sentence with maxLength defaulting to 255
        /// </summary>
        public static string Sentence(this Bogus.Faker faker, int maxLength=255) =>
            faker.Lorem.Sentence().Substring(0, maxLength);

        /// <summary>
        /// Returns fake sentence with maxLength defaulting to 255
        /// </summary>
        public static string MonetaryValue(this Bogus.Faker faker, decimal min = 0, decimal max = 1000, int decimals=2,
            string symbol = "$") =>
            faker.Commerce.Price(min, max, decimals, symbol);
    }
}
