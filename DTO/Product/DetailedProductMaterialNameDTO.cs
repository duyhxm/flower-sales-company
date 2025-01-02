using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Product
{
    public class DetailedProductMaterialNameDTO
    {
        public string MaterialId { get; set; } = null!;
        public string MaterialName { get; set; } = null!;
        public short? UsedQuantity { get; set; }
    }
}
