using Data.Contracts;
using Data.DTOs;
using Data.DTOs.AdminViewModel;
using Entities.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Project_Markets.Areas.Admin.Controllers.Users
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;

        public UserController(IUserRepository userRepository, UserManager<User> userManager)
        {
            this._userRepository = userRepository;
            this._userManager = userManager;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken, UserForAdminViewModel user, int pageId = 1, string filterUserName = "", string filterEmail = "")
        {
            if (!ModelState.IsValid)
            {

            }
            var users = await _userRepository.GetUsers(cancellationToken, pageId, filterEmail, filterUserName);

            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> Create(CancellationToken cancellationToken)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserViewModel createUser, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _userRepository.AddUserFromAdmin(createUser, cancellationToken);
            return Redirect("/Admin/User/");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserForShowInEditMode(id, cancellationToken);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditUserViewModel editUser, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return View(editUser);
            }
            await _userRepository.EditUserFromAdmin(editUser, cancellationToken);
            return Redirect("/Admin/User/");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            ViewData["UserId"] = id;
            var user = await _userRepository.GetUserInformation(id, cancellationToken);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int userId,User user,CancellationToken cancellationToken)
        {
            await _userRepository.DeleteUser(userId,cancellationToken);
            return Redirect("/Admin/User/");
        }


        [HttpGet]
        public async Task<IActionResult> ListDeleteUsers(CancellationToken cancellationToken, UserForAdminViewModel user, int pageId = 1, string filterUserName = "", string filterEmail = "")
        {
            var users = await _userRepository.GetDeleteUsers(cancellationToken, pageId, filterEmail, filterUserName);

            return View(users);
        }



    }
}
