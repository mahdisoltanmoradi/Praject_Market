using System;
using System.Collections.Generic;
using System.IO;
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
        public async Task<IActionResult> Create(ProductDto dto, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                var categories = await productCategoryRepository.TableNoTracking
                    .Select(c => new { c.Id, c.GroupTitle })
                    .ToListAsync(cancellationToken);

                ViewData["GroupBlogs"] = new SelectList(categories, "Id", "GroupTitle", dto.CategoryId);
                return View(dto);
            }

            var product = _mapper.Map<ProductDto, Product>(dto);

            if (dto.ImageFile != null && dto.ImageFile.Any())
            {
                var imageNames = new List<string>();
                foreach (var file in dto.ImageFile)
                {
                    if (file.Length > 0)
                    {
                        var fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(file.FileName);
                        var savePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/bg-img", fileName);
                        using (var stream = new FileStream(savePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream, cancellationToken);
                        }
                        imageNames.Add(fileName);
                    }
                }
                product.ProductImageName = string.Join(",", imageNames); // ذخیره نام‌ها در یک رشته
            }

            await _productRepository.AddAsync(product, cancellationToken);
            return RedirectToAction(nameof(Index));
        }




        [HttpGet]
        public async Task<IActionResult> Edit(int id, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(cancellationToken, id);
            if (product == null)
                return NotFound();

            // گرفتن دسته‌بندی‌ها برای dropdown
            var categories = await productCategoryRepository.TableNoTracking
                .Select(c => new { c.Id, c.GroupTitle })
                .ToListAsync(cancellationToken);
            ViewData["GroupBlogs"] = new SelectList(categories, "Id", "GroupTitle", product.CategoryId);

            // Map محصول به DTO
            var dto = new ProductDto
            {
                Id = product.Id,
                ProductTitle = product.ProductTitle,
                CategoryId = product.CategoryId,
                ProductPrice = product.ProductPrice,
                DeleteProductPrice = product.DeleteProductPrice,
                ProductCount = product.ProductCount,
                ProductColor = product.ProductColor,
                ProductSize = product.ProductSize,
                Status = product.Status,
                ShowInSlider = product.ShowInSlider,
                Tags = product.Tags,
                ProductDescription = product.ProductDescription,
                ProductImageName = product.ProductImageName // تصاویر قبلی
            };

            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductDto dto, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                var categories = await productCategoryRepository.TableNoTracking
                    .Select(c => new { c.Id, c.GroupTitle })
                    .ToListAsync(cancellationToken);
                ViewData["GroupBlogs"] = new SelectList(categories, "Id", "GroupTitle", dto.CategoryId);
                return View(dto);
            }

            var product = await _productRepository.GetByIdAsync(cancellationToken,dto.Id);
            if (product == null)
                return NotFound();

            // بروز رسانی فیلدهای محصول
            product.ProductTitle = dto.ProductTitle;
            product.CategoryId = dto.CategoryId;
            product.ProductPrice = dto.ProductPrice;
            product.DeleteProductPrice = dto.DeleteProductPrice;
            product.ProductCount = dto.ProductCount;
            product.ProductColor = dto.ProductColor;
            product.ProductSize = dto.ProductSize;
            product.Status = dto.Status;
            product.ShowInSlider = dto.ShowInSlider;
            product.Tags = dto.Tags;
            product.ProductDescription = dto.ProductDescription;

            // مدیریت فایل‌های جدید
            if (dto.ImageFile != null && dto.ImageFile.Count > 0)
            {
                List<string> savedFiles = new List<string>();
                foreach (var file in dto.ImageFile)
                {
                    if (file.Length > 0)
                    {
                        var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/bg-img", fileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream, cancellationToken);
                        }

                        savedFiles.Add(fileName);
                    }
                }

                // تصاویر جدید را به تصاویر قبلی اضافه کن
                if (!string.IsNullOrEmpty(product.ProductImageName))
                    product.ProductImageName += "," + string.Join(",", savedFiles);
                else
                    product.ProductImageName = string.Join(",", savedFiles);
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
