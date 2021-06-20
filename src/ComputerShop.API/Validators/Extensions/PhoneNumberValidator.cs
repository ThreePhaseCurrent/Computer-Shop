using System.Text.RegularExpressions;
using FluentValidation;
using FluentValidation.Validators;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ComputerShop.API.Validators.Extensions
{
    /// <summary>
    /// Phone number custom validator
    /// </summary>
    public class PhoneNumberValidator<T, TProperty> : PropertyValidator<T, TProperty>
    {
        public override bool IsValid(ValidationContext<T> context, TProperty value)
        {
            var phoneNumber = value.ToString();
            return Regex.IsMatch(phoneNumber,@"^[+][0-9\-\+]{9,15}$");
        }

        public override string Name { get; }

        protected override string GetDefaultMessageTemplate(string errorCode)
            => "Is not phone number!";
    }
}