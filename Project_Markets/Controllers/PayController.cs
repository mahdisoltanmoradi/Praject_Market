using Data.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ZarinPal.Class;
using Microsoft.Extensions.Configuration;
using Services.Utilities;
using Newtonsoft.Json;
using Dto.Payment;
using RestSharp;

namespace Project_Markets.Controllers
{
    public class PayController : Controller
    {
        private readonly ZarinPal.Class.Payment _payment;
        private readonly Authority _authority;
        private readonly Transactions _transactions;


        private readonly IConfiguration configuration;
        private readonly IPaymentRepository _paymentRepository;
        private readonly string merchendId;

        public PayController(IConfiguration configuration, IPaymentRepository paymentRepository)
        {
            this.configuration = configuration;
            this._paymentRepository = paymentRepository;
            merchendId = configuration["ZarinpalMerchendId"];


            var expose = new Expose();
            _payment = expose.CreatePayment();
            _authority = expose.CreateAuthority();
            _transactions = expose.CreateTransactions();

        }


        public async Task<IActionResult> Index(Guid PaymentId)
        {
            var payment = _paymentRepository.GetPayment(PaymentId);
            if (payment == null)
            {
                return NotFound();
            }
            string userId = ClaimUtility.GetUserId(User);
            if (userId != payment.Userid)
            {
                return BadRequest();
            }
            string callbackUrl = Url.Action(nameof(Verify), "pay", new { payment.Id }, protocol: Request.Scheme);
            var resultZarinpalRequest = await _payment.Request(new DtoRequest()
            {
                Amount = payment.Amount,
                CallbackUrl = callbackUrl,
                Description = payment.Description,
                Email = payment.Email,
                MerchantId = merchendId,
                Mobile = payment.PhoneNumber,
            }, ZarinPal.Class.Payment.Mode.zarinpal
                );

            return Redirect($"https://zarinpal.com/pg/StartPay/{resultZarinpalRequest.Authority}");
        }


        public IActionResult Verify(Guid Id, string Authority)
        {
            string Status = HttpContext.Request.Query["Status"];

            if (Status != "" && Status.ToString().ToLower() == "ok"
                && Authority != "")
            {
                var payment = _paymentRepository.GetPayment(Id);
                if (payment == null)
                {
                    return NotFound();
                }

                //var verification = _payment.Verification(new DtoVerification
                //{
                //    Amount = payment.Amount,
                //    Authority = Authority,
                //    MerchantId = merchendId,
                //}, Payment.Mode.zarinpal).Result;

                var client = new RestClient("https://www.zarinpal.com/pg/rest/WebGate/PaymentVerification.json");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", $"{{\"MerchantID\" :\"{merchendId}\",\"Authority\":\"{Authority}\",\"Amount\":\"{payment.Amount}\"}}", ParameterType.RequestBody);
                var response = client.Execute(request);

                VerificationPayResultDto verification =
                    JsonConvert.DeserializeObject<VerificationPayResultDto>(response.Content);

                if (verification.Status == 100)
                {
                    bool verifyResult = _paymentRepository.VerifyPayment(Id, Authority, verification.RefID);
                    if (verifyResult)
                    {
                        return Redirect("/customers/orders");
                    }
                    else
                    {
                        TempData["message"] = "پرداخت انجام شد اما ثبت نشد";
                        return RedirectToAction("checkout", "basket");
                    }
                }
                else
                {
                    TempData["message"] = "پرداخت شما ناموفق بوده است . لطفا مجددا تلاش نمایید یا در صورت بروز مشکل با مدیریت سایت تماس بگیرید .";
                    return RedirectToAction("checkout", "basket");
                }

            }
            TempData["message"] = "پرداخت شما ناموفق بوده است .";
            return RedirectToAction("checkout", "basket");
        }
    }


    public class VerificationPayResultDto
    {
        public int Status { get; set; }
        public long RefID { get; set; }
    }
}

