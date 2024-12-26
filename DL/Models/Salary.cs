using System;
using System.Collections.Generic;

namespace DL.Models;

public partial class Salary
{
    public string SalaryId { get; set; } = null!;

    public decimal? BaseSalary { get; set; }

    public decimal? SalaryCoefficient { get; set; }

    public virtual ICollection<FTEmployee> Ftemployees { get; set; } = new List<FTEmployee>();
}
