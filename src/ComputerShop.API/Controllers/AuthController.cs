using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using ComputerShop.API.Data;
using ComputerShop.API.Models;
using ComputerShop.API.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;


namespace ComputerShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private SignInManager<ApplicationUser> _signInManager;
        private UserManager<ApplicationUser> _userManager;
        private IOptions<AuthOptions> _authOptions;
        
        public AuthController(SignInManager<ApplicationUser> signInManager, IOptions<AuthOptions> authOptions, 
            UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _authOptions = authOptions;
            _userManager = userManager;
        }

        [Route("register")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] Register register)
        {
            var user = new ApplicationUser()
            {
                ProfileImage = "",
                FirstName = register.FirstName,
                LastName = register.LastName,
                Email = register.Email,
                NormalizedEmail = register.Email.ToUpper(),
                UserName = register.UserName,
                NormalizedUserName = register.UserName.ToUpper(),
                PhoneNumber = register.Phone,
                EmailConfirmed = false,
                PhoneNumberConfirmed = false,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };
            
            var result = await _userManager.CreateAsync(user, register.Password);
            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest();
        }

        [Route("username-check/{username}")]
        [HttpGet]
        public async Task<bool> UserNameCheck(string username)
        {
            var user = await _userManager.Users
                .FirstOrDefaultAsync(u => u.UserName == username);

            return user == null;
        }
        
        [Route("login")]
        [HttpGet]
        public IActionResult Login()
        {
            return Unauthorized();
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] Login request)
        {
            var user = await _userManager.FindByEmailAsync(request.UserLogin);
            var signInResult = await _signInManager.CheckPasswordSignInAsync(user, 
                request.UserPassword, false);

            if (signInResult.Succeeded)
            {
                var token = await GetToken(user);
            
                return Ok(new LoginViewModel()
                {
                    UserName = user.UserName,
                    AccessToken = token
                });
            }
            
            return Unauthorized();
        }
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private async Task<string> GetToken(ApplicationUser user)
        {
            var authParams = _authOptions.Value;

            var securityKey = authParams.GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id)
            };

            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim("role", role));
            }
            
            var token = new JwtSecurityToken(authParams.Issuer, authParams.Audience, claims,
                expires: DateTime.Now.AddSeconds(authParams.TokenLifeTime),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}