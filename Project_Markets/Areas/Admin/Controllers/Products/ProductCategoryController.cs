using System.Collections.Generic;
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

            if (dto.ImageProduct != null)
            {
                //string imagePath = "";
                //model.ImageProduct = NameGenerator.GeneratorUniqCode() + Path.GetExtension(dto.ImageFile.FileName);
                //imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/bg-img", model.ImageName);
                //using (var stream = new FileStream(imagePath, FileMode.Create))
                //{
                //    dto.ImageProduct.CopyTo(stream);
                //}
            }
            await _productCategoryRepository.AddAsync(model, cancellationToken);
            return Redirect("/Admin/ProductCategory/Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = _productCategoryRepository.GetById(id);
            return View(model);
        }

        [HttpPut]
        public async Task<IActionResult> Edit(ProductCategory productCategory, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return View(productCategory);
            }
            await _productCategoryRepository.UpdateAsync(productCategory, cancellationToken);
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
