using System;
using System.Collections.Generic;

namespace DL.Models;

public partial class Material
{
    public string MaterialId { get; set; } = null!;

    public string? MaterialName { get; set; }

    public string? MaterialType { get; set; }

    public string? Unit { get; set; }

    public virtual Accessory? Accessory { get; set; }

    public virtual ICollection<DetailedProduct> DetailedProducts { get; set; } = new List<DetailedProduct>();

    public virtual ICollection<DetailedPurchaseOrder> DetailedPurchaseOrders { get; set; } = new List<DetailedPurchaseOrder>();

    public virtual Flower? Flower { get; set; }

    public virtual ICollection<GoodsDistribution> GoodsDistributions { get; set; } = new List<GoodsDistribution>();

    public virtual ICollection<MaterialInventory> MaterialInventories { get; set; } = new List<MaterialInventory>();
}
