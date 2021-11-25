using Entities.Common;
using Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Product
{
    public class ProductComment:BaseEntity<int>
    {
        public int UserId { get; set; }
        public string Message { get; set; }
        public Rank ScoreUser { get; set; }
        public DateTime CreateDate { get; set; }


        #region Ralation
        public User.User User { get; set; }
        public Product Product{ get; set; }
        #endregion

    }
}
