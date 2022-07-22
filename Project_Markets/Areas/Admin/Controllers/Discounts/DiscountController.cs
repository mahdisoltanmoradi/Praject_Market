using Data.Contracts;
using Data.DTOs.Discount;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Project_Markets.Areas.Admin.Controllers.Discounts
{
    [Area("Admin")]
    [Authorize]
    public class DiscountController : Controller
    {
        private readonly IDiscountRepository _discountRepository;
        public DiscountController(IDiscountRepository discountRepository = null)
        {
            _discountRepository = discountRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _discountRepository.GetAllDiscount());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddNewDiscountDto dto)
        {
            _discountRepository.Execute(dto);
            return RedirectToAction(nameof(Index));
        }

    }
}
