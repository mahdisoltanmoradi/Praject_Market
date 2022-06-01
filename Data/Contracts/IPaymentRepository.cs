using Data.DTOs.Payment;
using Entities.Payments;
using System;

namespace Data.Contracts
{
    public interface IPaymentRepository  : IRepository<Payment>
    {
        PaymentOfOrderDto PayForOrder(int OrderId);
        PaymentDto GetPayment(Guid Id);
        bool VerifyPayment(Guid Id, string Authority, long RefId);
    }
}
