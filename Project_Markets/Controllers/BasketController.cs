using Data.Contracts;
using Data.DTOs.Baskets;
using Entities.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Markets.Controllers
{
    public class BasketController : Controller
    {
        private readonly IBasketRepository basketRepository;
        private readonly SignInManager<User> signInManager;
        private string userId = null;

        public BasketController(IBasketRepository basketRepository, SignInManager<User> signInManager)
        {
            this.basketRepository = basketRepository;
            this.signInManager = signInManager;
        }
        public IActionResult Index()
        {
            var data = GetOrSetBasket();
            return View(data);
        }

        [HttpPost]
        public IActionResult Index(int CatalogitemId, int quantity = 1)
        {
            var basket = GetOrSetBasket();
            basketRepository.AddItemToBasket(basket.Id, CatalogitemId, quantity);
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public IActionResult RemoveItemFromBasket(int ItemId)
        {
            basketRepository.RemoveItemFromBasket(ItemId);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult setQuantity(int basketItemId, int quantity)
        {
            return Json(basketRepository.SetQuantities(basketItemId, quantity));
        }

        private BasketDto GetOrSetBasket()
        {
            if (signInManager.IsSignedIn(User))
            {
                return basketRepository.GetOrCreateBasketForUser(User.Identity.Name);
            }
            else
            {
                SetCookiesForBasket();
                return basketRepository.GetOrCreateBasketForUser(userId);
            }
        }

        private void SetCookiesForBasket()
        {
            string basketCookieName = "BasketId";
            if (Request.Cookies.ContainsKey(basketCookieName))
            {
                userId = Request.Cookies[basketCookieName];
            }
            if (userId != null) return;
            userId = Guid.NewGuid().ToString();
            var cookieOptions = new CookieOptions { IsEssential = true };
            cookieOptions.Expires = DateTime.Today.AddYears(2);
            Response.Cookies.Append(basketCookieName, userId, cookieOptions);


        }
    }
}
