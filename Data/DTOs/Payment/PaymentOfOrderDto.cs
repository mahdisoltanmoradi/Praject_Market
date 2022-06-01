using Common.Enums;
using System;

namespace Data.DTOs.Payment
{
    public class PaymentOfOrderDto
    {
        public Guid PaymentId { get; set; }
        public int Amount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}
