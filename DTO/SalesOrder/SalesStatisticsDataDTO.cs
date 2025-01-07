using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.SalesOrder
{
    public class SalesStatisticsDataDTO
    {
        public DateTime YearMonth { get; set; }

        public decimal TotalRevenue { get; set; }

        public int CustomerCount { get; set; }
    }
}
