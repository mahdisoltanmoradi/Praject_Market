using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data.Contracts;
using Entities.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_Markets.DTOs.Product;
using Services.Attributes;

namespace Project_Markets.Areas.Admin.Controllers.Products
{
    [Area("Admin")]
    [ControllerInfo("دسته بندی محصولات", "پنل ادمین")]
    public class ProductCategoryController : Controller
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IMapper _mapper;

        public ProductCategoryController(IProductCategoryRepository productCategoryRepository, IMapper mapper)
        {
            this._productCategoryRepository = productCategoryRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<List<ProductCategoryDto>>> Index(CancellationToken cancellationToken)
        {
            var list = await _productCategoryRepository.TableNoTracking.ProjectTo<ProductCategoryDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCategoryDto dto, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<ProductCategoryDto, ProductCategory>(dto);

            if (dto.ImageFile != null && dto.ImageFile.Length > 0)
            {
                // تولید اسم یکتا برای فایل
                var fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(dto.ImageFile.FileName);

                // مسیر ذخیره‌سازی
                var savePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/bg-img", fileName);

                using (var stream = new FileStream(savePath, FileMode.Create))
                {
                    await dto.ImageFile.CopyToAsync(stream, cancellationToken);
                }

                // ذخیره نام فایل در دیتابیس
                model.ImageProduct = fileName;
            }

            await _productCategoryRepository.AddAsync(model, cancellationToken);

            return Redirect("/Admin/ProductCategory/Index");
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id, CancellationToken cancellationToken)
        {
            var entity = await _productCategoryRepository.GetByIdAsync(cancellationToken,id);
            if (entity == null)
                return NotFound();

            // مپ به DTO
            var dto = _mapper.Map<ProductCategoryDto>(entity);
            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductCategoryDto dto, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            // دریافت موجودی از دیتابیس
            var entity = await _productCategoryRepository.GetByIdAsync(cancellationToken, dto.Id);
            if (entity == null)
                return NotFound();

            // بروزرسانی فیلدها
            entity.GroupTitle = dto.GroupTitle;

            if (dto.ImageFile != null && dto.ImageFile.Length > 0)
            {
                // تولید اسم یکتا برای فایل جدید
                var fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(dto.ImageFile.FileName);
                var savePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/bg-img", fileName);

                using (var stream = new FileStream(savePath, FileMode.Create))
                {
                    await dto.ImageFile.CopyToAsync(stream, cancellationToken);
                }

                // حذف تصویر قبلی (در صورت وجود)
                if (!string.IsNullOrEmpty(entity.ImageProduct))
                {
                    var oldPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/bg-img", entity.ImageProduct);
                    if (System.IO.File.Exists(oldPath))
                        System.IO.File.Delete(oldPath);
                }

                entity.ImageProduct = fileName;
            }

            await _productCategoryRepository.UpdateAsync(entity, cancellationToken);

            return RedirectToAction("/Admin/ProductCategory/Index");
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
