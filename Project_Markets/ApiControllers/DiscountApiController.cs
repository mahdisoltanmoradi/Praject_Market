using Data.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Markets.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountApiController : ControllerBase
    {
        private readonly IDiscountRepository _discountRepository;

        public DiscountApiController(IDiscountRepository discountRepository)
        {
            _discountRepository = discountRepository;
        }


        [HttpGet]
        [Route("SearchCatalogItem")]
        public async Task<IActionResult> SearchCatalogItem(string term)
        {
            return Ok(_discountRepository.GetCatalogItems(term));
        }
    }
}
