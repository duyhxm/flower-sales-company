using System;
using System.Collections.Generic;

namespace DL.Models;

public partial class StoreExpenseHistory
{
    public string StoreExpenseId { get; set; } = null!;

    public string StoreId { get; set; } = null!;

    public decimal? Price { get; set; }

    public DateOnly? PaymentDate { get; set; }

    public virtual Store Store { get; set; } = null!;

    public virtual StoreExpense StoreExpense { get; set; } = null!;
}
