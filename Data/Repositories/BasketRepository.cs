using Common;
using Data.Contracts;
using Data.DTOs.Baskets;
using Entities.Baskets;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class BasketRepository : Repository<Basket>, IBasketRepository, IScopedDependency
    {
        private readonly ApplicationDbContext _dbContext;
        public BasketRepository(ApplicationDbContext context)
            : base(context)
        {
            _dbContext = context;
        }

        public void AddItemToBasket(int basketId, int ProductId, int quantity = 1)
        {
            var basket = _dbContext.Baskets.FirstOrDefault(p => p.Id == basketId);
            if (basket == null)
                throw new Exception("");

            var product = _dbContext.Products.Find(ProductId);
            basket.AddItem(ProductId, quantity, product.ProductPrice);

            _dbContext.SaveChanges();
        }

        public BasketDto GetBasketForUser(string userId)
        {
            var basket = _dbContext.Baskets
             .Include(p => p.Items)
             .ThenInclude(p => p.Product)
             .SingleOrDefault(p => p.BuyerId == userId);
            if (basket == null)
            {
                return null;
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
        

        public BasketDto GetOrCreateBasketForUser(string BuyerId)
        {
            var basket = _dbContext.Baskets
                .Include(p => p.Items)
                .ThenInclude(p => p.Product)
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

        public bool RemoveDiscountFromBasket(int BasketId)
        {
            var basket = _dbContext.Baskets.Find(BasketId);

            basket.RemoveDescount();
            _dbContext.SaveChanges();
            return true;
        }

        public bool RemoveItemFromBasket(int itemId)
        {
            var item = TableNoTracking.SingleOrDefault(p => p.Id == itemId);
            _dbContext.Remove(item);
            _dbContext.SaveChanges();
            return true;
        }

        public bool SetQuantities(int itemId, int quantity)
        {
            var item = _dbContext.BasketItems.SingleOrDefault(p => p.Id == itemId);
            item.SetQuantity(quantity);
            _dbContext.SaveChanges();
            return true;
        }

        public void TransferBasket(string anonymousId, string userId)
        {
            var anonymousBasket = _dbContext.Baskets
                .Include(p => p.Items)
                .SingleOrDefault(p => p.BuyerId == anonymousId);
            if (anonymousBasket == null) return;
            var userBasket = _dbContext.Baskets.SingleOrDefault(p => p.BuyerId == userId);
            if (userBasket == null)
            {
                userBasket = new Basket(userId);
                _dbContext.Baskets.Add(userBasket);
            }
            foreach (var item in anonymousBasket.Items)
            {
                userBasket.AddItem(item.ProductId, item.Quantity, item.UnitPrice);
            }
            _dbContext.Baskets.Remove(anonymousBasket);
            _dbContext.SaveChanges();
        }

        private BasketDto CreateBasketForUser(string BuyerId)
        {
            Basket basket = new Basket(BuyerId);
            _dbContext.Add(basket);
            _dbContext.SaveChanges();
            return new BasketDto
            {
                BuyerId = basket.BuyerId,
                Id = basket.Id,
            };
        }
    }
}
