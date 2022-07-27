using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Contracts
{
    public interface IBlogRepository : IRepository<Entities.Blog.Blogs>
    {
        Task<List<SelectListItem>> GetGroupBlogs(CancellationToken cancellationToken);
    }
}
