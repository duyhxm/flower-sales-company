using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Product
{
    public class ProductCreationHistoryDTO
    {
        public DateTimeOffset CreatedDateTime { get; set; }

        public string ProductId { get; set; } = null!;

        public string EmployeeId { get; set; } = null!;

        public short CreatedQuantity { get; set; }

        public decimal UnitPrice { get; set; }
    }
}
