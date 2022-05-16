using Common.Utilities.Convertors;
using Data.Contracts;
using Data.DTOs;
using Entities.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Project_Markets.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;
        //private readonly IViewRenderService _viewRender;

        public AccountController(IUserRepository userRepository, UserManager<User> userManager/*, IViewRenderService viewRender*/)
        {
            this._userRepository = userRepository;
            this._userManager = userManager;
            //this._viewRender = viewRender;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel register, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return View(register);
            }

            User user = new User()
            {
                UserName = register.UserName,
                Email = register.Email,
                RegisterDate = DateTime.Now,
                PasswordHash = register.Password,
                UserAvatar = "Defult.jpg",
                ActiveCode = NameGenerator.GeneratorUniqCode(),
                IsActive = true,
                lifeLocation = "There is no place",
                SecurityStamp = Guid.NewGuid().ToString("D")
            };
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, register.Password);
            await _userRepository.AddUser(user, cancellationToken);

            await _userManager.AddToRoleAsync(user, "person");
            //await _userRepository.AddAsync(user, cancellationToken);
            return View();
        }

        [HttpGet]
        public IActionResult Login(bool EditProfile = false)
        {
            ViewBag.EditProfile = EditProfile;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }
            //var user1 = await _userRepository.TableNoTracking.FirstOrDefaultAsync(p => p.Email == login.Email);
            var user = await _userManager.FindByEmailAsync(login.Email);
            if (user == null)
            {
                ModelState.AddModelError("Email", "کاربری با این مشخصات یافت نشد");
                return View(login);
            }
            var password = await _userRepository.ExistPassword(login.Password);
            //if (password ==)
            //{
            //    ModelState.AddModelError("Email", "حساب کاربری شما فعال نمیباشد");
            //    return View(login);

            //}

            var roles = await _userManager.GetRolesAsync(user);
            var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email,login.Email),
                        new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                         new Claim(ClaimTypes.Name,user.UserName),
                         new Claim(ClaimTypes.Role,roles.SingleOrDefault())
                    };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(30)
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

            ViewBag.IsSuccess = true;
            return View();

        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel forgotPassword, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return View(forgotPassword);
            }
            string fixdEmail = FixedText.FixeEmail(forgotPassword.Email);
            User user = await _userRepository.IsExistUserByUserEmail(fixdEmail, cancellationToken);
            if (user == null)
            {
                ModelState.AddModelError("Email", "کاربری یافت نشد");
            }
            //string bodyEmail = _viewRender.RenderToStringAsync("_ForgotPassword", user);
            //SendEmail.Send(forgotPassword.Email, "تغییر رمز", bodyEmail);
            return RedirectToAction("ForgotPasswordSuccess");
        }

        public IActionResult ForgotPasswordSuccess()
        {
            return View();
        }

        public IActionResult ResetForgotPassword(string token)
        {
            ViewData["token"] = token;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetForgotPassword(string token, ResetForgotPasswordViewModel reset, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return View(reset);
            }

            var user = await _userRepository.ExistActiveCode(token);
            string hashedpass = _userManager.PasswordHasher.HashPassword(user, reset.Password);

            user.PasswordHash = reset.Password;

            user.PasswordHash = hashedpass;
            await _userRepository.UpdateUser(user, cancellationToken);
            ViewBag.IsSuccess = true;
            return RedirectToAction(nameof(Login));
        }

        #region Logout
        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/Account/Login");
        }
        #endregion
    }
}
