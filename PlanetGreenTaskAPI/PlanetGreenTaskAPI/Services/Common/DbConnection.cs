using Microsoft.Data.Sqlite;
using PlanetGreenTaskAPI.Interfaces;

namespace PlanetGreenTaskAPI.Services.Common
{
    public class DbConnection
    {
        public SqliteConnection GetDbConnection()
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder();

            //Use DB in project directory.  If it does not exist, create it:
            connectionStringBuilder.DataSource = "./SqliteDB.db";
            var connection = new SqliteConnection(connectionStringBuilder.ConnectionString);
            return connection;
        }

    }
}
