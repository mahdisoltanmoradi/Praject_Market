using Common.Enums;

namespace Data.DTOs.Orders
{
    public class MyOrderDto
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public int Price { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
    }
}
