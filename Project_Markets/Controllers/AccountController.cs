using Common.Utilities.Convertors;
using Data.Contracts;
using Data.DTOs;
using Entities.User;
using infrastructure.Services.SendEmails;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.SendEmails;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Project_Markets.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private IUserRepository _userRepository;
        private UserManager<User> _userManager;
        IViewRenderService _viewRender;

        public AccountController(IUserRepository userRepository, UserManager<User> userManager, IViewRenderService viewRender)
        {
            this._userRepository = userRepository;
            this._userManager = userManager;
            this._viewRender = viewRender;
        }

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
                Password = register.Password,
                UserAvatar = "Defult.jpg",
                ActiveCode = NameGenerator.GeneratorUniqCode(),
                IsActive = true,
                lifeLocation= "There is no place"
            };
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, register.Password);
            await _userManager.AddToRoleAsync(user, "person");
            var c = await _userManager.CreateAsync(user);
            //await _userRepository.AddAsync(user, cancellationToken);
            return View();
        }

        [Route("Login")]
        public IActionResult Login(bool EditProfile=false)
        {
            ViewBag.EditProfile = EditProfile;
            return View();
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginViewModel login, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var user = await _userRepository.IsExistEmailAndPassword(login, cancellationToken);
            //var user1 =await _userRepository.GetByUserAndPass(user.Email, user.Password, cancellationToken);
            if (user != null)
            {
                if (user.IsActive)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email,login.Email),
                        new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                         new Claim(ClaimTypes.Name,user.UserName)
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
                else
                {
                    ModelState.AddModelError("Email", "حساب کاربری شما فعال نمیباشد");
                }
            }
            ModelState.AddModelError("Email", "کاربری با این مشخصات یافت نشد");
            return View(login);
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
            string bodyEmail = _viewRender.RenderToStringAsync("_ForgotPassword", user);
            SendEmail.Send(forgotPassword.Email, "تغییر رمز", bodyEmail);
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

            var user = await _userRepository.TableNoTracking.SingleOrDefaultAsync(u => u.ActiveCode == token);
            string hashedpass = _userManager.PasswordHasher.HashPassword(user, reset.Password);

            user.Password = reset.Password;

            user.PasswordHash = hashedpass;
            await _userRepository.UpdateAsync(user, cancellationToken);
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
