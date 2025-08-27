using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Data.Contracts;
using Data.Contracts.Blogs;
using Entities.Blog;
using infrastructure.WebFramework.CrudRefrences;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_Markets.DTOs.Blog;
using Services.Attributes;

namespace Project_Markets.Areas.Admin.Controllers.Blogs
{
    [Area("Admin")]
    [Authorize]
    [ControllerInfo("دسته های وبلاگ", "پنل ادمین")]
    public class BlogCategoryController : Controller
    {
        private readonly IBlogCategoryRepository _blogCategoryRepository;
        public BlogCategoryController(IBlogCategoryRepository blogCategoryRepository)
        {
            this._blogCategoryRepository = blogCategoryRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<BlogCategories>>> Index()
        {
            return View(await _blogCategoryRepository.GetBlogCategoriesAsync());
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(BlogCategoryDto dto, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Title", "فیلدهای مورد نظر را پرکنید");
                return View();
            }

            if (await _blogCategoryRepository.TableNoTracking.AnyAsync(p => p.BlogCategoryTitle == dto.Title))
            {
                ViewBag.IsExist = true;
                return View(dto);
            }

            BlogCategories blogCategories = new BlogCategories()
            {
                BlogCategoryTitle = dto.Title,
                CreateDate = DateTime.Now,
                IsActive = true,
                IsDelete = false,
            };
            await _blogCategoryRepository.AddAsync(blogCategories, cancellationToken);
            return RedirectToAction("Index","BlogCategory");
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id,CancellationToken cancellationToken)
        {
            return View(await _blogCategoryRepository.GetByIdAsync(cancellationToken, id));
        }

        [HttpPost]
        public async Task<ActionResult> Edit(int id,BlogCategoryDto dto,CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Title", "فیلدهای مورد نظر را پرکنید");
                return View(dto);
            }
            if (await _blogCategoryRepository.TableNoTracking.AnyAsync(p=>p.BlogCategoryTitle==dto.Title))
            {
                ViewBag.IsExist = true;
                return View(dto);
            }
            BlogCategories blogCategories = new BlogCategories()
            {
                BlogCategoryTitle=dto.Title,
            };
           await _blogCategoryRepository.UpdateAsync(blogCategories,cancellationToken);
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> Delete(int id,CancellationToken cancellationToken)
        {
            var result =await _blogCategoryRepository.GetByIdAsync(cancellationToken,id);
            await _blogCategoryRepository.DeleteAsync(result, cancellationToken);
            return RedirectToAction(nameof(Index));
        }

    }
}
