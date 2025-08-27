using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Common;
using Data.Contracts.Files;
using Entities.Files;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Files
{
    public class FileRepository : Repository<File>, IFileRepository, IScopedDependency
    {
        private readonly ApplicationDbContext _dbContext;
        public FileRepository(ApplicationDbContext context, ApplicationDbContext dbContext)
            : base(context)
        {
            _dbContext = dbContext;
        }
        public async Task AddFile(File file, CancellationToken cancellationToken)
        {
            await AddAsync(file, cancellationToken);
        }

        public async Task<List<File>> GetAllFile(CancellationToken cancellationToken)
        {
            return await TableNoTracking.ToListAsync(cancellationToken);
        }
    }
}
