using System;
using System.Collections.Generic;

namespace DL.Models;

public partial class Form
{
    public int FormId { get; set; }

    public string? FormName { get; set; }

    public virtual ICollection<JobTitle> JobTitles { get; set; } = new List<JobTitle>();
}
