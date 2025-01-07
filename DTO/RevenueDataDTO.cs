using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class RevenueDataDTO
    {
        public decimal? ReportingYear { get; set; }
        public decimal? ReportingMonth { get; set; }
        public decimal? ExpectedFlowerRevenue { get; set; }
        public decimal? NetFlowerRevenue { get; set; }
        public decimal? NetSuppMaterialRevenue { get; set; }
        public DateTime Date { get; set; }
    }
}
