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
    public class ProductCategoryRepository : Repository<ProductCategory>, IProductCategoryRepository, IScopedDependency
    {
        public ProductCategoryRepository(ApplicationDbContext context)
            :base(context)
        {

        }

        public async Task<List<ProductCategory>> GetAllProductCategory(CancellationToken cancellationToken)
        {
            return await TableNoTracking.ToListAsync(cancellationToken);
        }
    }
}
