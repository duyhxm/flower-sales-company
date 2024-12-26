using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Employee;

namespace DL.Repositories.Interfaces
{
    public interface ISystemRepository
    {
        Task<UserAccountDTO?> LoginAsync(UserAccountDTO userAccount);
    }
}
