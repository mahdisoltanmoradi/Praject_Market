using Entities.Blog;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Contracts.Blogs
{
    public interface IBlogCategoryRepository:IRepository<BlogCategories>
    {
        Task<List<BlogCategories>> GetBlogCategoriesAsync();
    }
}
