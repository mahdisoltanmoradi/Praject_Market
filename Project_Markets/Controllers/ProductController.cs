using Data.Contracts;
using Entities.Product;
using Entities.User;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Project_Markets.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductCommentRepository _productCommentRepository;
        private readonly IRepository<Entities.User.FavoriteUser> _favorite;
        private readonly IUserRepository _userRepository;
        public ProductController(IProductRepository productRepository
            ,IProductCommentRepository productCommentRepository
            ,IRepository<Entities.User.FavoriteUser> favorite
            ,IUserRepository userRepository)
        {
            this._productRepository = productRepository;
            this._productCommentRepository = productCommentRepository;
            this._favorite = favorite;
            this._userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int id, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProducts(id, cancellationToken);
            return View(product);
        }

        [HttpPost]
        public async Task<JsonResult> FavoriteProduct(int productId, CancellationToken cancellationToken)
        {
            var user = User.Identity.Name;
            var result = await _userRepository.GetUserByUserName(user,cancellationToken);
            if (!result.FavoriteUsers.Any(p=>p.FavoriteId==productId))
            {
                 
            }
            return new JsonResult(new {succes = true });
        }


        [HttpGet]
        public async Task<IActionResult> ProductInformation(int id, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductInformation(id, cancellationToken);
            ViewData["Comment"] =await _productCommentRepository.GetAllProductComments(id,cancellationToken);

            return View(product);
        }


        [HttpPost]
        public async Task<IActionResult> ProductInformation(ProductComment comment, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return View(comment);
            }

            await _productCommentRepository.AddProductComment(comment, cancellationToken);
            return View();
        }

    }
}
