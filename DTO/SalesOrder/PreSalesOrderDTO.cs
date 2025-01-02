using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.SalesOrder
{
    public class PreSalesOrderDTO
    {
        public string SalesOrderId { get; set; } = null!;

        public DateTimeOffset DeliveryDateTime;

        public string? OrderStatus { get; set; }

        public decimal FinalPrice { get; set; }
        
    }
}
