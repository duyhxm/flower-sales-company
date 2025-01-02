using System;
using System.Collections.Generic;

namespace DL.Models;

public partial class Payroll
{
    public string PeriodId { get; set; } = null!;

    public decimal? PayrollMonth { get; set; }

    public decimal? PayrollYear { get; set; }

    public virtual ICollection<EmployeePayrollHistory> EmployeePayrollHistories { get; set; } = new List<EmployeePayrollHistory>();
}
