using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Common.Utilities.Convertors;
using Data.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project_Markets.DTOs.Blog;
using Services.Attributes;

namespace Project_Markets.Areas.Admin.Controllers.Blogs
{
    [Area("Admin")]
    [ControllerInfo("وبلاگ ها", "پنل ادمین")]
    public class BlogController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IBlogRepository _blogrepository;
        public BlogController(IMapper mapper, IBlogRepository blogRepository)
        {
            this._blogrepository = blogRepository;
            this._mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<List<SelectBlogDto>>> Index(CancellationToken cancellationToken)
        {
            var list = await _blogrepository.TableNoTracking.ProjectTo<SelectBlogDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> Create(CancellationToken cancellationToken)
        {
            var result = await _blogrepository.GetGroupBlogs(cancellationToken);
            ViewData["GroupBlogs"] = new SelectList(result, "Value", "Text");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BlogDto dto, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<BlogDto, Entities.Blog.Blogs>(dto);

            if (dto.ImageBlog != null)
            {
                string imagePath = "";
                model.ImageName = NameGenerator.GeneratorUniqCode() + Path.GetExtension(dto.ImageBlog.FileName);
                imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/bg-img", model.ImageName);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    dto.ImageBlog.CopyTo(stream);
                }
            }
            await _blogrepository.AddAsync(model, cancellationToken);
            return Redirect("/Admin/Blog/Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id, CancellationToken cancellationToken)
        {
            var model = await _blogrepository.GetByIdAsync(cancellationToken, id);
            var projected = _mapper.Map<Entities.Blog.Blogs, BlogDto>(model);
            return View(projected);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BlogDto dto, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<BlogDto, Entities.Blog.Blogs>(dto);

            if (!ModelState.IsValid) return View(dto);
            await _blogrepository.UpdateAsync(model, cancellationToken);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id, CancellationToken cancellationToken)
        {
            var model = await _blogrepository.GetByIdAsync(cancellationToken, id);
            var projected = _mapper.Map<Entities.Blog.Blogs, BlogDto>(model);
            return View(projected);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var model = await _blogrepository.GetByIdAsync(cancellationToken, id);
            await _blogrepository.DeleteAsync(model, cancellationToken);
            return RedirectToAction(nameof(Index));
        }
    }
}
