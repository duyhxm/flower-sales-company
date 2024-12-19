using System;
using System.Collections.Generic;

namespace DL.Models;

public partial class UserAccount
{
    public string Username { get; set; } = null!;

    public string? Password { get; set; }

    public string? EmployeeId { get; set; }

    public virtual Employee? Employee { get; set; }
}
