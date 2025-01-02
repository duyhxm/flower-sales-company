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

        public string SalesOrderId { get; set; } = null!;

        public string? ShippingCompanyId { get; set; }

        public string ConsigneeName { get; set; } = null!;

        public string ConsigneePhoneNumber { get; set; } = null!;

        public DateTimeOffset? OrderDateTime { get; set; }

        public DateTimeOffset DeliveryDateTime { get; set; }

        public string ShippingAddress { get; set; } = null!;

        public string District { get; set; } = null!;

        public string CityProvince { get; set; } = null!;

        public decimal ShippingCost { get; set; }
    }
}
