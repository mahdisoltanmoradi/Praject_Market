using System;
using System.Threading.Tasks;
using Data.Contracts;
using Dto.Payment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using Services.Attributes;
using Services.Utilities;
using ZarinPal.Class;

namespace Project_Markets.Controllers
{
    [ControllerInfo("پرداختی ها", "عمومی")]
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
            if (userId != payment.UserId)
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


        [HttpGet]
        public async Task<IActionResult> Verify(Guid Id, string Authority)
        {
            string Status = HttpContext.Request.Query["Status"];

            if (!string.IsNullOrEmpty(Status) && Status.ToLower() == "ok" && !string.IsNullOrEmpty(Authority))
            {
                var payment = _paymentRepository.GetPayment(Id);
                if (payment == null)
                {
                    return NotFound();
                }

                // ساختن کلاینت با Option
                var options = new RestClientOptions("https://www.zarinpal.com/pg/rest/WebGate/PaymentVerification.json")
                {
                    MaxTimeout = -1 // می‌تونی زمان دلخواه بدی
                };
                var client = new RestClient(options);

                // درخواست POST
                var request = new RestRequest("", Method.Post);
                request.AddHeader("Content-Type", "application/json");

                // بدنه‌ی JSON
                var body = new
                {
                    MerchantID = merchendId,
                    Authority = Authority,
                    Amount = payment.Amount
                };
                request.AddJsonBody(body);

                // اجرای درخواست
                var response = await client.ExecuteAsync(request);

                // بررسی نتیجه
                if (!response.IsSuccessful || string.IsNullOrEmpty(response.Content))
                {
                    TempData["message"] = "خطا در برقراری ارتباط با درگاه پرداخت.";
                    return RedirectToAction("checkout", "basket");
                }

                // تبدیل JSON به مدل
                var verification = JsonConvert.DeserializeObject<VerificationPayResultDto>(response.Content);

                if (verification != null && verification.Status == 100)
                {
                    bool verifyResult = _paymentRepository.VerifyPayment(Id, Authority, verification.RefID);
                    if (verifyResult)
                    {
                        return Redirect("/customers/orders");
                    }
                    else
                    {
                        TempData["message"] = "پرداخت انجام شد اما در سیستم ثبت نشد.";
                        return RedirectToAction("checkout", "basket");
                    }
                }
                else
                {
                    TempData["message"] = "پرداخت شما ناموفق بوده است. لطفا مجدداً تلاش نمایید یا با مدیریت سایت تماس بگیرید.";
                    return RedirectToAction("checkout", "basket");
                }
            }

            TempData["message"] = "پرداخت شما ناموفق بوده است.";
            return RedirectToAction("checkout", "basket");
        }

    }


    public class VerificationPayResultDto
    {
        public int Status { get; set; }
        public long RefID { get; set; }
    }
}

