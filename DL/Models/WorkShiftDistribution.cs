using System;
using System.Collections.Generic;

namespace DL.Models;

public partial class WorkShiftDistribution
{
    public string PtemployeeId { get; set; } = null!;

    public string WorkShiftId { get; set; } = null!;

    public DateOnly WorkDate { get; set; }

    public bool? Absence { get; set; }

    public virtual Ptemployee Ptemployee { get; set; } = null!;

    public virtual WorkShift WorkShift { get; set; } = null!;
}
