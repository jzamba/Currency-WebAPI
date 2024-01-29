namespace Homework03_project.Configuration
{
    
        public class ValidationConfiguration
        {
            public int CurrencyNameMaxCharacters { get; set; }
            public int CurrencySymbolMaxCharacters { get; set; }
            public int ContinentMaxCharacters { get; set; }

            public int CountryMaxCharacters { get; set; }
            public string CurrencyRegex { get; set; }
        }
    
}
