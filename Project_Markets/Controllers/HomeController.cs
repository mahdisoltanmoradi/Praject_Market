using Data.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Project_Markets.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepository _productRepository;
        private readonly IWalletRepository _walletRepository;
        public HomeController(IProductRepository productRepository, IWalletRepository walletRepository)
        {
            this._productRepository = productRepository;
            this._walletRepository = walletRepository;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            ViewData["Slider"] = await _productRepository.GetProductInSlider(cancellationToken);
            return View(await _productRepository.GetTopProduct(cancellationToken));
        }


        [Route("OnlinePayment/{id}")]
        public IActionResult onlinePayment(int id, CancellationToken cancellationToken)
        {
            if (HttpContext.Request.Query["Status"] != "" &&
                HttpContext.Request.Query["Status"].ToString().ToLower() == "ok"
                && HttpContext.Request.Query["Authority"] != "")
            {
                string authority = HttpContext.Request.Query["Authority"];

                var wallet = _walletRepository.GetWalletByWalletId(id, cancellationToken);

                var payment = new ZarinpalSandbox.Payment(wallet.Id);
                var res = payment.Verification(authority).Result;
                if (res.Status == 100)
                {
                    ViewBag.code = res.RefId;
                    ViewBag.IsSuccess = true;
                    wallet.Result.IsPay = true;
                    _walletRepository.UpdateAsync(wallet.Result, cancellationToken);
                }

            }

            return View();
        }
    }
}
