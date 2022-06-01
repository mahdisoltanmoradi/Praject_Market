using Entities.Common;
using System;

namespace Entities.Discount
{
    public class DiscountUsageHistory:BaseEntity<int>
    {
        public DateTime CreatedOn { get; set; }
        public virtual Discount Discount { get; set; }
        public int DiscountId { get; set; }
        public virtual Order.Order Order { get; set; }
        public int OrderId { get; set; }
    }
}
