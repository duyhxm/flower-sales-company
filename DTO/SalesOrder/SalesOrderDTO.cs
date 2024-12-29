using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.SalesOrder
{
    public class SalesOrderDTO
    {
        public string SalesOrderId { get; set; } = null!;

        public string? CustomerId { get; set; }

        public string? StoreId { get; set; }

        public DateTimeOffset? CreatedDateTime { get; set; }

        public string? OrderStatus { get; set; }

        public string? OrderType { get; set; }

        public string? PurchaseMethod { get; set; }

        public decimal? BasePrice { get; set; }

        public decimal? FinalPrice { get; set; }

        public List<DetailedSalesOrderDTO> DetailedSalesOrders { get; set; } =  new List<DetailedSalesOrderDTO>();
    }
}
