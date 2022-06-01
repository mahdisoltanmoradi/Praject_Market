using Common.Enums;
using Data.Contracts;
using Data.DTOs.Baskets;
using Entities.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project_Markets.Models.ViewModels;
using Services.Utilities;
using System;
using System.Threading;

namespace Project_Markets.Controllers
{
    public class BasketController : Controller
    {
        private readonly IBasketRepository _basketRepository;
        private readonly SignInManager<User> signInManager;
        private readonly IUserAddressRepository _userAddressRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IUserRepository _userRepository;
        private string userId = null;

        public BasketController(IBasketRepository basketRepository, SignInManager<User> signInManager, IUserAddressRepository userAddressRepository = null, IOrderRepository orderRepository = null, IPaymentRepository paymentRepository = null, IUserRepository userRepository = null)
        {
            this._basketRepository = basketRepository;
            this.signInManager = signInManager;
            _userAddressRepository = userAddressRepository;
            _orderRepository = orderRepository;
            _paymentRepository = paymentRepository;
            _userRepository = userRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var data = GetOrSetBasket();
            return View(data);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Index(int ProductId, int quantity = 1)
        {
            var basket = GetOrSetBasket();
            _basketRepository.AddItemToBasket(basket.Id, ProductId, quantity);
            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult RemoveItemFromBasket(int ItemId)
        {
            _basketRepository.RemoveItemFromBasket(ItemId);
            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult setQuantity(int basketItemId, int quantity)
        {
            return Json(_basketRepository.SetQuantities(basketItemId, quantity));
        }

        [AllowAnonymous]
        public IActionResult RemoveDiscount(int id)
        {
            _basketRepository.RemoveDiscountFromBasket(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult ShippingPayment(CancellationToken cancellationToken)
        {
            ShippingPaymentViewModel model = new ShippingPaymentViewModel();
            string userId = ClaimUtility.GetUserId(User);
            model.Basket = _basketRepository.GetBasketForUser(userId);
            model.UserAddresses = _userAddressRepository.GetAddress(userId);
            return View(model);
        }

        [HttpPost]
        public IActionResult ShippingPayment(int Address, PaymentMethod PaymentMethod, CancellationToken cancellationToken)
        {
            string userId = ClaimUtility.GetUserId(User);
            var basket = _basketRepository.GetBasketForUser(userId);
            int orderId = _orderRepository.CreateOrder(basket.Id, Address, PaymentMethod);
            if (PaymentMethod == PaymentMethod.OnlinePaymnt)
            {
                //ثبت پرداخت
                var payment = _paymentRepository.PayForOrder(orderId);
                //ارسال به درگاه پرداخت
                return RedirectToAction("Index", "Pay", new { PaymentId = payment.PaymentId });
            }
            else
            {
                //برو به صفحه سفارشات من
                return RedirectToAction("Index", "Orders", new { area = "products" });
            }
        }

        private BasketDto GetOrSetBasket()
        {
            if (signInManager.IsSignedIn(User))
            {
                userId = ClaimUtility.GetUserId(User);
                return _basketRepository.GetOrCreateBasketForUser(userId);
            }
            else
            {
                SetCookiesForBasket();
                return _basketRepository.GetOrCreateBasketForUser(userId);
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
