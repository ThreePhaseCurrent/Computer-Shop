using System.ComponentModel.DataAnnotations;

namespace ComputerShop.API.Models
{
    public class Login
    {
        [Required]
        [EmailAddress]
        public string UserLogin { get; set; }
        [Required]
        public string UserPassword { get; set; }
        [Required]
        public bool RememberMe { get; set; }
    }
}