using System;
using System.Collections.Generic;

namespace DL.Models;

public partial class TaxRate
{
    public string TaxRateId { get; set; } = null!;

    public string? TaxTypeId { get; set; }

    public decimal? Rate { get; set; }

    public string? ConditionDescription { get; set; }

    public virtual ICollection<EmployeePayrollHistory> EmployeePayrollHistories { get; set; } = new List<EmployeePayrollHistory>();

    public virtual TaxType? TaxType { get; set; }
}
