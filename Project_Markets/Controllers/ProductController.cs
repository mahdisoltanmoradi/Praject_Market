using Data.Contracts;
using Entities.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.OpenApi.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Project_Markets.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductCommentRepository _productCommentRepository;
        public ProductController(IProductRepository productRepository, IProductCommentRepository productCommentRepository)
        {
            this._productRepository = productRepository;
            this._productCommentRepository = productCommentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int id, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProducts(id, cancellationToken);
            return View(product);
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
