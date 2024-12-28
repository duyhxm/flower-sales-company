using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Store
{
    public class StoreInventoryDTO
    {
        public string MaterialId { get; set; }
        public string MaterialName { get; set; }
        public int StockMaterialQuantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
