using DynamicPermission.AspNetCore.ViewModels;
using Entities.Role;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Contracts
{
    public interface IRoleRepository
    {
        Task AddAsync(RoleViewModel role,CancellationToken cancellationToken);
        Task DeleteAsync(int id,CancellationToken cancellationToken);
        Task<List<Role>> GetAllAsync(CancellationToken cancellationToken);
        Task<Role> GetByIdIncludePermissionsAsync(int id,CancellationToken cancellationToken);
    }
}