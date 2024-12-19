using System;
using System.Collections.Generic;

namespace DL.Models;

public partial class Bonu
{
    public string BonusId { get; set; } = null!;

    public string? BonusName { get; set; }

    public virtual ICollection<EmployeeBonu> EmployeeBonus { get; set; } = new List<EmployeeBonu>();
}
