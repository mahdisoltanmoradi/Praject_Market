using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Attributes;

namespace Project_Markets.Areas.Admin.Controllers.Messages
{
    [Area("Admin")]
    [Authorize]
    [ControllerInfo("پشتیبانی سایت", "پنل ادمین")]
    public class SupportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
