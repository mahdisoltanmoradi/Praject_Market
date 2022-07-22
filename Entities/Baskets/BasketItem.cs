using Entities.Common;

namespace Entities.Baskets
{
    public class BasketItem : BaseEntity<int>
    {
        public int UnitPrice { get; private set; }
        public int Quantity { get; private set; }
        public int ProductId { get; private set; }
        public Product.Product Product { get; private set; }
        public int BasketId { get; private set; }
        public bool IsRemoved { get; set; }
        public BasketItem(int productId, int quantity, int unitPrice)
        {
            IsRemoved = false;
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
