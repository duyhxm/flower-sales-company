using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.SalesOrder
{
    public class ShippingInformationDTO
    {
        public string ShippingId { get; set; } = null!;

        public string? SalesOrderId { get; set; }

        public string? ShippingCompanyId { get; set; }

        public string? ConsigneeName { get; set; }

        public string? ConsigneePhoneNumber { get; set; }

        public DateTimeOffset? OrderDateTime { get; set; }

        public DateTimeOffset? DeliveryDateTime { get; set; }

        public string? ShippingAddress { get; set; }

        public string? District { get; set; }

        public string? CityProvince { get; set; }

        public decimal? ShippingCost { get; set; }
    }
}
