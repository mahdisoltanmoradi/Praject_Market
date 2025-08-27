using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data.Contracts;
using Entities.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project_Markets.DTOs.Products;
using Services.Attributes;

namespace Project_Markets.Areas.Admin.Controllers.Products
{
    [Area("Admin")]
    [ControllerInfo("محصولات", "پنل ادمین")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductCategoryRepository productCategoryRepository;
        private readonly IMapper _mapper;

        public ProductController(IProductRepository productRepository, IMapper mapper, IProductCategoryRepository productCategoryRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            this.productCategoryRepository = productCategoryRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<SelectProductDto>>> Index(CancellationToken cancellationToken)
        {
            var list = await _productRepository.TableNoTracking.ProjectTo<SelectProductDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> Create(CancellationToken cancellationToken)
        {
            var categories = await productCategoryRepository.TableNoTracking
                .Select(c => new { c.Id, c.GroupTitle })
                .ToListAsync(cancellationToken);

            ViewData["GroupBlogs"] = new SelectList(categories, "Id", "GroupTitle");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                var categories = await productCategoryRepository.TableNoTracking
                    .Select(c => new { c.Id, c.GroupTitle })
                    .ToListAsync(cancellationToken);

                ViewData["GroupBlogs"] = new SelectList(categories, "Id", "GroupTitle", product.CategoryId);

                return View(product);
            }

            await _productRepository.AddAsync(product, cancellationToken);
            return RedirectToAction(nameof(Index));
        }



        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            return View(_productRepository.GetById(id));
        }

        [HttpPut]
        public async Task<IActionResult> Edit(Product product, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            await _productRepository.UpdateAsync(product, cancellationToken);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            return View(_productRepository.GetById(id));
        }

        public async Task<IActionResult> Deelete(int id, CancellationToken cancellationToken)
        {
            var result = await _productRepository.DeleteProduct(id, cancellationToken);
            return RedirectToAction(nameof(Index));
        }
    }
}
