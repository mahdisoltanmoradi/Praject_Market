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
    public class ProductRepsitory : Repository<Product>, IProductRepository, IScopedDependency
    {
        private readonly ApplicationDbContext _dbContext;
        public ProductRepsitory(ApplicationDbContext context, ApplicationDbContext dbContext)
            : base(context)
        {
            _dbContext = dbContext;
        }

        public async Task<Product> GetProductInformation(int productId, CancellationToken cancellationToken)
        {
            var product = await TableNoTracking.FirstOrDefaultAsync(p => p.Id == productId, cancellationToken);
            return product;
        }

        public async Task<IEnumerable<Product>> GetProductInSlider(CancellationToken cancellationToken)
        {
            return await TableNoTracking.OrderByDescending(p => p.CreateDate).Take(4).ToListAsync(cancellationToken);
        }

        public async Task<List<Product>> GetProducts(CancellationToken cancellationToken)
        {
            return await TableNoTracking.ToListAsync(cancellationToken);
        }

        public async Task<List<Product>> GetProducts(int id, CancellationToken cancellationToken)
        {
            var product = await TableNoTracking.Where(p => p.CategoryId == id).ToListAsync();
            return product;
        }

        public async Task<IEnumerable<Product>> GetTopProduct(CancellationToken cancellationToken, int take = 8)
        {
            var product = await TableNoTracking.OrderByDescending(p => p.ProductVisit)
                .Take(take).Distinct().ToListAsync(cancellationToken);
            return product;
        }

        public async Task InsertProduct(Product product, CancellationToken cancellationToken)
        {
            await AddAsync(product, cancellationToken);
        }

        public async Task UpdateProduct(Product product, CancellationToken cancellationToken)
        {
            await UpdateAsync(product, cancellationToken);
        }

        public async Task<Product> DeleteProduct(int productId, CancellationToken cancellationToken)
        {
            var product = await GetByIdAsync(cancellationToken, productId);
            await DeleteAsync(product, cancellationToken);
            return product;
        }
    }
}
