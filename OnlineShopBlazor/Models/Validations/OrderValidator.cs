using FluentValidation;

using OnlineShopBlazor.Models.Db;

namespace OnlineShopBlazor.Models.Validations
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {

            RuleFor(x => x.Country)
                .NotEmpty().WithMessage("Please enter your Country.")
                .MaximumLength(50).WithMessage("Country cannot be longer than 50 characters.");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("Please enter your FirstName.")
            .MaximumLength(50).WithMessage("FirstName cannot be longer than 50 characters.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Please enter a LastName.")
            .MaximumLength(50).WithMessage("LastName cannot be longer than 50 characters.");

            RuleFor(x => x.Address)
            .NotEmpty().WithMessage("Please enter a Address.")
        .MaximumLength(200).WithMessage("Address cannot be longer than 200 characters.");

            RuleFor(x => x.City)
          .NotEmpty().WithMessage("Please enter a City.")
      .MaximumLength(50).WithMessage("City cannot be longer than 50 characters.");

            RuleFor(x => x.Phone)
        .NotEmpty().WithMessage("Please enter a Phone.")
    .MaximumLength(50).WithMessage("Phone cannot be longer than 50 characters.");

            RuleFor(x => x.Email)
       .NotEmpty().WithMessage("Please enter a Email.")
   .MaximumLength(50).WithMessage("Email cannot be longer than 50 characters.");
        }
    }
}
