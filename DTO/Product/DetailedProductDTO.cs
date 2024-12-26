using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Product
{
    public class DetailedProductDTO
    {
        public string ProductId { get; set; } = null!;

        public string MaterialId { get; set; } = null!;

        public short? UsedQuantity { get; set; }
    }
}
