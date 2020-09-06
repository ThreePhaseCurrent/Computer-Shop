using System.Threading.Tasks;
using ComputerShop.API.Models;
using ComputerShop.Core.Constants;
using ComputerShop.Core.Entities;
using ComputerShop.Core.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ComputerShop.API.Controllers
{
    
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Authorize(Roles = AuthorizationConstants.Roles.ADMIN)]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api")]
    public class ProductController : Controller
    {
        private IProductService _productService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productService"></param>
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        
        /// <summary>
        /// Get page of products
        /// </summary>
        /// <param name="parameters">Params for pagination</param>
        /// <returns></returns>
        [HttpGet]
        [Route("products")]
        public async Task<IActionResult> GetProducts([FromQuery] ProductViewParameters parameters)
        {
            var test = await _productService.GetProducts(parameters);
            return Ok(test);
        }

        /// <summary>
        /// Add new product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [Route("product")]
        [HttpPut]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            await _productService.Add(product);

            return Ok();
        }
    }
}