using Entities.ModelPermission;
using Entities.Role;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
namespace infrastructure.Services.PermissionHelper.ViewModel
{
    public class PermissionListViewModel
    {
        public int? RoleId { get; set; }
        public List<Role> Roles { get; set; }
        public List<PermissionTab> Tabs { get; set; } = new List<PermissionTab>();

        public SelectList GetRolesSelectList()
        {
            return new SelectList(Roles, nameof(Role.Id), nameof(Role.Name));
        }
    }
}
