using Data.Contracts.CatalogItems;
using Entities.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Attributes;

namespace Project_Markets.Areas.UserPanel.Controllers
{
    [Authorize]
    [Area("UserPanel")]
    [ControllerInfo("علاقه مندی ها", "پنل کاربری")]
    public class MyFavouriteController : Controller
    {
        private readonly ICatalogItemRepository _catalogItemRepository;
        private readonly UserManager<User> _userManager;

        public MyFavouriteController(ICatalogItemRepository catalogItemRepository
            , UserManager<User> userManager)
        {
            this._catalogItemRepository=catalogItemRepository;
            this._userManager = userManager;
        }
        public IActionResult Index(int page = 1, int pageSize = 20)
        {
            var user = _userManager.GetUserAsync(User).Result;
            var data = _catalogItemRepository.GetMyFavourite(user.Id.ToString(), page, pageSize);
            return View(data);
        }

        public IActionResult AddToMyFavourite(int CatalogItemId)
        {
            var user = _userManager.GetUserAsync(User).Result;
            _catalogItemRepository.AddToMyFavourite(user.Id.ToString(), CatalogItemId);
            return RedirectToAction(nameof(Index));
        }


    }
}
