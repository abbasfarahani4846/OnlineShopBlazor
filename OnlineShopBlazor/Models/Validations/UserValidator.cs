using FluentValidation;

using OnlineShopBlazor.Models.Db;

namespace OnlineShopBlazor.Models.Validations
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {

            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("Please enter your full name.")
                .MaximumLength(50).WithMessage("Full name cannot be longer than 50 characters.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Please enter your email address.")
                .EmailAddress().WithMessage("Please enter a valid email address.")
            .MaximumLength(50).WithMessage("Full name cannot be longer than 50 characters.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Please enter a password.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
            .MaximumLength(50).WithMessage("Full name cannot be longer than 50 characters.");
        }
    }
}
