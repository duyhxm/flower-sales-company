using System;
using System.Collections.Generic;

namespace DL.Models;

public partial class EmployeeBonu
{
    public string EmployeeId { get; set; } = null!;

    public string BonusId { get; set; } = null!;

    public decimal? Amount { get; set; }

    public DateOnly? ReceivedDate { get; set; }

    public virtual Bonu Bonus { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;
}
