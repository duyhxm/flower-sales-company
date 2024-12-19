using System;
using System.Collections.Generic;

namespace DL.Models;

public partial class Product
{
    public string ProductId { get; set; } = null!;

    public string? FrepresentationId { get; set; }

    public string? ProductName { get; set; }

    public virtual ICollection<DetailedProduct> DetailedProducts { get; set; } = new List<DetailedProduct>();

    public virtual ICollection<DetailedSalesOrder> DetailedSalesOrders { get; set; } = new List<DetailedSalesOrder>();

    public virtual FloralRepresentation? Frepresentation { get; set; }

    public virtual ICollection<ProductCreationHistory> ProductCreationHistories { get; set; } = new List<ProductCreationHistory>();

    public virtual ICollection<ProductCreationPlanHistory> ProductCreationPlanHistories { get; set; } = new List<ProductCreationPlanHistory>();

    public virtual ICollection<ProductInventory> ProductInventories { get; set; } = new List<ProductInventory>();
}
