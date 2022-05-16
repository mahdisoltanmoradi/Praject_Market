using Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Baskets
{
    public class Basket:BaseEntity<int>
    {
        public string BuyerId { get; private set; }
        private readonly List<BasketItem> _items = new List<BasketItem>();

        public ICollection<BasketItem> Items => _items.AsReadOnly();
        public Basket(string buyerId)
        {
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
    }

    public class BasketItem:BaseEntity<int>
    {
        public int UnitPrice { get; private set; }
        public int Quantity { get; private set; }
        public int ProductId { get; private set; }
        public Product.Product Product { get; private set; }
        public int BasketId { get; private set; }
        public BasketItem(int productId, int quantity, int unitPrice)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
            SetQuantity(quantity);
        }

        public void AddQuantity(int quantity)
        {
            Quantity += quantity;
        }

        public void SetQuantity(int quantity)
        {
            Quantity = quantity;
        }
    }
}
