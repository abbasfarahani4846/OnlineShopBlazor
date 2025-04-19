using FluentValidation;

using OnlineShopBlazor.Models.ViewModels;

namespace OnlineShopBlazor.Models.Validations
{
    public class RecoveryPasswordValidator : AbstractValidator<RecoveryViewModel>
    {
        public RecoveryPasswordValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Please enter your email address.")
                .EmailAddress().WithMessage("Please enter a valid email address.")
            .MaximumLength(50).WithMessage("Full name cannot be longer than 50 characters.");
        }
    }
}
