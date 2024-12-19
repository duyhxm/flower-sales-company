using System;
using System.Collections.Generic;

namespace DL.Models;

public partial class OrderPromotionLevel
{
    public string OplevelId { get; set; } = null!;

    public decimal? Discount { get; set; }

    public decimal? MininumBasePrice { get; set; }

    public decimal? MaximumDiscountValue { get; set; }

    public virtual ICollection<Promotion> Promotions { get; set; } = new List<Promotion>();
}
