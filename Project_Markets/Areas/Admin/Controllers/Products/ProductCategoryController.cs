using Data.Contracts;
using Entities.Product;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Project_Markets.Areas.Admin.Controllers.Products
{
    [Area("Admin")]
    public class ProductCategoryController : Controller
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryController(IProductCategoryRepository productCategoryRepository)
        {
            this._productCategoryRepository = productCategoryRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var model =await _productCategoryRepository.GetAllProductCategory(cancellationToken);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCategory productCategory,CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return View(productCategory);
            }

            await _productCategoryRepository.AddAsync(productCategory,cancellationToken);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model =_productCategoryRepository.GetById(id);
            return View(model);
        }

        [HttpPut]
        public async Task<IActionResult> Edit(ProductCategory productCategory,CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return View(productCategory);
            }
            await _productCategoryRepository.UpdateAsync(productCategory,cancellationToken);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = _productCategoryRepository.GetById(id);
            return View(model);
        }

        [HttpPut]
        public async Task<IActionResult> Delete(ProductCategory productCategory, CancellationToken cancellationToken)
        {
            await _productCategoryRepository.DeleteAsync(productCategory, cancellationToken);
            return RedirectToAction(nameof(Index));
        }
    }
}
