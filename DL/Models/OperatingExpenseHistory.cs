using System;
using System.Collections.Generic;

namespace DL.Models;

public partial class OperatingExpenseHistory
{
    public int OperatingExpenseId { get; set; }

    public decimal? ReportingMonth { get; set; }

    public decimal? ReportingYear { get; set; }

    public decimal? TotalExpense { get; set; }
}
