using System;
using System.Collections.Generic;

namespace DL.Models;

public partial class Leave
{
    public string Leave1 { get; set; } = null!;

    public string? FtemployeeId { get; set; }

    public string? Reason { get; set; }

    public byte? LeaveDays { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public virtual Ftemployee? Ftemployee { get; set; }
}
