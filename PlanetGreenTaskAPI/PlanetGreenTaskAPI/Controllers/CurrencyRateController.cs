using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PlanetGreenTaskAPI.Interfaces;
using PlanetGreenTaskAPI.Models;
using PlanetGreenTaskAPI.Models.Common;

namespace PlanetGreenTaskAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyRateController : ControllerBase
    {
        public ICurrencyExchangeHandlerService currencyExchangeHandlerService { get; }
        public  CurrencyRateController(ICurrencyExchangeHandlerService currencyExchangeHandlerService)
        {
            this.currencyExchangeHandlerService = currencyExchangeHandlerService;
        }

        
        [Authorize]
        [HttpPost]
        [Route("SaveCurrency")]
        public async Task<ResponseModel> SaveCurrency(CurrencyBaseModel exchangeRateModel)
        {
            var res = await currencyExchangeHandlerService.SaveExchangeCurrencies(exchangeRateModel);
            return res;
           
        }

        [Authorize]
        [HttpPost]
        [Route("SaveCurrencyExchangeRate")]
        public async Task<ResponseModel> SaveCurrencyExchangeRate(CurrencyExchangeRateModel exchangeRateModel)
        {
            var res = await currencyExchangeHandlerService.SaveExchangeRate(exchangeRateModel);
            return res;

        }

        [Authorize]
        [HttpPost]
        [Route("UpdateCurrencyExchangeRate")]
        public async Task<ResponseModel> UpdateCurrencyExchangeRate(CurrencyExchangeRateModel exchangeRateModel)
        {
            var res = await currencyExchangeHandlerService.UpdateExchangeRate(exchangeRateModel);
            return res;

        }

        [Authorize]
        [HttpPost]
        [Route("GetCurrencyExchangeRate")]
        public async Task<ResponseModel> GetCurrencyExchangeRate(ExchangeRateRequestModel requestModel)
        {
            var res = await currencyExchangeHandlerService.GetExchangeRate(requestModel);
            return res;

        }


    }
}
