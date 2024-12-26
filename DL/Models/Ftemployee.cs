using System;
using System.Collections.Generic;

namespace DL.Models;

public partial class FTEmployee
{
    public string FTEmployeeID { get; set; } = null!;

    public string? SalaryId { get; set; }

    public virtual Employee FtemployeeNavigation { get; set; } = null!;

    public virtual ICollection<Leave> Leaves { get; set; } = new List<Leave>();

    public virtual Salary? Salary { get; set; }

    public virtual ICollection<Store> Stores { get; set; } = new List<Store>();
}
