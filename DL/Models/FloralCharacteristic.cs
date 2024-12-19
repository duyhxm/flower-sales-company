using System;
using System.Collections.Generic;

namespace DL.Models;

public partial class FloralCharacteristic
{
    public string FcharacteristicId { get; set; } = null!;

    public string? CharacteristicName { get; set; }

    public virtual ICollection<Flower> Flowers { get; set; } = new List<Flower>();
}
