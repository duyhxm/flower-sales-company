using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class MaterialInventoryDTO
    {
        public string MaterialID { get; set; } = string.Empty;
        public string MaterialName { get; set; } = string.Empty;
        public int? StockMaterialQuantity { get; set; }
    }
}
