using Microsoft.Data.Sqlite;
using PlanetGreenTaskAPI.Services.Common;
using System.Data;

namespace PlanetGreenTaskAPI.Services
{
    public class ExtensionService
    {

        public void InitiateDb()
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder();

            //Use DB in project directory.  If it does not exist, create it:
            //connectionStringBuilder.DataSource = "./SqliteDB.db";
            DbConnection dbConnection = new DbConnection();

            using (var connection = dbConnection.GetDbConnection())
            {
                connection.Open();

                //Create a table (drop if already exists first):

                var hasrowstable1 = false;
                var hasrowstable2 = false;

                //Read the newly inserted data:
                var existCmd1 = connection.CreateCommand();
                existCmd1.CommandText = "SELECT name FROM sqlite_master WHERE type='table' AND name='CurrencyMaster';";

                using (var reader = existCmd1.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        hasrowstable1 = true;
                    }

                }

                var existCmd2 = connection.CreateCommand();
                existCmd2.CommandText = "SELECT name FROM sqlite_master WHERE type='table' AND name='ExchangeRate';";

                using (var reader = existCmd2.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        hasrowstable2 = true;
                    }

                }

                if (!hasrowstable1)
                {
                    var createTableCmd = connection.CreateCommand();
                    createTableCmd.CommandText = "CREATE TABLE CurrencyMaster(CurrencyMasterID INTEGER  PRIMARY KEY autoincrement,Name VARCHAR(50),Code VARCHAR(5))";
                    createTableCmd.ExecuteNonQuery();



                    //Seed some data:
                    using (var transaction = connection.BeginTransaction())
                    {
                        var insertCmd = connection.CreateCommand();

                        insertCmd.CommandText = "INSERT INTO CurrencyMaster (Name, Code) VALUES('USD',0001)";
                        insertCmd.ExecuteNonQuery();

                        insertCmd.CommandText = "INSERT INTO CurrencyMaster (Name, Code) VALUES('LKR',0002)";
                        insertCmd.ExecuteNonQuery();

                        insertCmd.CommandText = "INSERT INTO CurrencyMaster (Name, Code) VALUES('IND',0003)";
                        insertCmd.ExecuteNonQuery();

                        transaction.Commit();
                    }

                }
                if (!hasrowstable2)
                {
                    var createTableCmd1 = connection.CreateCommand();
                    createTableCmd1.CommandText = "CREATE TABLE ExchangeRate(Id INTEGER  PRIMARY KEY autoincrement,FromCurrencyCode VARCHAR(5),ToCurrencyCode VARCHAR(5),Value DECIMAL)";
                    createTableCmd1.ExecuteNonQuery();


                    //Seed some data:
                    using (var transaction = connection.BeginTransaction())
                    {
                        var insertCmd = connection.CreateCommand();

                        insertCmd.CommandText = "INSERT INTO ExchangeRate (FromCurrencyCode, ToCurrencyCode,Value) VALUES('USD','LKR',360)";
                        insertCmd.ExecuteNonQuery();

                        insertCmd.CommandText = "INSERT INTO ExchangeRate (FromCurrencyCode, ToCurrencyCode,Value) VALUES('LKR','USD',0.360)";
                        insertCmd.ExecuteNonQuery();

                        insertCmd.CommandText = "INSERT INTO ExchangeRate (FromCurrencyCode, ToCurrencyCode,Value) VALUES('AED','LKR',97)";
                        insertCmd.ExecuteNonQuery();

                        insertCmd.CommandText = "INSERT INTO ExchangeRate (FromCurrencyCode, ToCurrencyCode,Value) VALUES('LKR','AED',0.97)";
                        insertCmd.ExecuteNonQuery();

                        transaction.Commit();
                    }
                }

        }
    }
}
}
