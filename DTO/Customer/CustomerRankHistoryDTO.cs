using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Customer
{
    public class CustomerRankHistoryDTO
    {
        public string CustomerId { get; set; }

        public string CustomerName { get; set; }

        public decimal? TotalSpending { get; set; }

        public string RankName { get; set; }
    }
}
