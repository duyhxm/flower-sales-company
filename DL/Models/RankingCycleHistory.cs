using System;
using System.Collections.Generic;

namespace DL.Models;

public partial class RankingCycleHistory
{
    public string RankingCycleId { get; set; } = null!;

    public string CustomerRankId { get; set; } = null!;

    public decimal? MinimumSpending { get; set; }

    public virtual CustomerRank CustomerRank { get; set; } = null!;

    public virtual RankingCycle RankingCycle { get; set; } = null!;
}
