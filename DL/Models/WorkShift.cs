using System;
using System.Collections.Generic;

namespace DL.Models;

public partial class WorkShift
{
    public string WorkShiftId { get; set; } = null!;

    public string? WorkShiftName { get; set; }

    public TimeOnly? StartTime { get; set; }

    public TimeOnly? EndTime { get; set; }

    public decimal? BaseSalary { get; set; }

    public decimal? SalaryCoefficient { get; set; }

    public virtual ICollection<WorkShiftDistribution> WorkShiftDistributions { get; set; } = new List<WorkShiftDistribution>();
}
