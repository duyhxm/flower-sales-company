using System;
using System.Collections.Generic;

namespace DL.Models;

public partial class CustomerRankHistory
{
    public string CustomerRankHistoryId { get; set; } = null!;

    public string? RankingCycleId { get; set; }

    public string? CustomerId { get; set; }

    public decimal? TotalSpending { get; set; }

    public string? CustomerRankId { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual CustomerRank? CustomerRank { get; set; }

    public virtual RankingCycle? RankingCycle { get; set; }
}
