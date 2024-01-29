using Homework03_project.Domain;

namespace Homework03_project.Controllers.DTO
{
    public class CurrencyInfoDTO
    {
         public int Id { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencySymbol { get; set; }
        public string CountryName { get; set; }
        public string Continent { get; set; }
        public string BiggestCoin { get; set; }

        public static CurrencyInfoDTO FromModel(Currency currency)
        {
            return new CurrencyInfoDTO
            {
                Id = currency.Id,
                CurrencyName = currency.CurrencyName,
                CurrencySymbol = currency.CurrencySymbol,
                CountryName = currency.CountryName,
                Continent = currency.Continent,
                BiggestCoin = currency.BiggestCoin
            };
        }
    }
}