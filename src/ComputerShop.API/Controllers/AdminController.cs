using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComputerShop.Core.Constants;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ComputerShop.API.Controllers
{
    /// <summary>
    /// Admin panel controller
    /// </summary>
    [ApiController]
    [Authorize(Roles = AuthorizationConstants.Roles.ADMIN)]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
