using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ComputerShop.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/{controller}")]
    [ApiController]
    public class HomeController : Controller
    {
        [Route("index")]
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Hello");
        }
    }
}