using Entities.Common;
using System;

namespace Entities.Payments
{
    public class Payment:BaseEntity<Guid>
    {
        public int Amount { get; private set; }
        public bool IsPay { get; private set; } = false;
        public DateTime? DatePay { get; private set; } = null;
        public string Authority { get; private set; }
        public long RefId { get; private set; } = 0;
        public Order.Order Order { get; private set; }
        public int OrderId { get; private set; }

        public Payment(int amount, int orderId)
        {
            Amount = amount;
            OrderId = orderId;
        }

        public void PaymentIsDone(string authority, long refId)
        {
            IsPay = true;
            DatePay = DateTime.Now;
            Authority = authority;
            RefId = refId;
        }
    }
}
