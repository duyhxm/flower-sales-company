﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Employee
{
    public class EmployeeDTO
    {
        public string EmployeeId { get; set; } = null!;

        public string? LastName { get; set; }

        public string? MiddleName { get; set; }

        public string? FirstName { get; set; }

        public string? WorkType { get; set; }
    }
}
