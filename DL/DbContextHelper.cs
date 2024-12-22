using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DL
{
    public class DbContextHelper
    {
        public static string GetConnectionString(string name)
        {
            ConfigurationManager manager = new ConfigurationManager();
            Dictionary<string, DatabaseConnection> connections;
            string? connectionString = null;

            try
            {
                connections = manager.GetDbConnectionString();
                foreach (var dbConnection in connections)
                {
                    if (dbConnection.Key == name)
                    {
                        connectionString = dbConnection.Value.ConnectionString;
                        break;
                    }
                }
            }
            catch(Exception)
            {
                throw;
            }

            return connectionString ?? throw new Exception("Connection string is null");
        }
    }
}
