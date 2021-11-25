using AutoMapper;
using Common;
using Data.Contracts;
using DynamicPermission.AspNetCore.ViewModels;
using Entities.Role;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class RoleRepository : Repository<Role>, IRoleRepository, IScopedDependency
    {
        private readonly IMapper _mapper;
        public RoleRepository(ApplicationDbContext context,IMapper mapper)
            :base(context)
        {
            this._mapper = mapper;
        }

        public async Task AddAsync(RoleViewModel role, CancellationToken cancellationToken)
        {
            var roles = _mapper.Map<Role>(role);
            await AddAsync(roles,cancellationToken);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var role = await TableNoTracking.FirstOrDefaultAsync(r => r.Id == id);
            await DeleteAsync(role,cancellationToken);
        }

        public async Task<List<Role>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await Table.ToListAsync();
        }

        public async Task<Role> GetByIdIncludePermissionsAsync(int id, CancellationToken cancellationToken)
        {
            return await TableNoTracking.Include(p => p.Permissions).FirstOrDefaultAsync(p => p.Id == id);
        }

    }
}
