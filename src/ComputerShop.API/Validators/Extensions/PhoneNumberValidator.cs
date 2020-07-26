using System.Text.RegularExpressions;
using FluentValidation;
using FluentValidation.Validators;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ComputerShop.API.Validators.Extensions
{
    /// <summary>
    /// Phone number custom validator
    /// </summary>
    public class PhoneNumberValidator : PropertyValidator
    {
        protected override bool IsValid(PropertyValidatorContext context)
        {
            var phoneNumber = (string) context.PropertyValue;
            return Regex.IsMatch(phoneNumber,@"^[+][0-9\-\+]{9,15}$");
        }

        public PhoneNumberValidator() : base($"Is not phone number!")
        {
        }
    }
    
    public static class PhoneNumberValidatorExtension {
        public static IRuleBuilderOptions<T, string> PhoneNumber<T>(
            this IRuleBuilder<T, string> rule) 
        {
            return rule.SetValidator(new PhoneNumberValidator());
        }
    }
}