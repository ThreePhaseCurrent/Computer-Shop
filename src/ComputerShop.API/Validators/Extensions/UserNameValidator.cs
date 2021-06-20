using System.Linq;
using ComputerShop.Core.Entities;
using FluentValidation;
using FluentValidation.Validators;
using Microsoft.AspNetCore.Identity;

namespace ComputerShop.API.Validators.Extensions
{
    /// <summary>
    /// Ensures that the username is unique
    /// </summary>
    public class UserNameValidator<T, TProperty> : PropertyValidator<T, TProperty>
    {
        public override string Name { get; }
        private readonly UserManager<ApplicationUser> _userManager;

        public UserNameValidator(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public override bool IsValid(ValidationContext<T> context, TProperty value)
        {
            var enteredUsername = value.ToString();
            var user =  _userManager.Users
                .FirstOrDefault(u => u.UserName == enteredUsername);

            return user == null;
        }

        protected override string GetDefaultMessageTemplate(string errorCode)
            => "Username should be unique!";
    }
}