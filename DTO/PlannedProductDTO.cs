using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PlannedProductDTO
    {
        public DateTimeOffset PlannedDateTime { get; set; } 
        public string ProductId { get; set; }

        public string StoreId { get; set; }

        public string FRName { get; set; }
        public string ProductName { get; set; }
        public DateTimeOffset ImplementationDateTime { get; set; }
        public short Quantity { get; set; }

        public string ImplementationDateTimeFormatted { get; set; }
    }
}
