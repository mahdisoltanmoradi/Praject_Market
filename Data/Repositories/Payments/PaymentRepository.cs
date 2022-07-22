using Common;
using Data.Contracts;
using Data.DTOs.Payment;
using Entities.Payments;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Data.Repositories
{
    public class PaymentRepository : Repository<Payment>, IPaymentRepository, IScopedDependency
    {
        private readonly ApplicationDbContext _dbContext;
        public PaymentRepository(ApplicationDbContext context, ApplicationDbContext dbContext)
            : base(context)
        {
            _dbContext = dbContext;
        }
        public PaymentDto GetPayment(Guid Id)
        {
            var payment = _dbContext.Payments
                .Include(p => p.Order)
                .ThenInclude(p => p.OrderItems)
                .Include(p=>p.Order)
                .ThenInclude(p=>p.AppliedDiscount)
                .SingleOrDefault(p => p.Id == Id);

            var user = _dbContext.Users.SingleOrDefault(p => p.Id.ToString() == payment.Order.UserId);

            string description = $"پرداخت سفارش شماره {payment.OrderId} " + Environment.NewLine;
            description += "محصولات" + Environment.NewLine;
            foreach (var item in payment.Order.OrderItems.Select(p => p.ProductName))
            {
                description += $" -{item}";
            }

            PaymentDto paymentDto = new PaymentDto
            {
                Amount = payment.Order.TotalPrice(),
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                UserId = user.Id.ToString(),
                Id = payment.Id,
                Description = description,
            };
            return paymentDto;
        }

        public PaymentOfOrderDto PayForOrder(int OrderId)
        {
            var order = _dbContext.Orders
                     .Include(p => p.OrderItems)
                     .Include(p=>p.AppliedDiscount)
                     .SingleOrDefault(p => p.Id == OrderId);
            if (order == null)
                throw new Exception("");
            var payment = _dbContext.Payments.SingleOrDefault(p => p.OrderId == order.Id);

            if (payment == null)
            {
                payment = new Payment(order.TotalPrice(), order.Id);
                _dbContext.Payments.Add(payment);
                _dbContext.SaveChanges();
            }

            return new PaymentOfOrderDto()
            {
                Amount = payment.Amount,
                PaymentId = payment.Id,
                PaymentMethod = order.PaymentMethod,
            };
        }

        public bool VerifyPayment(Guid Id, string Authority, long RefId)
        {
            var payment = _dbContext.Payments
                .Include(p => p.Order)
                .SingleOrDefault(p => p.Id == Id);

            if (payment == null)
                throw new Exception("payment not found");

            payment.Order.PaymentDone();
            payment.PaymentIsDone(Authority, RefId);

            _dbContext.SaveChanges();
            return true;
        }
    }
}
