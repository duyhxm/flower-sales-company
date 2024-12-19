using System;
using System.Collections.Generic;

namespace DL.Models;

public partial class PurchaseOrder
{
    public string PurchaseOrderId { get; set; } = null!;

    public string? VendorId { get; set; }

    public string? OrderType { get; set; }

    public DateTimeOffset? PurchasedDateTime { get; set; }

    public decimal? TotalCost { get; set; }

    public virtual ICollection<DetailedPurchaseOrder> DetailedPurchaseOrders { get; set; } = new List<DetailedPurchaseOrder>();

    public virtual ICollection<GoodsDistribution> GoodsDistributions { get; set; } = new List<GoodsDistribution>();

    public virtual Vendor? Vendor { get; set; }
}
