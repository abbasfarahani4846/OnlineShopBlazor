using FluentValidation;
using OnlineShopBlazor.Models.Db;

namespace OnlineShopBlazor.Models.Validations
{

    public class LoginValidator : AbstractValidator<User>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Please enter your email address.")
                .EmailAddress().WithMessage("Please enter a valid email address.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Please enter a password.");
        }
    }
}
