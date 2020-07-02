using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using ComputerShop.API.Identity;
using ComputerShop.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace ComputerShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private SignInManager<ApplicationUser> _signInManager;
        private UserManager<ApplicationUser> _userManager;
        private IOptions<AuthOptions> _authOptions;
        private RoleManager<IdentityRole> _roleManager;
        
        public AuthController(SignInManager<ApplicationUser> signInManager, IOptions<AuthOptions> authOptions, 
            UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager;
            _authOptions = authOptions;
            _userManager = userManager;
            _roleManager = roleManager;
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
                var token = GetToken(user);
            
                return Ok(new
                {
                    access_token = token
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