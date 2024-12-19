﻿using System;
using System.Collections.Generic;

namespace DL.Models;

public partial class FlowerSalesTargetHistory
{
    public int TargetId { get; set; }

    public string FlowerId { get; set; } = null!;

    public int? ExpectedQuantity { get; set; }

    public decimal? ProfitRate { get; set; }

    public virtual Flower Flower { get; set; } = null!;

    public virtual FlowerSalesTarget Target { get; set; } = null!;
}
