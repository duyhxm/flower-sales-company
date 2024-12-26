using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DL.Models;
using DL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using DTO.Employee;

namespace DL.Repositories.Implementations
{
    public class EmployeeRepository : IEmployeeRepository
    {
        FlowerSalesCompanyDbContext _context;

        public EmployeeRepository()
        {
            _context = new FlowerSalesCompanyDbContext();
        }

        public async Task<LoginInformation> GetLoginInfoAsync(UserAccountDTO account)
        {
            try
            {
                var loginInfo = await _context.Set<LoginInformation>()
                                .FromSqlInterpolated($"SELECT * FROM dbo.FnGetLoginInfo({account.Username}, {account.Password})")
                                .FirstOrDefaultAsync();

                return loginInfo;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string?> GetStoreID(string ptEmployeeID)
        {
            var storeId = await (from e in _context.Ptemployees
                                 where e.PtemployeeId == ptEmployeeID
                                 select e.StoreId).FirstOrDefaultAsync();

            return storeId?.ToString();
        }

        public bool Login(UserAccountDTO account)
        {
            UserAccount? result;

            try
            {
                result = _context.UserAccounts.Find(account.Username);
            }
            catch (Exception)
            {
                throw;
            }

            if (result != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string? GetJobTitle(string employeeID)
        {
            string? jobTitle = null;

            try
            {
                jobTitle = (from ejt in _context.EmployeeJobTitles
                            where ejt.EmployeeId == employeeID && ejt.JobTitleStatus == "đang làm"
                            join jt in _context.JobTitles
                            on ejt.JobTitleId equals jt.JobTitleId
                            select jt.JobTitleName).FirstOrDefault();

                return jobTitle;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
