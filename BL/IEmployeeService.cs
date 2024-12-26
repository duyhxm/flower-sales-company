using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DTO.Employee;

namespace BL
{
    public interface IEmployeeService
    {
        bool Login(UserAccountDTO account);

        Task<LoginInformation> GetLoginInfoAsync(UserAccountDTO account);
    }
}
