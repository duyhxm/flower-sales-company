using System;
using System.Collections.Generic;

namespace DL.Models;

public partial class AccessoryProfitRateHistory
{
    public int AccessoryProfitRateId { get; set; }

    public string AccessoryId { get; set; } = null!;

    public decimal? ProfitRate { get; set; }

    public virtual Accessory Accessory { get; set; } = null!;

    public virtual AccessoryProfitRate AccessoryProfitRate { get; set; } = null!;
}
