using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Enums;
using Entities.Order;

namespace Data.DTOs.Orders
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentStatus { get; set; }
        public string OrderStatus { get; set; }
        public decimal TotalPrice { get; set; }

        // برای زمانی که خواستیم جزئیات سفارش رو هم همراهش برگردونیم
        public List<OrderDetailDto> OrderDetails { get; set; }
    }

    public class OrderDetailDto
    {
        public int Id { get; set; }
        public int CatalogItemId { get; set; }
        public string ProductName { get; set; }
        public string PictureUri { get; set; }
        public int UnitPrice { get; set; }
        public int Units { get; set; }
        public int TotalPrice => UnitPrice * Units;
    }

}
