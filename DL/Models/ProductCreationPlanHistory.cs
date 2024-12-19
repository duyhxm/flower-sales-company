using System;
using System.Collections.Generic;

namespace DL.Models;

public partial class ProductCreationPlanHistory
{
    public DateTimeOffset PlannedDateTime { get; set; }

    public string StoreId { get; set; } = null!;

    public string ProductId { get; set; } = null!;

    public DateTimeOffset? ImplementationDateTime { get; set; }

    public short? NeededCreationQuantity { get; set; }

    public DateTimeOffset? CreatedDateTime { get; set; }

    public string? PlanStatus { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual Store Store { get; set; } = null!;
}
