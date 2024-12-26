using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Store
{
    public class StoreDTO
    {
        public string StoreId { get; set; } = null!;

        public string? StoreName { get; set; }

        public string? StoreAddress { get; set; }

        public string? RegionId { get; set; }

        public string? ManagerId { get; set; }
    }
}
