using Homework03_project.Domain;

namespace Homework03_project.Logic
{
    
    public interface ICurrencyLogic
    {
        void CreateNewCurrency(Currency? currency);
        void DeleteCurrency(int id);
        Currency? GetCurrency(int id);
        IEnumerable<Currency> GetCurrencies();
        void UpdateCurrency(int id, Currency? currency);
    }

}
