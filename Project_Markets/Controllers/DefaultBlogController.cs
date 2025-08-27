using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Data.Contracts;
using Entities.Blog;
using Entities.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_Markets.DTOs.Blog;
using Services.Attributes;

namespace Project_Markets.Controllers
{
    [ControllerInfo("وبلاگ ها", "عمومی")]
    public class DefaultBlogController : Controller
    {
        private readonly IRepository<Blogs> _blogRepository;
        private readonly IRepository<BlogComments> _blogComment;
        private readonly IRepository<User> _userRepository;
        private readonly IMapper _mapper;
        public DefaultBlogController(IRepository<Blogs> repository
            ,IRepository<BlogComments> blogComment
            ,IMapper mapper
            ,IRepository<User> userrepository)
        {
            this._blogRepository = repository;
            this._blogComment = blogComment;
            _mapper = mapper;
            _userRepository = userrepository;
        }
        [HttpGet]
        public async Task<ActionResult> Index(CancellationToken cancellationToken,string filterBlogs="")
        {
            var blog = await _blogRepository.TableNoTracking.ToListAsync();
            if (!string.IsNullOrEmpty(filterBlogs))
            {
                blog.FirstOrDefault(u => u.BlogTitle.Contains(filterBlogs));
            }
            
            return View(blog);
        }

        [HttpGet]
        public async Task<IActionResult> GetBlogInformation(int id,CancellationToken cancellationToken)
        {
            var model = await _blogRepository.GetByIdAsync(cancellationToken, id);
            if (model!=null)
            {
                model.BlogVisit += 1;
                var blogDto = _mapper.Map<Blogs, BlogDto>(model);
                ViewData["BlogComments"] = await _blogComment.TableNoTracking.Where(b=>b.Id==id).ToListAsync();
                return View(blogDto);
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> GetBlogInformation(BlogComments comments,CancellationToken cancellationToken)
        {
            await _blogComment.AddAsync(comments,cancellationToken);  
            return View();
        }
    }
}
