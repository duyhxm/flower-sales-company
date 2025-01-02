using System;
using System.Collections.Generic;

namespace DL.Models;

public partial class AccessoryProfitRateHistory
{
    public string AccessoryProfitRateId { get; set; } = null!;

    public string AccessoryId { get; set; } = null!;

    public decimal? ProfitRate { get; set; }

    public virtual Accessory Accessory { get; set; } = null!;

    public virtual AccessoryProfitRate AccessoryProfitRate { get; set; } = null!;
}
