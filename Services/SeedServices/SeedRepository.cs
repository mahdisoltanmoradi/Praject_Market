using Common;
using Data.Contracts;
using Entities.Role;
using Entities.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Services.SeedServices
{
    public class SeedRepository : ISeedRepository, IScopedDependency
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;
        public SeedRepository(RoleManager<Role> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task SeedAsync()
        {
            if (!_roleManager.RoleExistsAsync("Admin").GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new Role { Name = "Admin" }).GetAwaiter().GetResult();
            }
            if (!_roleManager.RoleExistsAsync("User").GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new Role { Name = "User" }).GetAwaiter().GetResult();
            }
            if (!_userManager.Users.AsNoTracking().Any(p => p.UserName == "Admin"))
            {
                var user = new User
                {
                    UserName = "admin",
                    Email = "admin@site.com",
                    LockoutEnabled = false,
                    PhoneNumber = "admin"
                };
                if (_userManager.CreateAsync(user, "adminroot").GetAwaiter().GetResult().Succeeded)
                    _userManager.AddToRoleAsync(user, "Admin").GetAwaiter().GetResult();



            }
            if (!_userManager.Users.AsNoTracking().Any(p => p.UserName == "User"))
            {
                var user = new User
                {
                    UserName = "user",
                    Email = "user@site.com",
                    LockoutEnabled = false,
                    PhoneNumber = "user"
                };
                if (_userManager.CreateAsync(user, "user12345").GetAwaiter().GetResult().Succeeded)
                    _userManager.AddToRoleAsync(user, "User").GetAwaiter().GetResult();
            }
        }
    }

}
