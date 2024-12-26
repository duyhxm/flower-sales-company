using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Material
{
    public class AccessoryDTO
    {
        public string AccessoryId { get; set; }
        public string AccessoryName { get; set; }

        public AccessoryDTO(string accessoryId, string accessoryName)
        {
            AccessoryId = accessoryId;
            AccessoryName = accessoryName;
        }
    }
}
