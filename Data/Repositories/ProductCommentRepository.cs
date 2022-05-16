using Common;
using Data.Contracts;
using Entities.Product;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ProductCommentRepository : Repository<ProductComment>, IProductCommentRepository, IScopedDependency
    {
        public ProductCommentRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        public async Task AddProductComment(ProductComment comment, CancellationToken cancellationToken)
        {
            await AddAsync(comment, cancellationToken);
        }

        public async Task<List<ProductComment>> GetAllProductComments(int productId, CancellationToken cancellationToken)
        {
            return await TableNoTracking.Where(p => p.Product.Id == productId).ToListAsync(cancellationToken);
        }
    }
}
