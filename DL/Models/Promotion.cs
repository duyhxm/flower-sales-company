using System;
using System.Collections.Generic;

namespace DL.Models;

public partial class Promotion
{
    public string PromotionId { get; set; } = null!;

    public string? PromotionName { get; set; }

    public string? PromotionType { get; set; }

    public DateTimeOffset? StartDateTime { get; set; }

    public DateTimeOffset? EndDateTime { get; set; }

    public string? UsageStatus { get; set; }

    public virtual ICollection<CustomerPromotionHistory> CustomerPromotionHistories { get; set; } = new List<CustomerPromotionHistory>();

    public virtual ICollection<UsedPromotionHistory> UsedPromotionHistories { get; set; } = new List<UsedPromotionHistory>();

    public virtual ICollection<OrderPromotionLevel> Oplevels { get; set; } = new List<OrderPromotionLevel>();
}
