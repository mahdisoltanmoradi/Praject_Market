using System;
using System.Collections.Generic;
using System.IO;
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
                return View(dto);
            }

            if (await _blogCategoryRepository.TableNoTracking.AnyAsync(p => p.BlogCategoryTitle == dto.BlogCategoryTitle, cancellationToken))

            {
                ViewBag.IsExist = true;
                return View(dto);
            }

            string imageName = null;

            // ذخیره تصویر
            if (dto.ImageFile != null && dto.ImageFile.Length > 0)
            {
                imageName = Guid.NewGuid().ToString() + Path.GetExtension(dto.ImageFile.FileName);
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/bg-img", imageName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await dto.ImageFile.CopyToAsync(stream, cancellationToken);
                }
            }

            BlogCategories blogCategories = new BlogCategories()
            {
                BlogCategoryTitle = dto.BlogCategoryTitle,
                CreateDate = DateTime.Now,
                IsActive = dto.IsActive,
                IsDelete = false,
                ImageName = imageName
            };

            await _blogCategoryRepository.AddAsync(blogCategories, cancellationToken);
            return RedirectToAction("Index", "BlogCategory");
        }


        [HttpGet]
        public async Task<ActionResult> Edit(int id, CancellationToken cancellationToken)
        {
            var entity = await _blogCategoryRepository.GetByIdAsync(cancellationToken, id);
            if (entity == null) return NotFound();

            var dto = new BlogCategoryDto()
            {
                BlogCategoryTitle = entity.BlogCategoryTitle,
                IsActive = entity.IsActive,
                ImageName = entity.ImageName
            };

            return View(dto);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(int id, BlogCategoryDto dto, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Title", "فیلدهای مورد نظر را پرکنید");
                return View(dto);
            }

            var entity = await _blogCategoryRepository.GetByIdAsync(cancellationToken, id);
            if (entity == null) return NotFound();

            if (await _blogCategoryRepository.TableNoTracking
                .AnyAsync(p => p.BlogCategoryTitle == dto.BlogCategoryTitle && p.Id != id, cancellationToken))
            {
                ViewBag.IsExist = true;
                return View(dto);
            }

            // آپدیت فیلدها
            entity.BlogCategoryTitle = dto.BlogCategoryTitle;
            entity.IsActive = dto.IsActive;

            // اگر عکس جدید آپلود شد
            if (dto.ImageFile != null && dto.ImageFile.Length > 0)
            {
                var imageName = Guid.NewGuid().ToString() + Path.GetExtension(dto.ImageFile.FileName);
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/bg-img", imageName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await dto.ImageFile.CopyToAsync(stream, cancellationToken);
                }

                entity.ImageName = imageName;
            }

            await _blogCategoryRepository.UpdateAsync(entity, cancellationToken);
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
