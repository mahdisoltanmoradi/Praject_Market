
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Entities.Product;

namespace Data.Contracts
{
    public interface IProductCategoryRepository : IRepository<ProductCategory>
    {
        Task<List<ProductCategory>> GetAllProductCategory(CancellationToken cancellationToken);
        Task InsertProductCategory(ProductCategory productCategory, CancellationToken cancellationToken);
        Task UpdateProductCategory(ProductCategory productCategory, CancellationToken cancellationToken);
        Task<ProductCategory> DeleteProductCategory(int productCategoryId, CancellationToken cancellationToken);
    }
}
