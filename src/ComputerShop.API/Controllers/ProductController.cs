using System.Threading.Tasks;
using ComputerShop.API.Data;
using ComputerShop.API.Entities;
using ComputerShop.Core.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ComputerShop.API.Controllers
{
    [ApiController]
    [Authorize(Roles = AuthorizationConstants.Roles.ADMIN)]
    public class ProductController : Controller
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody]Product product)
        {
            await _productService.Add(product);

            return Ok();
        }
    }
}