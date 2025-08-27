using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Common;
using Data.Contracts;
using Entities.Product;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class ProductCategoryRepository : Repository<ProductCategory>, IProductCategoryRepository, IScopedDependency
    {
        public ProductCategoryRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        public async Task<List<ProductCategory>> GetAllProductCategory(CancellationToken cancellationToken)
        {
            return await TableNoTracking.ToListAsync(cancellationToken);
        }

        public async Task InsertProductCategory(ProductCategory productCategory, CancellationToken cancellationToken)
        {
            await AddAsync(productCategory, cancellationToken);
        }

        public async Task UpdateProductCategory(ProductCategory productCategory, CancellationToken cancellationToken)
        {
            await UpdateAsync(productCategory, cancellationToken);
        }

        public async Task<ProductCategory> DeleteProductCategory(int productCategoryId, CancellationToken cancellationToken)
        {
            var productCategory = await GetByIdAsync(cancellationToken, productCategoryId);
            await DeleteAsync(productCategory, cancellationToken);
            return productCategory;
        }
    }
}
