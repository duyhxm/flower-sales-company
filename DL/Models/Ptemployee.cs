using System;
using System.Collections.Generic;

namespace DL.Models;

public partial class Ptemployee
{
    public string PtemployeeId { get; set; } = null!;

    public string? StoreId { get; set; }

    public virtual Employee PtemployeeNavigation { get; set; } = null!;

    public virtual Store? Store { get; set; }

    public virtual ICollection<WorkShiftDistribution> WorkShiftDistributions { get; set; } = new List<WorkShiftDistribution>();
}
