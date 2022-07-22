using Common;
using Common.Enums;
using Data.Contracts;
using Data.DTOs;
using Data.DTOs.Discount;
using Data.DTOs.Product;
using Entities.Discount;
using Entities.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class DiscountRepository : IDiscountRepository, IScopedDependency
    {
        private readonly ApplicationDbContext _context;
        private readonly IDiscountHistoryRepository _discountHistoryRepository;
        public DiscountRepository(ApplicationDbContext context, IDiscountHistoryRepository discountHistoryRepository)
        {
            _context = context;
            _discountHistoryRepository = discountHistoryRepository;
        }

        public bool ApplyDiscountInBasket(string CoponCode, int BasketId)
        {
            var basket = _context.Baskets
                 .Include(p => p.Items)
                 .Include(p => p.AppliedDiscount)
                 .FirstOrDefault(p => p.Id == BasketId);

            var discount = _context.Discounts.Where(p => p.CouponCode.Equals(CoponCode))
                .FirstOrDefault();

            basket.ApplyDiscountCode(discount);
            _context.SaveChanges();
            return true;
        }

        public void Execute(AddNewDiscountDto discount)
        {
            var stratDate = discount.StartDate = new DateTime(discount.StartDate.Value.Year, discount.StartDate.Value.Month, discount.StartDate.Value.Day, new PersianCalendar());
            var endDate = discount.EndDate = new DateTime(discount.EndDate.Value.Year, discount.EndDate.Value.Month, discount.EndDate.Value.Day, new PersianCalendar());

            var newdiscount = new Discount()
            {
                Name = discount.Name,
                CouponCode = discount.CouponCode,
                DiscountAmount = discount.DiscountAmount,
                DiscountLimitationId = discount.DiscountLimitationId,
                DiscountPercentage = discount.DiscountPercentage,
                DiscountTypeId = discount.DiscountTypeId,
                EndDate = endDate,
                RequiresCouponCode = discount.RequiresCouponCode,
                StartDate = stratDate,
                UsePercentage = discount.UsePercentage,
            };

            if (discount.appliedToCatalogItem != null)
            {
                var productItems = _context.Products.Where(p => discount.appliedToCatalogItem.Contains(p.Id)).ToList();
                newdiscount.Products = productItems;
            }

            _context.Discounts.Add(newdiscount);
            _context.SaveChanges();
        }

        public async Task<List<Discount>> GetAllDiscount()
        {
            return await _context.Discounts.ToListAsync();
        }

        public List<ProductItemDto> GetCatalogItems(string searchKey)
        {
            if (!string.IsNullOrEmpty(searchKey))
            {
                var data = _context.Products
                    .Where(p => p.ProductTitle.Contains(searchKey))
                    .Select(p => new ProductItemDto
                    {
                        Id = p.Id,
                        Name = p.ProductTitle
                    }).ToList();
                return data;
            }
            else
            {
                var data = _context.Products
                    .OrderByDescending(p => p.Id)
                    .Take(10)
                    .Select(p => new ProductItemDto
                    {
                        Id = p.Id,
                        Name = p.ProductTitle
                    }).ToList();
                return data;
            }
        }

        public BaseDto IsDiscountValid(string couponCode, User user)
        {
            var discount = _context.Discounts
               .Where(p => p.CouponCode.Equals(couponCode)).FirstOrDefault();
            if (discount == null)
            {
                return new BaseDto(IsSuccess: false,
                    Message: new List<string> { "کد تخفیف معتبر نمی باشد" });
            }

            var now = DateTime.UtcNow;
            if (discount.StartDate.HasValue)
            {
                var startDate = DateTime.SpecifyKind(discount.StartDate.Value, DateTimeKind.Utc);
                if (startDate.CompareTo(now) > 0)
                    return new BaseDto(false, new List<string>
                    { "هنوز زمان استفاده از این کد تخفیف فرا نرسیده است" });
            }
            if (discount.EndDate.HasValue)
            {
                var endDate = DateTime.SpecifyKind(discount.EndDate.Value, DateTimeKind.Utc);
                if (endDate.CompareTo(now) < 0)
                    return new BaseDto(false, new List<string> { "کد تخفیف منقضی شده است" });
            }

            var checkLimit = CheckDiscountLimitations(discount, user);

            if (checkLimit.IsSuccess == false)
                return checkLimit;
            return new BaseDto(true, null);
        }

        public bool RemoveDiscountFromBasket(int BasketId)
        {
            var basket = _context.Baskets.Find(BasketId);

            basket.RemoveDescount();
            _context.SaveChanges();
            return true;
        }

        private BaseDto CheckDiscountLimitations(Discount discount, User user)
        {
            switch (discount.DiscountLimitation)
            {
                case DiscountLimitationType.Unlimited:
                    {
                        return new BaseDto(true, null);
                    }
                case DiscountLimitationType.NTimesOnly:
                    {
                        var totalUsage = _discountHistoryRepository.GetAllDiscountUsageHistory(discount.Id, null, 0, 1).Data.Count();
                        if (totalUsage < discount.LimitationTimes)
                        {
                            return new BaseDto(true, null);

                        }
                        else
                        {
                            return new BaseDto(false, new List<string> { "ظرفیت استفاده از این کد تخفیف تکمیل شده است" });

                        }
                    }
                case DiscountLimitationType.NTimesPerCustomer:
                    {
                        if (user != null)
                        {
                            var totalUsage = _discountHistoryRepository.GetAllDiscountUsageHistory(discount.Id, user.Id.ToString(), 0, 1).Data.Count();
                            if (totalUsage < discount.LimitationTimes)
                            {
                                return new BaseDto(true, null);
                            }
                            else
                            {
                                return new BaseDto(false, new List<string> { "تعدادی که شما مجاز به استفاده از این تخفیف بوده اید به پایان رسیده است" });
                            }
                        }
                        else
                        {
                            return new BaseDto(true, null);
                        }
                    }
                default:
                    break;
            }
            return new BaseDto(true, null);

        }
    }
}
