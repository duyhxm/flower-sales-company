using System;
using System.Collections.Generic;

namespace DL.Models;

public partial class RevenueHistory
{
    public string RevenueId { get; set; } = null!;

    public decimal? ReportingMonth { get; set; }

    public decimal? ReportingYear { get; set; }

    public decimal? ExpectedFlowerRevenue { get; set; }

    public decimal? NetFlowerRevenue { get; set; }

    public decimal? NetSuppMaterialRevenue { get; set; }
}
