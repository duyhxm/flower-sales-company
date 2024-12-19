using System;
using System.Collections.Generic;

namespace DL.Models;

public partial class TaxType
{
    public string TaxTypeId { get; set; } = null!;

    public string? TaxTypeName { get; set; }

    public virtual ICollection<TaxRate> TaxRates { get; set; } = new List<TaxRate>();
}
