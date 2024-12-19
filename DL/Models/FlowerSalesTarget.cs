using System;
using System.Collections.Generic;

namespace DL.Models;

public partial class FlowerSalesTarget
{
    public int TargetId { get; set; }

    public decimal? ApplyMonth { get; set; }

    public decimal? ApplyYear { get; set; }

    public string? UsageStatus { get; set; }

    public virtual ICollection<FlowerSalesTargetHistory> FlowerSalesTargetHistories { get; set; } = new List<FlowerSalesTargetHistory>();
}
