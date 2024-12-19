using System;
using System.Collections.Generic;

namespace DL.Models;

public partial class Region
{
    public string RegionId { get; set; } = null!;

    public string? RegionName { get; set; }

    public virtual ICollection<Store> Stores { get; set; } = new List<Store>();
}
