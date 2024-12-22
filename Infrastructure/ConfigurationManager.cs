using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using DTO;

namespace Infrastructure
{
    public class ConfigurationManager
    {
        private readonly IConfiguration _configuration;

        public ConfigurationManager()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
        }

        public string GetServiceBusConnectionString()
        {
            string? connectionString = _configuration["ServiceBusConnectionString"];
            if (connectionString != null)
            {
                return connectionString;
            }
            else
                throw new Exception("Service bus connection string is null");
        }

        public Dictionary<string, DatabaseConnection> GetDbConnectionString()
        {
            try
            {
                return _configuration.GetSection("DbConnectionStrings").Get<Dictionary<string, DatabaseConnection>>() ?? throw new InvalidOperationException("Failed to retrieve the configuration section.");
            }
            catch(NullReferenceException)
            {
                throw;
            }
        }
    }
}
