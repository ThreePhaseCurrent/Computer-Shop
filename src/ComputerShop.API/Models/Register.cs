using System.ComponentModel.DataAnnotations;

namespace ComputerShop.API.Models
{
    public class Register
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
    }
}