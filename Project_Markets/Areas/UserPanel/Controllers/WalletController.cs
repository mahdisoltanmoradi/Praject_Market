using System.Threading;
using System.Threading.Tasks;
using Data.Contracts;
using Data.DTOs;
using Microsoft.AspNetCore.Mvc;
using Services.Attributes;

namespace Project_Markets.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    [ControllerInfo("کیف پول", "پنل کاربری")]
    public class WalletController : Controller
    {
        private readonly IUserRepository _userRepository;
        public WalletController(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            ViewBag.ListWallet =await _userRepository.GetWalletUser(User.Identity.Name,cancellationToken);
            return View();
        }

        [HttpPost("ChargeWallet")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(ChargeWalletViewModel charge,CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ListWallet = await _userRepository.GetWalletUser(User.Identity.Name,cancellationToken);
                return View(charge);
            }

            int walletId = await _userRepository.ChargeWallet(User.Identity.Name, charge.Amount, "شارژ حساب",cancellationToken);

            #region Online Payment

            var payment = new ZarinpalSandbox.Payment(charge.Amount);

            var res = await payment.PaymentRequest("شارژ کیف پول", "https://localhost:44321/OnlinePayment/" + walletId);

            if (res.Status == 100)
            {
                return Redirect("https://sandbox.zarinpal.com/pg/StartPay/" + res.Authority);
            }


            #endregion


            return null;
        }


    }
}
