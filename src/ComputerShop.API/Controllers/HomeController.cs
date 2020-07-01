using Microsoft.AspNetCore.Mvc;

namespace ComputerShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        [Route("Index")]
        public IActionResult Index()
        {
            return Ok("Hello");
        }
    }
}