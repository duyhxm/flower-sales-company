using System;
using System.Collections.Generic;

namespace DL.Models;

public partial class MaterialInventory
{
    public string StoreId { get; set; } = null!;

    public string MaterialId { get; set; } = null!;

    public int? StockMaterialQuantity { get; set; }

    public virtual Material Material { get; set; } = null!;

    public virtual Store Store { get; set; } = null!;
}
