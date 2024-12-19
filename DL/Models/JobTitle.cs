using System;
using System.Collections.Generic;

namespace DL.Models;

public partial class JobTitle
{
    public string JobTitleId { get; set; } = null!;

    public string? DepartmentId { get; set; }

    public string? JobTitleName { get; set; }

    public string? Jd { get; set; }

    public int? FormId { get; set; }

    public virtual Department? Department { get; set; }

    public virtual ICollection<EmployeeJobTitle> EmployeeJobTitles { get; set; } = new List<EmployeeJobTitle>();

    public virtual Form? Form { get; set; }
}
