using System.Threading.Tasks;
using Data.Contracts;
using Microsoft.AspNetCore.Mvc;
using Services.Attributes;

namespace Project_Markets.Areas.Admin.Controllers.Orders
{
    [Area("Admin")]
    [ControllerInfo("سفارشات", "پنل ادمین")]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var orders = await _orderRepository.GetOrdersAsync();
            return View(orders);
        }

        public async Task<IActionResult> Details(int id)
        {
            var order = await _orderRepository.GetOrderByIdAsync(id);
            if (order == null)
                return NotFound();

            return View(order);
        }
    }

}
