using Data.Contracts;
using Entities.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Project_Markets.Areas.Admin.Controllers.Products
{
    [Area("Admin")]
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var model =await _productRepository.GetProducts(cancellationToken);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product,CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            await _productRepository.AddAsync(product,cancellationToken);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            return View(_productRepository.GetById(id));
        }

        [HttpPut]
        public async Task<IActionResult> Edit(Product product,CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            await _productRepository.UpdateAsync(product,cancellationToken);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            return View(_productRepository.GetById(id));
        }

        public async Task<IActionResult> Deelete(int id,CancellationToken cancellationToken)
        {
            var result = await _productRepository.DeleteProduct(id,cancellationToken);
            return RedirectToAction(nameof(Index));
        }
    }
}
