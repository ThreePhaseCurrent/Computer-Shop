using Microsoft.AspNetCore.Identity;

namespace ComputerShop.API.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string ProfileImage { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}