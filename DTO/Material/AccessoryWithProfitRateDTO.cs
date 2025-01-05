using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Material
{
    public class AccessoryWithProfitRateDTO
    {
        public string AccessoryId { get; set; } = null!;

        public string AccessoryName { get; set; } = null!;

        public decimal ProfitRate { get; set; }
    }
}
