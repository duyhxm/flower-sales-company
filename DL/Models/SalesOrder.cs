using System;
using System.Collections.Generic;

namespace DL.Models;

public partial class SalesOrder
{
    public string SalesOrderId { get; set; } = null!;

    public string? CustomerId { get; set; }

    public string? StoreId { get; set; }

    public DateTimeOffset? CreatedDateTime { get; set; }

    public string? OrderStatus { get; set; }

    public string? OrderType { get; set; }

    public string? PurchaseMethod { get; set; }

    public decimal? BasePrice { get; set; }

    public decimal? FinalPrice { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<DetailedSalesOrder> DetailedSalesOrders { get; set; } = new List<DetailedSalesOrder>();

    public virtual ImmediateSalesOrder? ImmediateSalesOrder { get; set; }

    public virtual PreSalesOrder? PreSalesOrder { get; set; }

    public virtual ICollection<ShippingInformation> ShippingInformations { get; set; } = new List<ShippingInformation>();

    public virtual Store? Store { get; set; }

    public virtual ICollection<UsedPromotionHistory> UsedPromotionHistories { get; set; } = new List<UsedPromotionHistory>();
}
