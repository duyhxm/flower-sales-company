using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Material
{
    public class FlowerProfitRateDTO
    {
        public string TargetId { get; set; }
        public string FlowerId { get; set; }
        public int? ExpectedQuantity { get; set; }
        public decimal? ProfitRate { get; set; }
        public decimal? ApplyMonth { get; set; }
        public decimal? ApplyYear { get; set; }
        public string UsageStatus { get; set; }
    }
}
