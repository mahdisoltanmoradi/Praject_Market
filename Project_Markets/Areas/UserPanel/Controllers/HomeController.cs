using Data.Contracts;
using Data.DTOs;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace Project_Markets.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IUserRepository _userRepository;
        public HomeController(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            return View(await _userRepository.GetUserInformation(User.Identity.Name,cancellationToken));
        }

        [Route("UserPanel/EditProfile")]
        public async Task<IActionResult> EditProfile(CancellationToken cancellationToken)
        {
            return View(await _userRepository.GetDataForEditProfileUser(User.Identity.Name,cancellationToken));
        }

        [HttpPost]
        [Route("UserPanel/EditProfile")]
        public async Task<IActionResult> EditProfile(EditProfileViewModel editProfile,CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return View(editProfile);
            }
            await _userRepository.EditProfile(User.Identity.Name,editProfile,cancellationToken);

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            
            return Redirect("/Login?EditProfile=true");
        }

    }
}
