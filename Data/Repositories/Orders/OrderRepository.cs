using AutoMapper;
using Common;
using Common.Enums;
using Data.Contracts;
using Entities.Order;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Data.Repositories
{
    public class OrderRepository :Repository<Order> ,IOrderRepository, IScopedDependency
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IDiscountHistoryRepository _discountHistoryRepository;
        public OrderRepository(ApplicationDbContext context, IDiscountHistoryRepository discountHistoryRepository, IMapper mapper)
        : base(context)
        {
            _context = context;
            _discountHistoryRepository = discountHistoryRepository;
            this._mapper = mapper;
        }
        public int CreateOrder(int BasketId, int UserAddressId, PaymentMethod paymentMethod)
        {

            var basket = _context.Baskets
                         .Include(p => p.Items)
                         .SingleOrDefault(p => p.Id == BasketId);

            int[] Ids = basket.Items.Select(p => p.ProductId).ToArray();
            var productItems = _context.Products
                .Where(p => Ids.Contains(p.Id));


            var orderItems = basket.Items.Select(basketItem =>
            {
                var productItem = productItems.First(c => c.Id == basketItem.ProductId);

                var orderitem = new OrderDetail(productItem.Id,
                    productItem.ProductTitle,
                    productItem.ProductImageName,
                    productItem.ProductPrice, basketItem.Quantity);
                return orderitem;

            }).ToList();

            var userAddress = _context.UserAddresses.SingleOrDefault(p => p.Id == UserAddressId);
            var address = _mapper.Map<Address>(userAddress);
            var order = new Order(basket.BuyerId, address, orderItems, paymentMethod, basket.AppliedDiscount);
            _context.Orders.Add(order);
           // _context.Baskets.Remove(basket);
            _context.SaveChanges();

            if (basket.AppliedDiscount != null)
            {
                _discountHistoryRepository.InsertDiscountUsageHistory(basket.Id, order.Id);
            }
            return order.Id;

        }
    }
}
