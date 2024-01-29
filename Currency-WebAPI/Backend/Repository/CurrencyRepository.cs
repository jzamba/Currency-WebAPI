using Homework03_project.Domain;
using Homework03_project.Repository;

namespace Homework03_project.Repository
{
    public class CurrencyRepository : ICurrencyRepository
    {

        private static List<Currency> _currency = new List<Currency>();

        public CurrencyRepository()
        {
            
        }
        public void CreateCurrency(Currency currency)
        {
            _currency.Add(currency);
        }

        public bool DeleteCurrency(int id)
        {
            var currencyToDelete = _currency.FirstOrDefault(a => a.Id == id);
            if (currencyToDelete == null)
            {
                return false;
            }
            else
            {
                _currency.Remove(currencyToDelete);
                return true;
            }
        }

        public IEnumerable<Currency> GetAllCurrencies()
        {
            return _currency;
        }

        public Currency GetCurrency(int id)
        {
            var currency = _currency.FirstOrDefault(a => a.Id == id);
            if(currency == null)
            {
                return null;
            }
            return currency;
        }

        public bool UpdateCurrency(int id, string currencyname)
        {
            var currencyToUpdate = _currency.FirstOrDefault(a => a.Id == id);
            if(currencyToUpdate != null)
            {
                currencyToUpdate.CurrencyName = currencyname;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
