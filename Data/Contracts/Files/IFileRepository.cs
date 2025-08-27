using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Entities.Files;

namespace Data.Contracts.Files
{
    public interface IFileRepository
    {
        Task<List<File>> GetAllFile(CancellationToken cancellationToken);
        Task AddFile(File file, CancellationToken cancellationToken);
    }
}
