using System;
using System.Collections.Generic;

namespace DL.Models;

public partial class Vendor
{
    public string VendorId { get; set; } = null!;

    public string? VendorName { get; set; }

    public string? VendorAddress { get; set; }

    public string? PhoneNumber { get; set; }

    public string? BankAccountId { get; set; }

    public virtual BankAccount? BankAccount { get; set; }

    public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; } = new List<PurchaseOrder>();
}
