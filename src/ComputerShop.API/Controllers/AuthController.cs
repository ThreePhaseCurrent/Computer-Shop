using System.Threading.Tasks;
using AutoMapper;
using ComputerShop.API.Models;
using ComputerShop.API.Services.Interfaces;
using ComputerShop.API.Validators;
using ComputerShop.API.ViewModels;
using ComputerShop.Core.Entities;
using ComputerShop.Core.Interfaces;
using ComputerShop.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerShop.API.Controllers
{
    /// <summary>
    /// Controller for auth options
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IAppLogger<AuthController> _logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapper">Auto Mapper</param>
        /// <param name="userService">Service to manage users </param>
        /// <param name="tokenService">Service to manage tokens</param>
        /// <param name="logger"></param>
        public AuthController(IMapper mapper, IUserService userService, ITokenService tokenService,
            IAppLogger<AuthController> logger)
        {
            _mapper = mapper;
            _userService = userService;
            _tokenService = tokenService;
            _logger = logger;
        }

        /// <summary>
        /// For register user
        /// </summary>
        /// <remarks>
        ///
        /// Sample body:
        /// 
        ///     {
        ///         "firstName": "TestFirstName1"
        ///         "lastName": "TestFirstName1"
        ///         "email": "testuser1@gmail.com"
        ///         "userName": "Testuser1"
        ///         "password": "Pass@word123"
        ///         "phone": "+3801111111111"
        ///     }
        /// 
        /// </remarks>
        /// <param name="register">Register model from UI in body</param>
        /// <returns></returns>
        /// <response code="200">Register was success</response>
        /// <response code="400">Register was invalid</response>
        [Route("register")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] Register register)
        {
            var validResult = await new RegisterValidator().ValidateAsync(register);

            if (!validResult.IsValid)
            {
                _logger.LogInformation("User data is not valid!");

                foreach (var error in validResult.Errors)
                {
                    ModelState.AddModelError(error.ErrorCode, error.ErrorMessage);
                }

                return BadRequest(ModelState);
            }

            var user = _mapper.Map<ApplicationUser>(register);

            var result = await _userService.CreateUser(user, register.Password);
            if (result.Succeeded)
            {
                _logger.LogInformation("User was register!");
                return Ok();
            }

            return BadRequest();
        }

        /// <summary>
        /// Check username exist
        /// </summary>
        /// <param name="username">User name</param>
        /// <returns>Returns True if username is not exist</returns>
        /// <response code="200">Always should return code 200</response>
        [Route("username-check/{username}")]
        [HttpGet]
        public async Task<bool> UserNameCheck(string username)
        {
            var user = await _userService.Users
                .FirstOrDefaultAsync(u => u.UserName == username);

            return user == null;
        }

        /// <summary>
        /// Loin for user
        /// </summary>
        /// <remarks>
        ///
        /// Sample body:
        ///
        ///     {
        ///         "userLogin": "admin@gmail.com",
        ///         "userPassword": "Pass@word123",
        ///         "rememberMe": true
        ///     }
        ///
        /// </remarks>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <response code="200">Login was success</response>
        /// <response code="400">Model has som error</response>
        /// <response code="401">User not found</response>
        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] Login request)
        {
            var validResult = await new LoginValidator().ValidateAsync(request);

            if (!validResult.IsValid)
            {
                _logger.LogInformation("User credentials is wrong!");
                
                foreach (var error in validResult.Errors)
                {
                    ModelState.AddModelError(error.ErrorCode, error.ErrorMessage);
                }
                
                return BadRequest(ModelState);
            }

            var signInResult = await _userService.UserSingIn(request.UserLogin, request.UserPassword, request.RememberMe);

            if (signInResult.Succeeded)
            {
                var user = await _userService.Users.FirstOrDefaultAsync(x => 
                    x.Email == request.UserLogin);
                var token = await _tokenService.GetToken(user);
                
                _logger.LogInformation("User was signin!");
            
                return Ok(new LoginViewModel()
                {
                    UserName = user.UserName,
                    AccessToken = token
                });
            }
            
            return Unauthorized();
        }
    }
}