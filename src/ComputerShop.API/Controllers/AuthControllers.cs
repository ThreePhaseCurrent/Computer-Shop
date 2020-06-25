using Microsoft.AspNetCore.Mvc;

namespace ComputerShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthControllers : Controller
    {
        public IActionResult Login()
        {
            return Unauthorized();
        }
    }
}