using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Product
{
    public class ProductCreationPlanHistoryDTO
    {
        public DateTimeOffset PlannedDateTime { get; set; }

        public string StoreId { get; set; } = null!;

        public string ProductId { get; set; } = null!;

        public DateTimeOffset ImplementationDateTime { get; set; }

        public short NeededCreationQuantity { get; set; }

        public DateTimeOffset? CreatedDateTime { get; set; }

        public string? PlanStatus { get; set; }
    }
}
