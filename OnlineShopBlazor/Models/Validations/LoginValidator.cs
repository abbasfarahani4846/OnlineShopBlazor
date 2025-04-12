using FluentValidation;
using OnlineShopBlazor.Models.Db;
using OnlineShopBlazor.Models.ViewModels;

namespace OnlineShopBlazor.Models.Validations
{

    public class LoginValidator : AbstractValidator<LoginViewModel>
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
