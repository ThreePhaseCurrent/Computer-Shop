using Microsoft.AspNetCore.Identity;

namespace ComputerShop.API.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string ProfileImage { get; set; }
    }
}