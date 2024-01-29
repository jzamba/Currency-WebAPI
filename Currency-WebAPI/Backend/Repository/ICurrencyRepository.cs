using Homework03_project.Domain;

namespace Homework03_project.Repository
{
    public interface ICurrencyRepository
    {
        public void CreateCurrency(Currency currency);
        public bool UpdateCurrency(int id, string currencyname);
        public IEnumerable<Currency> GetAllCurrencies();
        public Currency GetCurrency(int id);
        public bool DeleteCurrency(int id);
    }
}
