using Common;
using Data.Contracts;
using Data.DTOs.Baskets;
using Entities.Baskets;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Data.Repositories
{
    public class BasketRepository : Repository<Basket>, IBasketRepository, IScopedDependency
    {
        public BasketRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public void AddItemToBasket(int basketId, int ProductId, int quantity = 1)
        {
            var basket = TableNoTracking.FirstOrDefault(p => p.Id == basketId);
            if (basket == null)
                throw new Exception("");

            //var catalog = Table.FirstOrDefault(p=>p.Id);
            //basket.AddItem(ProductId, quantity, catalog.Price);

            DbContext.SaveChanges();
        }

        public BasketDto GetOrCreateBasketForUser(string BuyerId)
        {
            var basket = TableNoTracking
                .Include(p => p.Items)
                .ThenInclude(p => p.Product)
                .ThenInclude(p => p.ProductImageName)
                .SingleOrDefault(p => p.BuyerId == BuyerId);
            if (basket == null)
            {
                //سبد خرید را ایجاد کنید
                return CreateBasketForUser(BuyerId);
            }
            return new BasketDto
            {
                Id = basket.Id,
                BuyerId = basket.BuyerId,
                Items = basket.Items.Select(item => new BasketItemDto
                {
                    ProductId = item.ProductId,
                    Id = item.Id,
                    ProductName = item.Product.ProductTitle,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice,
                    ImageUrl = item.Product.ProductImageName

                }).ToList(),
            };

        }

        public bool RemoveItemFromBasket(int itemId)
        {
            var item = TableNoTracking.SingleOrDefault(p => p.Id == itemId);
            DbContext.Remove(item);
            DbContext.SaveChanges();
            return true;
        }

        public bool SetQuantities(int itemId, int quantity)
        {
            var item = TableNoTracking.SingleOrDefault(p => p.Id == itemId);
            //item.SetQuantity(quantity);
            DbContext.SaveChanges();
            return true;
        }

        private BasketDto CreateBasketForUser(string BuyerId)
        {
            Basket basket = new Basket(BuyerId);
            DbContext.Add(basket);
            DbContext.SaveChanges();
            return new BasketDto
            {
                BuyerId = basket.BuyerId,
                Id = basket.Id,
            };
        }
    }
}
