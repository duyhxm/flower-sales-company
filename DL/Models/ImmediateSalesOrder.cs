using System;
using System.Collections.Generic;

namespace DL.Models;

public partial class ImmediateSalesOrder
{
    public string IsalesOrderId { get; set; } = null!;

    public virtual SalesOrder IsalesOrder { get; set; } = null!;
}
