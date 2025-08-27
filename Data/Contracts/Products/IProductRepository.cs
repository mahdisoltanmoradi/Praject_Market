using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Entities.Product;

namespace Data.Contracts
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<List<Product>> GetProducts(CancellationToken cancellationToken);
        Task<List<Product>> GetProducts(int id, CancellationToken cancellationToken);
        Task<Product> GetProductInformation(int productId, CancellationToken cancellationToken);
        Task<IEnumerable<Product>> GetProductInSlider(CancellationToken cancellationToken);
        Task<IEnumerable<Product>> GetTopProduct(CancellationToken cancellationToken, int take = 8);
        Task InsertProduct(Product product, CancellationToken cancellationToken);
        Task UpdateProduct(Product product, CancellationToken cancellationToken);
        Task<Product> DeleteProduct(int productId, CancellationToken cancellationToken);

    }
}
