using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using ComputerShop.API.Data;
using ComputerShop.API.Models;
using ComputerShop.API.Validators;
using ComputerShop.API.ViewModels;
using ComputerShop.Core.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ComputerShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private ITokenService _tokenService;
        private IMapper _mapper;
        private IUserService _userService;
        private ILogger<AuthController> _logger;

        public AuthController(IMapper mapper, IUserService userService, ITokenService tokenService,
            ILogger<AuthController> logger)
        {
            _mapper = mapper;
            _userService = userService;
            _tokenService = tokenService;
            _logger = logger;
        }

        [Route("register")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] Register register)
        {
            var validResult = await new RegisterValidator().ValidateAsync(register);

            if (!validResult.IsValid)
            {
                _logger.Log(LogLevel.Information, "User data is not valid!");
                return BadRequest();
            }

            var user = _mapper.Map<ApplicationUser>(register);

            var result = await _userService.CreateUser(user, register.Password);
            if (result.Succeeded)
            {
                _logger.Log(LogLevel.Information, "User was register!");
                return Ok();
            }

            return BadRequest();
        }

        /// <summary>
        /// Check username exist
        /// </summary>
        /// <param name="username">User name</param>
        /// <returns>Returns True if username is not exist</returns>
        [Route("username-check/{username}")]
        [HttpGet]
        public async Task<bool> UserNameCheck(string username)
        {
            var user = await _userService.Users
                .FirstOrDefaultAsync(u => u.UserName == username);

            return user == null;
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] Login request)
        {
            var validResult = await new LoginValidator().ValidateAsync(request);

            if (!validResult.IsValid)
            {
                _logger.Log(LogLevel.Information, "User credentials is wrong!");
                return BadRequest();
            }

            var signInResult = await _userService.UserSingIn(request);

            if (signInResult.Succeeded)
            {
                var user = await _userService.Users.FirstOrDefaultAsync(x => 
                    x.Email == request.UserLogin);
                var token = await _tokenService.GetToken(user);
                
                _logger.Log(LogLevel.Information, "User was signin!");
            
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