using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DetailedPurchaseOrderDTO
    {
        public string PurchaseOrderId { get; set; } = null!;

        public string MaterialId { get; set; } = null!;

        public decimal? CostPrice { get; set; }

        public int? Quantity { get; set; }
    }
}
