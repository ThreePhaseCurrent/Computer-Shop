using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComputerShop.API.Models;
using FluentValidation;

namespace ComputerShop.API.Validators
{
    /// <summary>
    /// Validator for products request model
    /// </summary>
    public class GetProductsRequestValidator: AbstractValidator<GetProductsRequest>
    {
        /// <summary>
        /// Constructor which to do validation
        /// </summary>
        public GetProductsRequestValidator()
        {
            RuleSet("ViewParameters", () =>
            {
                RuleFor(x => x.ProductViewParameters.PageNumber)
                    .NotNull()
                    .When(x => x.ProductViewParameters != null);
            });

            RuleSet("Filters", () =>
            {
                RuleFor(x => x.ProductFilters).NotNull();
                RuleFor(x => x.ProductFilters.ProductCategoryId).NotNull();
            });
        }
    }
}
