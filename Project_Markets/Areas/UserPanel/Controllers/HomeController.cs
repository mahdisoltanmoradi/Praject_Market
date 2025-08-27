using System.Threading;
using System.Threading.Tasks;
using Data.Contracts;
using Data.DTOs;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Attributes;
using Services.Utilities;

namespace Project_Markets.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    [Authorize]
    [ControllerInfo("صفحه داشبورد کاربر", "پنل کاربری")]
    public class HomeController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserAddressRepository _userAddressRepository;
        public HomeController(IUserRepository userRepository, IUserAddressRepository userAddressRepository)
        {
            this._userRepository = userRepository;
            _userAddressRepository = userAddressRepository;
        }
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            ViewData["UserAddress"] = _userAddressRepository.GetAddress(ClaimUtility.GetUserId(User));
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
            
            return Redirect("/Account/Login?EditProfile=true");
        }

    }
}
