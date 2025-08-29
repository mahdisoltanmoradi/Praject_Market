using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Data.Contracts.Blogs;
using Entities.Blog;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Blogs
{
    public class BlogCategoryRepository:Repository<BlogCategories>, IBlogCategoryRepository, IScopedDependency
    {
        public BlogCategoryRepository(ApplicationDbContext context)
            :base(context)
        {

        }

        public async Task<List<BlogCategories>> GetBlogCategoriesAsync()
        {
            return await TableNoTracking.ToListAsync();
        }
    }
}
