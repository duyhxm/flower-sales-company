using System;
using System.Collections.Generic;

namespace DL.Models;

public partial class FloralRepresentation
{
    public string FrepresentationId { get; set; } = null!;

    public string? Frname { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
