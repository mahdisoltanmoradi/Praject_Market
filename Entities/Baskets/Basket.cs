using Entities.Common;
using System.Collections.Generic;
using System.Linq;

namespace Entities.Baskets
{
    public class Basket : BaseEntity<int>
    {
        public string BuyerId { get; private set; }
        private readonly List<BasketItem> _items = new List<BasketItem>();

        public int DiscountAmount { get; private set; } = 0;
        public Discount.Discount AppliedDiscount { get; private set; }
        public int? AppliedDiscountId { get; private set; }
        public bool IsRemoved { get; set; }
        public ICollection<BasketItem> Items => _items.AsReadOnly();
        public Basket(string buyerId)
        {
            IsRemoved = false;
            this.BuyerId = buyerId;
        }

        public void AddItem(int productId, int quantity, int unitPrice)
        {
            if (!Items.Any(p => p.ProductId == productId))
            {
                _items.Add(new BasketItem(productId, quantity, unitPrice));
                return;
            }
            var existingItem = Items.FirstOrDefault(p => p.ProductId == productId);
            existingItem.AddQuantity(quantity);
        }

        public int TotalPrice()
        {
            int totalPrice = _items.Sum(p => p.UnitPrice * p.Quantity);
            totalPrice -= AppliedDiscount.GetDiscountAmount(totalPrice);
            return totalPrice;
        }

        public int TotalPriceWithOutDiescount()
        {
            int totalPrice = _items.Sum(p => p.UnitPrice * p.Quantity);
            return totalPrice;
        }

        public void ApplyDiscountCode(Discount.Discount discount)
        {
            this.AppliedDiscount = discount;
            this.AppliedDiscountId = discount.Id;
            this.DiscountAmount = discount.GetDiscountAmount(TotalPriceWithOutDiescount());
        }

        public void RemoveDescount()
        {
            AppliedDiscount = null;
            AppliedDiscountId = null;
            DiscountAmount = 0;
        }
    }
}
