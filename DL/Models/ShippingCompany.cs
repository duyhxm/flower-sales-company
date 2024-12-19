using System;
using System.Collections.Generic;

namespace DL.Models;

public partial class ShippingCompany
{
    public string ShippingCompanyId { get; set; } = null!;

    public string? ShippingCompanyName { get; set; }

    public virtual ICollection<ShippingInformation> ShippingInformations { get; set; } = new List<ShippingInformation>();
}
