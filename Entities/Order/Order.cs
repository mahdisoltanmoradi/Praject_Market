using Common.Enums;
using Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Entities.Order
{
    public class Order : BaseEntity<int>
    {
        public string UserId { get; private set; }
        public DateTime OrderDate { get; private set; } = DateTime.Now;
        public Address Address { get; private set; }

        public PaymentMethod PaymentMethod { get; private set; }
        public PaymentStatus PaymentStatus { get; private set; }
        public OrderStatus OrderStatus { get; private set; }
        private readonly List<OrderDetail> _orderItems = new List<OrderDetail>();
        public IReadOnlyCollection<OrderDetail> OrderItems => _orderItems.AsReadOnly();

        public Order(string userId, Address address, List<OrderDetail> orderItems, PaymentMethod paymentMethod)
        {
            UserId = userId;
            Address = address;
            _orderItems = orderItems;
            PaymentMethod = paymentMethod;
        }

        public Order()
        {

        }

        /// <summary>
        /// پرداخت انجام شد
        /// </summary>
        public void PaymentDone()
        {
            PaymentStatus = PaymentStatus.Paid;
        }


        /// <summary>
        /// کالا تحویل داده شد
        /// </summary>
        public void OrderDelivered()
        {
            OrderStatus = OrderStatus.Delivered;
        }

        /// <summary>
        /// ثبت مرجوعی کالا
        /// </summary>
        public void OrderReturned()
        {
            OrderStatus = OrderStatus.Returned;
        }


        /// <summary>
        /// لغو سفارش
        /// </summary>
        public void OrderCancelled()
        {
            OrderStatus = OrderStatus.Cancelled;
        }

        public int TotalPrice()
        {
            return _orderItems.Sum(p => p.UnitPrice * p.Units);
        }
    }
}
