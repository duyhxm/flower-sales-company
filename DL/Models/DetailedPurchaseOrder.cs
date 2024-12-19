using System;
using System.Collections.Generic;

namespace DL.Models;

public partial class DetailedPurchaseOrder
{
    public string PurchaseOrderId { get; set; } = null!;

    public string MaterialId { get; set; } = null!;

    public decimal? CostPrice { get; set; }

    public int? Quantity { get; set; }

    public virtual Material Material { get; set; } = null!;

    public virtual PurchaseOrder PurchaseOrder { get; set; } = null!;
}
