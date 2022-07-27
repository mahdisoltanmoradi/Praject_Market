using Data.Contracts.Blogs;
using Entities.Blog;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Blogs
{
    public class BlogCategoryRepository:Repository<BlogCategories>, IBlogCategoryRepository
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
