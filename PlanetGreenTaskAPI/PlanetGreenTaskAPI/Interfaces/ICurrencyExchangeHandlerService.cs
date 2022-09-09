using Microsoft.AspNetCore.Mvc;
using PlanetGreenTaskAPI.Models;
using PlanetGreenTaskAPI.Models.Common;

namespace PlanetGreenTaskAPI.Interfaces
{
    public interface ICurrencyExchangeHandlerService
    {
        public Task<ResponseModel> SaveExchangeCurrencies(CurrencyBaseModel exchangeRateModel);
        public Task<ResponseModel> SaveExchangeRate(CurrencyExchangeRateModel exchangeRateModel);
        public Task<ResponseModel> UpdateExchangeRate(CurrencyExchangeRateModel exchangeRateModel);
        public Task<ResponseModel> GetExchangeRate(ExchangeRateRequestModel exchangeRateModel);
    }
}
