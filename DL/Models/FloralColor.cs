using System;
using System.Collections.Generic;

namespace DL.Models;

public partial class FloralColor
{
    public string FcolorId { get; set; } = null!;

    public string? ColorName { get; set; }

    public virtual ICollection<Flower> Flowers { get; set; } = new List<Flower>();
}
