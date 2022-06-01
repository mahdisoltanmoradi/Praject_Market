using Data.DTOs;
using Data.DTOs.Discount;
using Data.DTOs.Product;
using Entities.User;
using System.Collections.Generic;

namespace Data.Contracts
{
    public interface IDiscountRepository
    {
        List<ProductItemDto> GetCatalogItems(string searchKey);
        bool ApplyDiscountInBasket(string CoponCode, int BasketId);
        bool RemoveDiscountFromBasket(int BasketId);
        BaseDto IsDiscountValid(string couponCode, User user);
        void Execute(AddNewDiscountDto discount);
    }
}
