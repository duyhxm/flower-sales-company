using System;
using System.Collections.Generic;

namespace DL.Models;

public partial class EmployeeAllowance
{
    public string EmployeeId { get; set; } = null!;

    public string AllowanceId { get; set; } = null!;

    public DateOnly? ReceivedDate { get; set; }

    public virtual Allowance Allowance { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;
}
