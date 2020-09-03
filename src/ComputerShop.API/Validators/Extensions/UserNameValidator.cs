using System.Linq;
using ComputerShop.Core.Entities;
using FluentValidation.Validators;
using Microsoft.AspNetCore.Identity;

namespace ComputerShop.API.Validators.Extensions
{
    /// <summary>
    /// Ensures that the username is unique
    /// </summary>
    public class UserNameValidator : PropertyValidator
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserNameValidator(UserManager<ApplicationUser> userManager) 
            : base("Username should be unique!")
        {
            _userManager = userManager;
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            var enteredUsername = (string) context.PropertyValue;
            var user =  _userManager.Users
                .FirstOrDefault(u => u.UserName == enteredUsername);

            return user == null;
        }
    }
}