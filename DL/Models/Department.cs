using System;
using System.Collections.Generic;

namespace DL.Models;

public partial class Department
{
    public string DepartmentId { get; set; } = null!;

    public string? DepartmentName { get; set; }

    public virtual ICollection<JobTitle> JobTitles { get; set; } = new List<JobTitle>();
}
