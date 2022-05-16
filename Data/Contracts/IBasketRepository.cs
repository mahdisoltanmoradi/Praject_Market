using Data.DTOs.Baskets;
using Entities.Baskets;


namespace Data.Contracts
{
    public interface IBasketRepository : IRepository<Basket>
    {
        BasketDto GetOrCreateBasketForUser(string BuyerId);
        void AddItemToBasket(int basketId, int ProductId, int quantity = 1);
        bool RemoveItemFromBasket(int itemId);
        bool SetQuantities(int itemId, int quantity);
    }
}
