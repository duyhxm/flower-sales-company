using System;
using System.Collections.Generic;

namespace DL.Models;

public partial class Bonus
{
    public string BonusId { get; set; } = null!;

    public string? BonusName { get; set; }

    public virtual ICollection<EmployeeBonus> EmployeeBonus { get; set; } = new List<EmployeeBonus>();
}
