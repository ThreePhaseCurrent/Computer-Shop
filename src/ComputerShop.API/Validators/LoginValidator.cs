using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComputerShop.API.Models;
using FluentValidation;

namespace ComputerShop.API.Validators
{
    public class LoginValidator : AbstractValidator<Login>
    {
        public LoginValidator()
        {
            RuleFor(x => x.UserLogin).NotNull();
            RuleFor(x => x.UserPassword).NotNull();
        }
    }
}
