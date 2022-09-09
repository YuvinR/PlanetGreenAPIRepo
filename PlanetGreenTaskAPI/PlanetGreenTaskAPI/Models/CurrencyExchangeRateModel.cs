namespace PlanetGreenTaskAPI.Models
{
    public class CurrencyExchangeRateModel
    {
        public string FromCurrencyCode { get; set; }
        public string ToCurrencyCode { get; set; }
        public decimal Value { get; set; }

    }
}
