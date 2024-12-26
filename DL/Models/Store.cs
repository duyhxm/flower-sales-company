using System;
using System.Collections.Generic;

namespace DL.Models;

public partial class Store
{
    public string StoreId { get; set; } = null!;

    public string? StoreName { get; set; }

    public string? StoreAddress { get; set; }

    public string? RegionId { get; set; }

    public string? ManagerId { get; set; }

    public virtual ICollection<GoodsDistribution> GoodsDistributions { get; set; } = new List<GoodsDistribution>();

    public virtual FTEmployee? Manager { get; set; }

    public virtual ICollection<MaterialInventory> MaterialInventories { get; set; } = new List<MaterialInventory>();

    public virtual ICollection<ProductCreationPlanHistory> ProductCreationPlanHistories { get; set; } = new List<ProductCreationPlanHistory>();

    public virtual ICollection<ProductInventory> ProductInventories { get; set; } = new List<ProductInventory>();

    public virtual ICollection<Ptemployee> Ptemployees { get; set; } = new List<Ptemployee>();

    public virtual Region? Region { get; set; }

    public virtual ICollection<SalesOrder> SalesOrders { get; set; } = new List<SalesOrder>();

    public virtual ICollection<StoreExpenseHistory> StoreExpenseHistories { get; set; } = new List<StoreExpenseHistory>();
}
