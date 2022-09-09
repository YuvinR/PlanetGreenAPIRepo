using Microsoft.AspNetCore.Mvc;
using PlanetGreenTaskAPI.Interfaces;
using PlanetGreenTaskAPI.Models;
using PlanetGreenTaskAPI.Models.Common;
using PlanetGreenTaskAPI.Services.Common;
using System.Transactions;

namespace PlanetGreenTaskAPI.Services
{
    public class CurrencyExchangeHandlerService : ICurrencyExchangeHandlerService
    {
        public async Task<ResponseModel> SaveExchangeCurrencies(CurrencyBaseModel exchangeRateModel)
        {
            DbConnection dbConnection = new DbConnection();
            using (var connection = dbConnection.GetDbConnection())
            {

                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var insertCmd = connection.CreateCommand();
                        insertCmd.CommandText = "INSERT INTO CurrencyMaster (Name, Code) VALUES(@Name,@Code)";

                        insertCmd.Parameters.AddWithValue("@Name", exchangeRateModel.Name);
                        insertCmd.Parameters.AddWithValue("@Code", exchangeRateModel.Code);

                        insertCmd.ExecuteNonQuery();
                        transaction.Commit();
                        var res = new ResponseModel { IsSuccess = true, Data = "Success" };
                        return res;

                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        var res = new ResponseModel { IsSuccess = false, Data = "Error" };
                        return res;
                    }
                }
            }
        }

        public async Task<ResponseModel> SaveExchangeRate(CurrencyExchangeRateModel exchangeRateModel)
        {
            DbConnection dbConnection = new DbConnection();
            using (var connection = dbConnection.GetDbConnection())
            {

                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var insertCmd = connection.CreateCommand();
                        insertCmd.CommandText = "INSERT INTO ExchangeRate (FromCurrencyCode, ToCurrencyCode,Value) VALUES(@FromCurrencyCode,@ToCurrencyCode,@Value)";

                        insertCmd.Parameters.AddWithValue("@FromCurrencyCode", exchangeRateModel.FromCurrencyCode);
                        insertCmd.Parameters.AddWithValue("@ToCurrencyCode", exchangeRateModel.ToCurrencyCode);
                        insertCmd.Parameters.AddWithValue("@Value", exchangeRateModel.Value);

                        insertCmd.ExecuteNonQuery();
                        transaction.Commit();
                        var res = new ResponseModel { IsSuccess = true, Data = "Success" };
                        return res;

                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        var res = new ResponseModel { IsSuccess = false, Data = "Error" };
                        return res;
                    }
                }
            }
        }

        public async Task<ResponseModel> UpdateExchangeRate(CurrencyExchangeRateModel exchangeRateModel)
        {
            DbConnection dbConnection = new DbConnection();
            using (var connection = dbConnection.GetDbConnection())
            {

                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var insertCmd = connection.CreateCommand();
                        insertCmd.CommandText = "UPDATE ExchangeRate SET Value = @Value WHERE FromCurrencyCode = @FromCurrencyCode AND ToCurrencyCode =@ToCurrencyCode";

                        insertCmd.Parameters.AddWithValue("@FromCurrencyCode", exchangeRateModel.FromCurrencyCode);
                        insertCmd.Parameters.AddWithValue("@ToCurrencyCode", exchangeRateModel.ToCurrencyCode);
                        insertCmd.Parameters.AddWithValue("@Value", exchangeRateModel.Value);

                        insertCmd.ExecuteNonQuery();
                        transaction.Commit();
                        var res = new ResponseModel { IsSuccess = true, Data = "Success" };
                        return res;

                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        var res = new ResponseModel { IsSuccess = false, Data = "Error" };
                        return res;
                    }
                }
            }
        }

        public async Task<ResponseModel> GetExchangeRate(ExchangeRateRequestModel exchangeRateModel)
        {
            //Read the newly inserted data:
            DbConnection dbConnection = new DbConnection();
            List<CurrencyExchangeRateModel> model = new List<CurrencyExchangeRateModel>();

            using (var connection = dbConnection.GetDbConnection())
            {
                var selectCmd = connection.CreateCommand();
                selectCmd.CommandText = "SELECT FromCurrencyCode,ToCurrencyCode,Value FROM ExchangeRate WHERE FromCurrencyCode =@FromCurrencyCode AND ToCurrencyCode =@ToCurrencyCode";
                selectCmd.Parameters.AddWithValue("@FromCurrencyCode", exchangeRateModel.FromCurrencyCode);
                selectCmd.Parameters.AddWithValue("@ToCurrencyCode", exchangeRateModel.ToCurrencyCode);

                connection.Open();
                using (var reader = selectCmd.ExecuteReader())
                {


                    while (reader.Read())
                    {
                        var from = reader.GetString(0);
                        var to = reader.GetString(1);
                        var value = reader.GetDecimal(2);
                        model.Add(new CurrencyExchangeRateModel { FromCurrencyCode = from, ToCurrencyCode = to, Value = value });

                    }

                }
            }
            var res = new ResponseModel { IsSuccess = true, Data = model };
            return res;
        }
    }


}

