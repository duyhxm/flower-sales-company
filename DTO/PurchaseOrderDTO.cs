using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PurchaseOrderDTO
    {
        public string PurchaseOrderId { get; set; } = null!;

        public string? VendorId { get; set; }

        public string? OrderType { get; set; }

        public DateTimeOffset? PurchasedDateTime { get; set; }

        public decimal? TotalCost { get; set; }

        public string? DistributionStatus { get; set; }

        public string PurchasedDateTimeFormatted { get; set; }
    }
}
