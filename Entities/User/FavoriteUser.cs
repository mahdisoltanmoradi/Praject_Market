using Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.User
{
    public class FavoriteUser:BaseEntity<int>
    {
        public int FavoriteId { get; set; }
        public int UserId { get; set; }
        

        #region Relation
        public List<User> Users { get; set; }
        #endregion
    }
}
