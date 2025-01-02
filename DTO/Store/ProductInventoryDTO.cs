using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Store
{
    public class ProductInventoryDTO
    {
        public string ProductId { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public DateOnly StockDate { get; set; }
        public int? StockProductQuantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
