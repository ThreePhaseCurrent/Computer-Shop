using ComputerShop.Core.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace ComputerShop.API.Validators.Extensions
{
    /// <summary>
    /// Extensions for fluentvalidator
    /// </summary>
    public static class ValidatorExtension
    {
        /// <summary>
        /// Check that the phone number is correct
        /// </summary>
        /// <param name="rule"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IRuleBuilderOptions<T, string> PhoneNumber<T>(
            this IRuleBuilder<T, string> rule) 
        {
            return rule.SetValidator(new PhoneNumberValidator());
        }
        
        /// <summary>
        /// Check that the username is unique
        /// </summary>
        /// <param name="rule"></param>
        /// <param name="userManager"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IRuleBuilderOptions<T, string> UniqueUserName<T>(
            this IRuleBuilder<T, string> rule, UserManager<ApplicationUser> userManager) 
        {
            return rule.SetValidator(new UserNameValidator(userManager));
        }
    }
}