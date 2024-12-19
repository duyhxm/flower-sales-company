using System;
using System.Collections.Generic;

namespace DL.Models;

public partial class PreSalesOrder
{
    public string PreSalesOrderId { get; set; } = null!;

    public DateTimeOffset? DeliveryDateTime { get; set; }

    public virtual SalesOrder PreSalesOrderNavigation { get; set; } = null!;
}
