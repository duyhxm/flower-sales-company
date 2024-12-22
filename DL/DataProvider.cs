using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Diagnostics;

namespace DL
{
    public class DataProvider
    {
        private readonly SqlConnection _connection;
        private readonly string _connectionString;

        public DataProvider()
        {
            try
            {
                _connectionString = ConfigurationManager.ConnectionStrings["OnPremisesSQLServer"].ConnectionString;
                _connection = new SqlConnection(_connectionString);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public SqlCommand CreateCommand()
        {
            return new SqlCommand(_connectionString, _connection);
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

        public Object MyExecuteScalar(string query, SqlCommand command)
        {
            Connect();
            try
            {
                using (command)
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = query;

                    return command.ExecuteScalar();
                }
            }
            catch (SqlException)
            {
                throw;
            }
            finally
            {
                Disconnect();
            }
        }

        public int MyExecuteNonQuery(string storedProcedureName)
        {
            Connect();

            try
            {
                using (SqlCommand command = new SqlCommand(_connectionString, _connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = storedProcedureName;

                    return command.ExecuteNonQuery();
                }
            }
            catch(SqlException)
            {
                throw;
            }
            finally
            {
                Disconnect();
            }
        }

        public SqlDataReader MyExecuteReader(string query, SqlCommand command)
        {
            try
            {
                using (command)
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = query;

                    return command.ExecuteReader();
                }
            }
            catch(SqlException)
            {
                throw;
            }
        }
    }
}

