using System;
using System.Collections.Generic;

namespace DL.Models;

public partial class ProductInventory
{
    public string StoreId { get; set; } = null!;

    public string ProductId { get; set; } = null!;

    public int? StockProductQuantity { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual Store Store { get; set; } = null!;
}
