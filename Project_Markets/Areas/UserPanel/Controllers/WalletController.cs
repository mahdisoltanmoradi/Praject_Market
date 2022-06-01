using Data.Contracts;
using Data.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace Project_Markets.Areas.UserPanel.Controllers
{
    [Authorize]
    [Area("UserPanel")]
    public class WalletController : Controller
    {
        private readonly IUserRepository _userRepository;
        public WalletController(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        [Route("UserPanel/Wallet")]
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            ViewBag.ListWallet =await _userRepository.GetWalletUser(User.Identity.Name,cancellationToken);
            return View();
        }

        [HttpPost]
        [Route("UserPanel/Wallet")]
        public async Task<IActionResult> Index(ChargeWalletViewModel charge,CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ListWallet = await _userRepository.GetWalletUser(User.Identity.Name,cancellationToken);
                return View(charge);
            }

            int walletId =await _userRepository.ChargeWallet(User.Identity.Name, charge.Amount, "شارژ حساب",cancellationToken);

            #region Online Payment

            var payment = new ZarinpalSandbox.Payment(charge.Amount);

            var res = payment.PaymentRequest("شارژ کیف پول", "http://localhost:13148/OnlinePayment/" + walletId);

            if (res.Result.Status == 100)
            {
                return Redirect("https://sandbox.zarinpal.com/pg/StartPay/" + res.Result.Authority);
            }

            #endregion


            return null;
        }


    }
}
