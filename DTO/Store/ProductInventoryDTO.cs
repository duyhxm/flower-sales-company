using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Store
{
    public class ProductInventoryDTO
    {
        public string StoreId { get; set; } = null!;

        public string ProductId { get; set; } = null!;

        public int? StockProductQuantity { get; set; }
    }
}
