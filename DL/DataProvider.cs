using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Diagnostics;

namespace DL
{
    public class DataProvider
    {
        private readonly SqlConnection _connection;

        public DataProvider()
        {
            //Create configuration for .json file
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Retrieve the connection string, prioritizing the environment variable
            string connectionString = configuration.GetConnectionString("MyConnectionString");

            _connection = new SqlConnection(connectionString);

            Connect();
        }

        public void Connect()
        {
            if(_connection != null && _connection.State == System.Data.ConnectionState.Closed)
            {
                _connection.Open();
            }
        }

        public void Disconnect()
        {
            if (_connection != null && _connection.State == System.Data.ConnectionState.Open)
            {
                _connection.Close();
            }
        }
    }
}
