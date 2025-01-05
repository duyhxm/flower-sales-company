using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Material
{
    public class FlowerWithProfitRateDTO
    {
        public string FlowerID { get; set; }
        public string FlowerName { get; set; }
        public string FTypeName { get; set; }
        public string FColorName { get; set; }
        public string FCharacteristicName { get; set; }

        public decimal ProfitRate { get; set; }
    }
}
