using Data.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Project_Markets.ViewComponents
{
    public class ProductCategoryComponent:ViewComponent
    {
        private readonly IProductCategoryRepository _productCategory;

        public ProductCategoryComponent(IProductCategoryRepository productCategory)
        {
            this._productCategory = productCategory;
        }

        public async Task<IViewComponentResult> InvokeAsync(CancellationToken cancellationToken)
        {
            return View("ProductCategoryComponent", await _productCategory.GetAllProductCategory(cancellationToken));
        }

    }
}
