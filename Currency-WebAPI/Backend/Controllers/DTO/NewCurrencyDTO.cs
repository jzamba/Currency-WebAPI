using Homework03_project.Domain;

namespace Homework03_project.Controllers.DTO
{
    public class NewCurrencyDTO
    {
        public string? CurrencyName { get; set; }
        public string? CurrencySymbol { get; set; }
        public string? CountryName { get; set; }
        public string? Continent { get; set; }

        public string? BiggestCoin { get; set; }

        public Currency ToModel()
        {
            return new Currency
            {
                Id = Id,
                CurrencyName = CurrencyName,
                CurrencySymbol = CurrencySymbol,
                CountryName = CountryName,
                Continent = Continent,
                BiggestCoin = BiggestCoin,
            };
        }
    }
}