using System;
using System.Collections.Generic;

namespace DL.Models;

public partial class UsedPromotionHistory
{
    public string PromotionId { get; set; } = null!;

    public string SalesOrderId { get; set; } = null!;

    public decimal? OrderDiscountValue { get; set; }

    public decimal? CustomerDiscountValue { get; set; }

    public virtual Promotion Promotion { get; set; } = null!;

    public virtual SalesOrder SalesOrder { get; set; } = null!;
}
