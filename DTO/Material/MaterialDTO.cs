using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Material
{
    public class MaterialDTO
    {
        public string MaterialId { get; set; } = null!;

        public string? MaterialName { get; set; }

        public string? MaterialType { get; set; }

        public string? Unit { get; set; }
    }
}
