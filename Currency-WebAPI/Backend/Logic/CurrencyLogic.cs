using Homework03_project.Exceptions;
using Homework03_project.Repository;
using Microsoft.Extensions.Options;
using Homework03_project.Controllers;
using Homework03_project.Logic;
using Homework03_project.Configuration;
using Homework03_project.Domain;
using System.Reflection;
using System.Text.RegularExpressions;


namespace Homework03_project.Logic
{

    public class CurrencyLogic : ICurrencyLogic
    {
        private readonly ICurrencyRepository _currencyRepository;
        private readonly ValidationConfiguration _validationConfiguration;

        public CurrencyLogic(ICurrencyRepository currencyRepository, IOptions<ValidationConfiguration> configuration)
        {
            _currencyRepository = currencyRepository;
            _validationConfiguration = configuration.Value;
        }

        private void ValidateCurrencyNameField(string? currencyname)
        {
            if (currencyname is null)
            {
                throw new UserErrorMessage("CurrencyName field cannot be empty.");
            }

            if (currencyname.Length > _validationConfiguration.CurrencyNameMaxCharacters)
            {
                throw new UserErrorMessage($"CurrencyName field too long. Exceeded {_validationConfiguration.CurrencyNameMaxCharacters} characters");
            }

            if (!Regex.IsMatch(currencyname, _validationConfiguration.CurrencyRegex))
            {
                throw new UserErrorMessage($"Currency format invalid for currencyname '{currencyname}'");
            }
        }

        private void ValidateCountryField(string? country)
        {
            if (string.IsNullOrEmpty(country))
            {
                throw new UserErrorMessage("Currency country cannot be empty.");
            }

            if (country.Length > _validationConfiguration.CountryMaxCharacters)
            {
                throw new UserErrorMessage($"Country field too long. Exceeded {_validationConfiguration.CountryMaxCharacters} characters");
            }

        }

        private void ValidateContinentField(string? continent)
        {
            if (continent is not null && continent.Length > _validationConfiguration.ContinentMaxCharacters)
            {
                throw new UserErrorMessage($"Continent field too long. Exceeded {_validationConfiguration.ContinentMaxCharacters} characters");
            }
        }

        private void ValidateCurrencySymbolField(string? currencysymbol)
        {
            if (currencysymbol is null)
            {
                throw new UserErrorMessage("CurrencySymbol field cannot be empty.");
            }

            if (currencysymbol.Length > _validationConfiguration.CurrencySymbolMaxCharacters)
            {
                throw new UserErrorMessage($"CurrencySymbol field too long. Exceeded {_validationConfiguration.CurrencySymbolMaxCharacters} characters");
            }

            if (!Regex.IsMatch(currencysymbol, _validationConfiguration.CurrencyRegex))
            {
                throw new UserErrorMessage($"Currency format invalid for currencysymbol '{currencysymbol}'");
            }
        }


        public void CreateNewCurrency(Currency? currency)
        {
            // Check all arguments
            if (currency is null)
            {
                throw new UserErrorMessage("Cannot create a new mail. No mail specified or the mail is invalid.");
            }

            

            // Continent CAN be empty, just make sure it is not null
            if (currency.Continent is null)
            {
                throw new Exception ();
            }

            ValidateContinentField(currency.Continent);
            ValidateCurrencyNameField(currency.CurrencyName);
            ValidateCurrencySymbolField(currency.CurrencySymbol);

            // All fields validated, continue...

            // Set currency timestamp to current time
            // (use UTC for cross-timezone compatibility)
           

            _currencyRepository.CreateCurrency(currency);
        }

        public void UpdateCurrency(int id, Currency? currency)
        {
            // Check all arguments
            if (currency is null)
            {
                throw new UserErrorMessage("Cannot create a new mail. No mail specified or the mail is invalid.");
            }

            // Sanitize inputs
            currency.Id = -1;

            // Continent CAN be empty, just make sure it is not null
            if (currency.Continent is null)
            {
                currency.Continent = string.Empty;
            }

            

            ValidateCountryField(currency.CountryName);
            ValidateContinentField(currency.Continent);
            ValidateCurrencyNameField(currency.CurrencyName);
            ValidateCurrencySymbolField(currency.CurrencySymbol);

            // All fields validated, continue...

            _currencyRepository.UpdateCurrency(id, currency);
        }

        public void DeleteCurrency(int id)
        {
            _currencyRepository.DeleteCurrency(id);
        }

        public Currency? GetCurrency(int id)
        {
            return _currencyRepository.GetCurrency(id);
        }

        public IEnumerable<Currency> GetCurrencies()
        {
            return _currencyRepository.GetAllCurrencies();
        }
    }
}
