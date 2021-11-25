using Data.Contracts;
using Data.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace Project_Markets.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    public class WalletController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IWalletRepository _walletRepository;
        public WalletController(IUserRepository userRepository,IWalletRepository walletRepository)
        {
            this._userRepository = userRepository;
            this._walletRepository = walletRepository;
        }

        [Route("UserPanel/Wallet")]
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            ViewBag.ListWallet =await _walletRepository.GetWalletUser(User.Identity.Name,cancellationToken);
            return View();
        }

        [HttpPost]
        [Route("UserPanel/Wallet")]
        public async Task<IActionResult> Index(ChargeWalletViewModel charge,CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ListWallet = await _walletRepository.GetWalletUser(User.Identity.Name,cancellationToken);
                return View(charge);
            }

            int walletId =await _walletRepository.ChargeWallet(User.Identity.Name, charge.Amount, "شارژ حساب",cancellationToken);

            #region Online Payment

            var payment = new ZarinpalSandbox.Payment(charge.Amount);

            var res = payment.PaymentRequest("شارژ کیف پول", "https://localhost:5002/OnlinePayment/" + walletId);

            if (res.Result.Status == 100)
            {
                return Redirect("https://sandbox.zarinpal.com/pg/StartPay/" + res.Result.Authority);
            }

            #endregion


            return null;
        }


    }
}
