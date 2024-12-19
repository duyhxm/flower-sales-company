using System;
using System.Collections.Generic;

namespace DL.Models;

public partial class Bank
{
    public string BankId { get; set; } = null!;

    public string? BankName { get; set; }

    public virtual ICollection<BankAccount> BankAccounts { get; set; } = new List<BankAccount>();
}
