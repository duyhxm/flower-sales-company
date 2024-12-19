using System;
using System.Collections.Generic;

namespace DL.Models;

public partial class Accessory
{
    public string AccessoryId { get; set; } = null!;

    public virtual Material AccessoryNavigation { get; set; } = null!;

    public virtual ICollection<AccessoryProfitRateHistory> AccessoryProfitRateHistories { get; set; } = new List<AccessoryProfitRateHistory>();
}
