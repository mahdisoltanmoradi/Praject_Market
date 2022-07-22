using Data.DTOs.Baskets;
using Entities.Baskets;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Contracts
{
    public interface IBasketRepository : IRepository<Basket>
    {
        BasketDto GetOrCreateBasketForUser(string BuyerId);
        void AddItemToBasket(int basketId, int ProductId, int quantity = 1);
        bool RemoveItemFromBasket(int itemId);
        bool RemoveDiscountFromBasket(int BasketId);
        bool SetQuantities(int itemId, int quantity);
        BasketDto GetBasketForUser(string userId);
        void TransferBasket(string anonymousId, string userId);
    }
}
