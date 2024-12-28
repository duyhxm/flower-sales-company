using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Product
{
    public class ReturnedProductDTO
    {
        public ProductDTO Product { get; set; }
        public bool HasExisted { get; set; }
    }
}
