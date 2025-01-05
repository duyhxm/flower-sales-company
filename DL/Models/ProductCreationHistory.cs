using System;
using System.Collections.Generic;

namespace DL.Models;

public partial class ProductCreationHistory
{
    public DateTimeOffset CreatedDateTime { get; set; }

    public string ProductId { get; set; } = null!;

    public string EmployeeId { get; set; } = null!;

    public short CreatedQuantity { get; set; }

    public decimal UnitPrice { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
