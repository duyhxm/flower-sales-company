using System;
using System.Collections.Generic;

namespace DL.Models;

public partial class DetailedProduct
{
    public string ProductId { get; set; } = null!;

    public string MaterialId { get; set; } = null!;

    public short? UsedQuantity { get; set; }

    public virtual Material Material { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
