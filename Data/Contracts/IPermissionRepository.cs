using Data.DTOs.Permission;
using Entities.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Contracts
{
    public interface IPermissionRepository : IRepository<Permission>
    {
        Task<List<Permission>> GetAllPermission(CancellationToken cancellationToken);
        Task AddPermissionToRole(int roleId, List<int> permission, CancellationToken cancellationToken);
        Task<List<int>> PermissionRole(int roleId, CancellationToken cancellationToken);
        Task UpdatePermission(int roleId, List<int> permissions, CancellationToken cancellationToken);
        Task AddPermissionsIfNotExistsAsync(RolePermissionViewModel model);
        Task DeletePermissionsAsync(RolePermissionViewModel model);
        Task<bool> UserHasPermissionAsync(int userId, string actionFullName);
    }
}
