using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Product
{
    public class ProductDTO
    {
        public string ProductId { get; set; } = null!;

        public string? FrepresentationId { get; set; }

        public string? ProductName { get; set; }

        public List<DetailedProductDTO> DetailedProducts { get; set; } = new List<DetailedProductDTO>();
    }
}
