using Data.Contracts;
using Data.Contracts.Catalogs.CatalogItems;
using Entities.Product;
using Entities.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly IMediator mediator;
        private readonly IGetCatalogIItemPLPRepository getCatalogIItemPLPRepository;
        private readonly IGetCatalogItemPDPRepository getCatalogItemPDPRepository;

        public ProductController(IProductRepository productRepository
            , IProductCommentRepository productCommentRepository
            , IRepository<Entities.User.FavoriteUser> favorite
            , IUserRepository userRepository)
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

            var userFavorites =
                await _favorite
                    .TableNoTracking
                    .Where(
                        a => product
                            .Select(g => g.Id)
                            .Contains(a.ProductId))
                    .ToListAsync(cancellationToken);

            ViewData["Favorites"] = userFavorites;

            return View(product);
        }

        [HttpPost]
        public async Task<JsonResult> FavoriteProduct(int productId, CancellationToken cancellationToken)
        {

            if (!User.Identity.IsAuthenticated)
                return new JsonResult(new { succes = true, msg = "برو گمشو لاگین گن" });

            var user = User.Identity.Name;
            var result = await _userRepository.GetUserByUserName(user, cancellationToken);

            var ttt = await _favorite.TableNoTracking.Where(p => p.ProductId == productId).ToListAsync();
            if (ttt.Count() == 0)
            {
                await _favorite.AddAsync(new FavoriteUser
                {
                    ProductId = productId,
                    UserId = result.Id
                }, cancellationToken);
                return new JsonResult(new { succes = true, msg = "احسنت" });
            }

            await _favorite.DeleteRangeAsync(ttt, cancellationToken);
            return new JsonResult(new { succes = false, msg = "احسنت" });
        }


        [HttpGet]
        public async Task<IActionResult> ProductInformation(int id, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductInformation(id, cancellationToken);
            if (product != null)
            {
                product.ProductVisit += 1;
                ViewData["Comment"] = await _productCommentRepository.GetAllProductComments(id, cancellationToken);
                return View(product);
            }

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
