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
        //private readonly Dictionary<string, SqlDependency> _dependencies;

        //public event EventHandler<DataChangedEventArgs> DataChanged;

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
            
            //_dependencies = new Dictionary<string, SqlDependency>();
            //SqlDependency.Start(_connectionString);
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


        //private void SetupSqlDependency(string functionName) //functionName is the name of a function that returns a table, or execute a SELECT statement.
        //{
        //    Connect();

        //    using (SqlCommand command = new SqlCommand($"SELECT * {functionName};", _connection))
        //    {           
        //        SqlDependency dependency = new SqlDependency(command);
        //        dependency.OnChange += (sender, e) => OnDependencyChange(sender, e, functionName);

        //        // Execute the command to establish the dependency
        //        using (command.ExecuteReader())
        //        {
        //            // Process the data if needed
        //        }

        //        // Store the dependency in the dictionary
        //        _dependencies[functionName] = dependency;
        //    }
        //}

        //private void OnDependencyChange(object sender, SqlNotificationEventArgs e, string functionName)
        //{
        //    Debug.WriteLine($"Data change detected for function {functionName}: {e.Info}");

        //    if (e.Info == SqlNotificationInfo.Insert || e.Info == SqlNotificationInfo.Update || e.Info == SqlNotificationInfo.Delete)
        //    {
        //        RefreshData(functionName);
        //    }

        //    // Re-establish dependency after change notification
        //    if (sender is SqlDependency dependency)
        //    {
        //        dependency.OnChange -= (s, ev) => OnDependencyChange(s, ev, functionName);
        //        _dependencies.Remove(functionName);
        //        SetupSqlDependency(functionName);
        //    }
        //}

        //private string GetFunctionNameByDependency(SqlDependency dependency)
        //{
        //    foreach (var kvp in _dependencies)
        //    {
        //        if (kvp.Value == dependency)
        //        {
        //            return kvp.Key;
        //        }
        //    }
        //    return null;
        //}

        //private void RefreshData(string functionName)
        //{
        //    var data = FetchData(functionName);
        //    OnDataChanged(new DataChangedEventArgs(functionName, data));
        //}

        //private DataTable FetchData(string functionName)
        //{
        //    using (SqlCommand command = new SqlCommand($"SELECT {functionName};", _connection))
        //    {
        //        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
        //        {
        //            DataTable dataTable = new DataTable();
        //            adapter.Fill(dataTable);
        //            return dataTable;
        //        }
        //    }
        //}

        //protected virtual void OnDataChanged(DataChangedEventArgs e)
        //{
        //    DataChanged?.Invoke(this, e);
        //}

        //public void TrackDataChanges(string functionName)
        //{
        //    SetupSqlDependency(functionName);
        //}

        //~DataProvider()
        //{
        //    // Stop SqlDependency when the object is destroyed
        //    SqlDependency.Stop(_connection.ConnectionString);
        //}

    }
}

