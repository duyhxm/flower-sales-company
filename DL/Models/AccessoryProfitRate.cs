using System;
using System.Collections.Generic;

namespace DL.Models;

public partial class AccessoryProfitRate
{
    public string AccessoryProfitRateId { get; set; } = null!;

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public string? UsageStatus { get; set; }

    public virtual ICollection<AccessoryProfitRateHistory> AccessoryProfitRateHistories { get; set; } = new List<AccessoryProfitRateHistory>();
}
