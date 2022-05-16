using Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Entities.Order
{
    public class Order : BaseEntity<int>
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int OrderSum { get; set; }

        public bool IsFinaly { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }


        public virtual User.User User { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}
