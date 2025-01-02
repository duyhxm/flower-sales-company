using System;
using System.Collections.Generic;

namespace DL.Models;

public partial class RankingCycle
{
    public string RankingCycleId { get; set; } = null!;

    public DateTimeOffset? StartDateTime { get; set; }

    public DateTimeOffset? EndDateTime { get; set; }

    public string? UsageStatus { get; set; }

    public virtual ICollection<CustomerRankHistory> CustomerRankHistories { get; set; } = new List<CustomerRankHistory>();

    public virtual ICollection<RankingCycleHistory> RankingCycleHistories { get; set; } = new List<RankingCycleHistory>();
}
