using System;
using System.Collections.Generic;

namespace DL.Models;

public partial class Allowance
{
    public string AllowanceId { get; set; } = null!;

    public string? AllowanceName { get; set; }

    public decimal? Amount { get; set; }

    public virtual ICollection<EmployeeAllowance> EmployeeAllowances { get; set; } = new List<EmployeeAllowance>();
}
