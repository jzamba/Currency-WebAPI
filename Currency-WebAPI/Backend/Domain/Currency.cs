namespace Homework03_project.Domain
{
    public class Currency
    {
        public int Id { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencySymbol { get; set; }
        public string CountryName { get; set; }
        public string Continent { get; set; }
        public string BiggestCoin { get; set; }

        public Currency(
        int id,
        string currencyname,
        string currencysymbol,
        string countryname,
        string continent,
        string biggestcoin)
        {
            Id = id;
            CurrencyName = currencyname;
            CurrencySymbol = currencysymbol;
            CountryName = countryname;
            Continent = continent;
            BiggestCoin = biggestcoin;
        }
        public Currency()
        {
            Id = 0;
            CurrencyName = "";
            CurrencySymbol = "";
            CountryName = "";
            Continent = "";
            BiggestCoin = "";
        }
    }
}
