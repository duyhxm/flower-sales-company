using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Microsoft.Data.SqlClient;
using System.Data;


namespace DL
{
    public class LoginDL : DataProvider
    {
        public bool Login(UserAccount account)
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
            catch(Exception ex)
            {
                throw;
            }
        }

        public Dictionary<string, string> GetAdditionalInfo(UserAccount account)
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

                        info.Add("EmployeeID", employeeID);
                        info.Add("EmployeeName", employeeName);
                        info.Add("JobTitleName", jobTitleName);
                        info.Add("AccessibleFormName", formName);
                    }
                }    
            }
            catch (Exception ex)
            {
                throw new Exception("Error while fetching additional info", ex);
            }
            finally
            {
                Disconnect();
            }
            
            return info;
        }
    }
}
