using Common;
using Data.Contracts;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class BlogRepository : Repository<Entities.Blog.Blogs>, IBlogRepository, IScopedDependency
    {
        public BlogRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        public async Task<List<SelectListItem>> GetGroupBlogs(CancellationToken cancellationToken)
        {
            return await TableNoTracking
                .Select(g => new SelectListItem()
                {
                    Text = g.Category.BlogCategoryTitle,
                    Value = g.Category_id.ToString()
                }).ToListAsync(cancellationToken);
        }
    }
}
