using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Data.Contracts;
using Entities.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.Attributes;

namespace Project_Markets.Areas.Admin.Controllers.Roles
{
    [Area("Admin")]
    [ControllerInfo("نقش ها", "احراز هویت")]
    public class RoleController : Controller
    {
        private readonly IRepository<Role> _roleRepository;
        private readonly IPermissionRepository _permissionRepository;
        private readonly IMapper _mapper;

        public RoleController(IRepository<Role> RoleRepository, IPermissionRepository permissionRepository, IMapper mapper)
        {
            this._roleRepository = RoleRepository;
            this._permissionRepository = permissionRepository;
            this._mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var roleList = await _roleRepository.Table.ToListAsync();
            return View(roleList);
        }

        public async Task<IActionResult> Create(CancellationToken cancellationToken)
        {
            ViewData["Permission"] = await _permissionRepository.GetAllPermission(cancellationToken);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Role role, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return View(role);
            }
            role.IsDelete = false;
            await _roleRepository.AddAsync(role, cancellationToken);
            return Redirect("/Admin/Role/Index");
        }

        public async Task<IActionResult> Delete(int roleId, CancellationToken cancellationToken)
        {
            if (roleId == null)
            {
                return NotFound();
            }
            var roles = await _roleRepository.GetByIdAsync(cancellationToken, roleId);
            return View(roles);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Role role, CancellationToken cancellationToken)
        {
            await _roleRepository.DeleteAsync(role, cancellationToken);
            return RedirectToAction(nameof(Index));
        }

    }
}
