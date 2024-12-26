using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;
using DTO.Store;
using DTO.Employee;


namespace DL
{
    public class LoginDL : DataProvider
    {
        public bool Login(UserAccountDTO account)
        {
            try
            {
                string query = @"SELECT dbo.fn_CheckUserAccount(@username, @password);";
                SqlCommand command = CreateCommand();

                command.Parameters.AddRange(new SqlParameter []
                    {
                        new SqlParameter("@username", SqlDbType.VarChar, 20) {Value = account.Username },

                        new SqlParameter("@password", SqlDbType.VarChar, 20) {Value = account.Password }
                    }
                );

                bool result = (bool)MyExecuteScalar(query, command);

                return result;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public Dictionary<string, string> GetAdditionalInfo(UserAccountDTO account)
        {
            Dictionary<string, string> info = new Dictionary<string, string>();

            string query = @"SELECT *
                             FROM dbo.fn_GetAdditionalInfo(@username, @password);";

            SqlCommand command = CreateCommand();

            command.Parameters.AddRange(new SqlParameter[]
                    {
                        new SqlParameter("@username", SqlDbType.VarChar, 20) {Value = account.Username },

                        new SqlParameter("@password", SqlDbType.VarChar, 20) {Value = account.Password }
                    }
            );

            try
            {
                Connect();
                using (SqlDataReader dr = MyExecuteReader(query, command))
                {
                    while (dr.Read())
                    {
                        string employeeID = dr.GetString(0);
                        string employeeName = dr.GetString(1);
                        string jobTitleName = dr.GetString(2);
                        string formName = dr.GetString(3);

                        info.Add("EmployeeId", employeeID);
                        info.Add("FullName", employeeName);
                        info.Add("JobTitle", jobTitleName);
                        info.Add("AccessibleFormName", formName);
                    }
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
            
            return info;
        }

        public StoreDTO GetStoreInformation(string employeeId)
        {
            return new StoreDTO();
        }
    }
}
