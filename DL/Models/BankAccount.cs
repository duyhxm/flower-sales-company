using System;
using System.Collections.Generic;

namespace DL.Models;

public partial class BankAccount
{
    public string BankAccountId { get; set; } = null!;

    public string? BankId { get; set; }

    public string? BankAccountNumber { get; set; }

    public virtual Bank? Bank { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<Vendor> Vendors { get; set; } = new List<Vendor>();
}
