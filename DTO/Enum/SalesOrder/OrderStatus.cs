using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Enum.SalesOrder
{
    public static class OrderStatus
    {
        public const string Confirmed = "Đã xác nhận";
        public const string Success = "Hoàn thành";
        public const string Cancelled = "Đã huỷ";
        public const string OnDelivery = "Đang vận chuyển";
    }
}
