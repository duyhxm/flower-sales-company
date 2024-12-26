using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DTO.Employee;

namespace DL.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<LoginInformation> GetLoginInfoAsync(UserAccountDTO account);

        bool Login(UserAccountDTO account);
    }
}
