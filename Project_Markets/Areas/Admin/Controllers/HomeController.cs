using Microsoft.AspNetCore.Mvc;
using Services.Attributes;

namespace Project_Markets.Areas.Admin.Controllers
{
    [Area("Admin")]
    [ControllerInfo("داشبورد", "پنل ادمین")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
