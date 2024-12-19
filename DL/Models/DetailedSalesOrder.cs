using System;
using System.Collections.Generic;

namespace DL.Models;

public partial class DetailedSalesOrder
{
    public string SalesOrderId { get; set; } = null!;

    public string ProductId { get; set; } = null!;

    public int? Quantity { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual SalesOrder SalesOrder { get; set; } = null!;
}
