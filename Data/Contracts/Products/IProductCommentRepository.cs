using Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Contracts
{
    public interface IProductCommentRepository:IRepository<ProductComment>
    {
        Task<List<ProductComment>> GetAllProductComments(int productId,CancellationToken cancellationToken);
        Task AddProductComment(ProductComment comment,CancellationToken cancellationToken);

    }
}
