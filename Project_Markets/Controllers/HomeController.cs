using Data.Contracts;
using Entities.Blog;
using Entities.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly IRepository<Blogs> _blogrepository;
        private readonly IUserRepository _userRepository;
        public HomeController(IProductRepository productRepository, IRepository<Blogs> repository, IUserRepository userRepository)
        {
            this._productRepository = productRepository;
            this._blogrepository = repository;
            _userRepository = userRepository;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            ViewData["Blogs"] = await _blogrepository.TableNoTracking.OrderByDescending(b => b.BlogVisit).Take(3).ToListAsync();
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

                var wallet = _userRepository.GetWalletByWalletId(id, cancellationToken);

                var payment = new ZarinpalSandbox.Payment(wallet.Result.Amount);
                var res = payment.Verification(authority).Result;
                if (res.Status == 100)
                {
                    ViewBag.code = res.RefId;
                    ViewBag.IsSuccess = true;
                    wallet.Result.IsPay = true;
                    _userRepository.UpdateWallet(wallet.Result, cancellationToken);
                }

            }
            return View();
        }
    }
}
