using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.SalesOrder
{
    public class UsedPromotionHistoryDTO
    {
        public string PromotionId { get; set; } = null!;

        public string SalesOrderId { get; set; } = null!;

        public decimal? OrderDiscountValue { get; set; }

        public decimal? CustomerDiscountValue { get; set; }
    }
}
