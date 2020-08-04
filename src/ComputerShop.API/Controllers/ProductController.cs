using System.Threading.Tasks;
using ComputerShop.API.Data;
using ComputerShop.API.Entities;
using ComputerShop.API.Models;
using ComputerShop.Core.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ComputerShop.API.Controllers
{
    
    [ApiController]
    [Authorize(Roles = AuthorizationConstants.Roles.ADMIN)]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/{controller}")]
    public class ProductController : Controller
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        
        [HttpGet]
        [Route("products")]
        public async Task<IActionResult> GetProducts([FromQuery] ProductViewParameters parameters)
        {
            var test = await _productService.GetProducts(parameters);
            return Ok(test);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody]Product product)
        {
            await _productService.Add(product);

            return Ok();
        }
    }
}