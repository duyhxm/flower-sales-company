using System;
using System.Collections.Generic;

namespace DL.Models;

public partial class CustomerPromotionHistory
{
    public string PromotionId { get; set; } = null!;

    public string CustomerRankId { get; set; } = null!;

    public decimal? Discount { get; set; }

    public decimal? MinimumBasePrice { get; set; }

    public decimal? MaximumDiscountValue { get; set; }

    public virtual CustomerRank CustomerRank { get; set; } = null!;

    public virtual Promotion Promotion { get; set; } = null!;
}
