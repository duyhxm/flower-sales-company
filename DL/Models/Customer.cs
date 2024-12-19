using System;
using System.Collections.Generic;

namespace DL.Models;

public partial class Customer
{
    public string CustomerId { get; set; } = null!;

    public string? LastName { get; set; }

    public string? MiddleName { get; set; }

    public string? FirstName { get; set; }

    public DateOnly? Birthday { get; set; }

    public string? Gender { get; set; }

    public string? PhoneNumber { get; set; }

    public string? CustomerAddress { get; set; }

    public string? CustomerType { get; set; }

    public virtual ICollection<CustomerRankHistory> CustomerRankHistories { get; set; } = new List<CustomerRankHistory>();

    public virtual ICollection<SalesOrder> SalesOrders { get; set; } = new List<SalesOrder>();
}
