using Common;
using Data.Contracts;
using Data.DTOs;
using Entities.Discount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class DiscountHistoryRepository: IDiscountHistoryRepository,IScopedDependency
    {
        private readonly ApplicationDbContext _context;

        public DiscountHistoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public PaginatedItemsDto<DiscountUsageHistory> GetAllDiscountUsageHistory(int? discountId, string userId, int pageIndex, int pageSize)
        {
            var query = _context.DiscountUsageHistories.AsQueryable();

            if (discountId.HasValue && discountId.Value > 0)
                query = query.Where(p => p.DiscountId == discountId.Value);

            if (!string.IsNullOrEmpty(userId))
                query = query.Where(p => p.Order != null && p.Order.UserId == userId);

            query = query.OrderByDescending(c => c.CreatedOn);
            var pagedItems = query.PagedResult(pageIndex, pageSize, out int rowCount);
            return new PaginatedItemsDto<DiscountUsageHistory>(pageIndex, pageSize, rowCount, query.ToList());
        }

        public DiscountUsageHistory GetDiscountUsageHistoryById(int discountUsageHistoryId)
        {
            if (discountUsageHistoryId == 0)
                return null;

            var discountUsage = _context.DiscountUsageHistories.Find(discountUsageHistoryId);
            return discountUsage;
        }

        public void InsertDiscountUsageHistory(int DiscountId, int OrderId)
        {
            var order = _context.Orders.Find(OrderId);
            var discount = _context.Discounts.Find(DiscountId);

            DiscountUsageHistory discountUsageHistory = new DiscountUsageHistory()
            {
                CreatedOn = DateTime.Now,
                Discount = discount,
                Order = order,
            };
            _context.DiscountUsageHistories.Add(discountUsageHistory);
            _context.SaveChanges();
        }
    }
}
