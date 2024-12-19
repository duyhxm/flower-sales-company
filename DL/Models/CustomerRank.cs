using System;
using System.Collections.Generic;

namespace DL.Models;

public partial class CustomerRank
{
    public string CustomerRankId { get; set; } = null!;

    public string? RankName { get; set; }

    public virtual ICollection<CustomerPromotionHistory> CustomerPromotionHistories { get; set; } = new List<CustomerPromotionHistory>();

    public virtual ICollection<CustomerRankHistory> CustomerRankHistories { get; set; } = new List<CustomerRankHistory>();

    public virtual ICollection<RankingCycleHistory> RankingCycleHistories { get; set; } = new List<RankingCycleHistory>();
}
