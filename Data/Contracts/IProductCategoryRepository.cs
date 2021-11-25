
using Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Contracts
{
    public interface IProductCategoryRepository: IRepository<ProductCategory>
    {
        Task<List<ProductCategory>> GetAllProductCategory(CancellationToken cancellationToken);
    }
}
