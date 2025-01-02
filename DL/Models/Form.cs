using System;
using System.Collections.Generic;

namespace DL.Models;

public partial class Form
{
    public string FormId { get; set; } = null!;

    public string? FormName { get; set; }

    public virtual ICollection<JobTitle> JobTitles { get; set; } = new List<JobTitle>();
}
