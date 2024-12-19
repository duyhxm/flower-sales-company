using System;
using System.Collections.Generic;

namespace DL.Models;

public partial class FloralType
{
    public string FtypeId { get; set; } = null!;

    public string? TypeName { get; set; }

    public virtual ICollection<Flower> Flowers { get; set; } = new List<Flower>();
}
