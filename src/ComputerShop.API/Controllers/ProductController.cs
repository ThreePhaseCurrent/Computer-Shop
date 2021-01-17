using System;
using System.Threading.Tasks;
using ComputerShop.API.DTOs;
using ComputerShop.API.Models;
using ComputerShop.API.Validators;
using ComputerShop.Core.Constants;
using ComputerShop.Core.Entities;
using ComputerShop.Core.Services.Interfaces;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ComputerShop.API.Controllers
{
    
    /// <summary>
    /// Generic controller for products
    /// </summary>
    [ApiController]
    [Authorize(Roles = AuthorizationConstants.Roles.ADMIN)]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

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
        /// <param name="productsRequest">Includes params for pagination (not required) and filters (required)</param>
        /// <returns></returns>
        [HttpGet]
        [Route("products")]
        public async Task<IActionResult> GetProducts([FromBody] GetProductsRequest productsRequest)
        {
            ValidationResult validation = await new GetProductsRequestValidator().ValidateAsync(productsRequest);

            if (!validation.IsValid) { return BadRequest(ModelState); }

            //TODO: need return view model instead db entity
            var productsToShow = await _productService.GetProducts(productsRequest);
            return Ok(productsToShow);
        }

        /// <summary>
        /// Get specific product
        /// </summary>
        /// <param name="productStockNumber">Product's stock number</param>
        /// <returns></returns>
        [HttpGet]
        [Route("product")]
        public async Task<IActionResult> GetProduct([FromQuery] String productStockNumber)
        {
            if (String.IsNullOrEmpty(productStockNumber))
            {
                ModelState.AddModelError("400", "Stock number is required!");
                return BadRequest(ModelState);
            }

            Product product = await _productService.GetSpecificProduct(productStockNumber);

            if (product == null)
            {
                ModelState.AddModelError("400", "Product not found!");
                return BadRequest(ModelState);
            }
            //TODO: need return view model instead db entity
            return Ok(product);
        }

        /// <summary>
        /// Add new product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [Route("product")]
        [HttpPut]
        public async Task<IActionResult> AddProduct([FromBody] ProductToAddDto product)
        {
            //TODO: need gets productDTO instead db entity model
            //await _productService.Add(product);

            return Ok();
        }
    }
}