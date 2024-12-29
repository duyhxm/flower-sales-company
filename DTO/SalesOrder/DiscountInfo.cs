using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.SalesOrder
{
    public class DiscountInfo
    {
        public string PromotionID { get; set; }
        public string PromotionType { get; set; }
        public decimal Discount { get; set; }
        public decimal MaximumDiscountValue { get; set; }
    }
}
