using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL.Repositories.Implementations;
using DTO.Employee;

namespace BL
{
    public class PTEmployeeService : IEmployeeService
    {
        EmployeeRepository _employeeRepository;

        public PTEmployeeService()
        {
            _employeeRepository = new EmployeeRepository();
        }

        public async Task<LoginInformation> GetLoginInfoAsync(UserAccountDTO account)
        {
            try
            {
                return await _employeeRepository.GetLoginInfoAsync(account);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Login(UserAccountDTO account)
        {
            try
            {
                return _employeeRepository.Login(account);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string?> GetStoreID(string ptEmployeeID)
        {
            try
            {
                return await _employeeRepository.GetStoreID(ptEmployeeID);
            }
            catch (Exception)
            {
                throw;
            }
        }
        
    }
}
