using System;
using System.Collections.Generic;

namespace DL.Models;

public partial class GoodsDistribution
{
    public string PurchaseOrderId { get; set; } = null!;

    public string StoreId { get; set; } = null!;

    public string MaterialId { get; set; } = null!;

    public int? DistributedQuantity { get; set; }

    public DateTimeOffset? DistributedDateTime { get; set; }

    public virtual Material Material { get; set; } = null!;

    public virtual PurchaseOrder PurchaseOrder { get; set; } = null!;

    public virtual Store Store { get; set; } = null!;
}
