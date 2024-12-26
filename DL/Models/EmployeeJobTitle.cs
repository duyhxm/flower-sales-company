using System;
using System.Collections.Generic;

namespace DL.Models;

public partial class EmployeeJobTitle
{
    public string EmployeeId { get; set; } = null!;

    public string JobTitleId { get; set; } = null!;

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public string? JobTitleStatus { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual JobTitle JobTitle { get; set; } = null!;
}
