using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Employee
    {
        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }

        public string JobTitleName { get; set; }

        public Employee(string employeeID, string employeeName, string jobTitleName)
        {
            EmployeeID = employeeID;
            EmployeeName = employeeName;
            JobTitleName = jobTitleName;
        }
    }
}
