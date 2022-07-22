using Data.Contracts;
using Data.DTOs.Orders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class CustomerOrdersRepository : ICustomerOrdersRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CustomerOrdersRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<MyOrderDto> GetMyOrder(string userId)
        {
            var orders = _dbContext.Orders
             .Include(p => p.OrderItems)
             .Where(p => p.UserId == userId)
             .OrderByDescending(p => p.Id)
             .Select(p => new MyOrderDto
             {
                 Id = p.Id,
                 Date = _dbContext.Entry(p).Property("InsertTime").CurrentValue.ToString(),
                 OrderStatus = p.OrderStatus,
                 PaymentStatus = p.PaymentStatus,
                 Price = p.TotalPrice()

             }).ToList();
            return orders;
        }
    }
}
