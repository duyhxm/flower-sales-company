using System;
using System.Collections.Generic;

namespace DL.Models;

public partial class SyncStatus
{
    public string TableName { get; set; } = null!;

    public long LastSyncVersion { get; set; }

    public DateTimeOffset LastSyncTime { get; set; }

    public string? Status { get; set; }

    public string? ErrorMessage { get; set; }
}
