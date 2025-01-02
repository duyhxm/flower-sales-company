using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.SalesOrder
{
    public class ShippingCompanyDTO
    {
        public string ShippingCompanyId { get; set; } = null!;

        public string? ShippingCompanyName { get; set; }
    }
}
