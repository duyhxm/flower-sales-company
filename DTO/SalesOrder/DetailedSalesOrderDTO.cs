using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.SalesOrder
{
    public class DetailedSalesOrderDTO
    {
        public string SalesOrderId { get; set; } = null!;

        public string ProductId { get; set; } = null!;

        public int? Quantity { get; set; }
    }
}
