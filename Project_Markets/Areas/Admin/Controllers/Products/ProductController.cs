using Microsoft.AspNetCore.Mvc;
namespace Project_Markets.Areas.Admin.Controllers.Products
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
