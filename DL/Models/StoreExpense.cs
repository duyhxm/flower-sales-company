using System;
using System.Collections.Generic;

namespace DL.Models;

public partial class StoreExpense
{
    public string StoreExpenseId { get; set; } = null!;

    public string? StoreExpenseName { get; set; }

    public string? PaymentCycle { get; set; }

    public virtual ICollection<StoreExpenseHistory> StoreExpenseHistories { get; set; } = new List<StoreExpenseHistory>();
}
