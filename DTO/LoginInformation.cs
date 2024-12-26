using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Employee;

namespace DTO
{
    public class LoginInformation
    {
        public UserAccountDTO UserAccount { get; set; }
        public string JobTitle { get; set; }
        public string AccessibleForm { get; set; }
        public string? StoreID { get; set; }
        public string? StoreName { get; set; }

    }
}
