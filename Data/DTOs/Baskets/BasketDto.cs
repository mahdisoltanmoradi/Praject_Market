using System.Collections.Generic;
using System.Linq;

namespace Data.DTOs.Baskets
{
    public class BasketDto
    {
        public int Id { get; set; }
        public string BuyerId { get; set; }
        public List<BasketItemDto> Items { get; set; } = new List<BasketItemDto>();
        public int DiscountAmount { get; set; }

        public int Total()
        {
            if (Items.Count > 0)
            {
                int total = Items.Sum(p => p.UnitPrice * p.Quantity);
                total -= DiscountAmount;
                return total;
            }
            return 0;
        }
        public int TotalWithOutDiescount()
        {
            if (Items.Count > 0)
            {
                int total = Items.Sum(p => p.UnitPrice * p.Quantity);
                return total;
            }
            return 0;
        }
    }

    public class BasketItemDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string ImageUrl { get; set; }
    }
}
