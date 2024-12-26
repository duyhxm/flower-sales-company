using DL.Repositories.Implementations;
using DTO;
using DTO.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class FTEmployeeService : IEmployeeService
    {
        EmployeeRepository _employeeRepository;

        public FTEmployeeService()
        {
            _employeeRepository = new EmployeeRepository();
        }

        public Task<LoginInformation> GetLoginInfoAsync(UserAccountDTO account)
        {
            throw new NotImplementedException();
        }

        public bool Login(UserAccountDTO account)
        {
            throw new NotImplementedException();
        }
    }
}
