using Common.Enums;
using Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Discount
{
    public class Discount : BaseEntity<int>
    {
        public string Name { get; set; }
        public bool UsePercentage { get; set; }
        public int DiscountPercentage { get; set; }
        public int DiscountAmount { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public bool RequiresCouponCode { get; set; }
        public string CouponCode { get; set; }

        [NotMapped]
        public DiscountType DiscountType
        {
            get => (DiscountType)this.DiscountTypeId;
            set => this.DiscountTypeId = (int)value;
        }
        public int DiscountTypeId { get; set; }

        public ICollection<Product.Product> Products { get; set; }


        public int LimitationTimes { get; set; }
        [NotMapped]
        public DiscountLimitationType DiscountLimitation
        {
            get => (DiscountLimitationType)this.DiscountLimitationId;
            set => this.DiscountLimitationId = (int)value;
        }
        public int DiscountLimitationId { get; set; }



        public int GetDiscountAmount(int amount)
        {
            var result = 0;

            if (UsePercentage)
            {
                result = (((amount) * (DiscountPercentage)) / 100);
            }
            else
            {
                result = DiscountAmount;
            }

            return result;
        }
    }
}

