using System;
using System.Collections.Generic;

namespace DL.Models;

public partial class EmployeePayrollHistory
{
    public string PeriodId { get; set; } = null!;

    public string EmployeeId { get; set; } = null!;

    public byte? PracticalWorkDays { get; set; }

    public byte? PracticalWorkShifts { get; set; }

    public decimal? TotalAllowance { get; set; }

    public decimal? TotalBonus { get; set; }

    public decimal? Income { get; set; }

    public string? TaxRateId { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual Payroll Period { get; set; } = null!;

    public virtual TaxRate? TaxRate { get; set; }
}
