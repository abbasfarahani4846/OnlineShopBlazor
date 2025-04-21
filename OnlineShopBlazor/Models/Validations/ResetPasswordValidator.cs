using FluentValidation;
using OnlineShopBlazor.Models.ViewModels;

namespace OnlineShopBlazor.Models.Validations
{
    public class ResetPasswordValidator : AbstractValidator<ResetPasswordViewModel>
    {
        public ResetPasswordValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Please enter your email address.")
                .EmailAddress().WithMessage("Please enter a valid email address.")
                .MaximumLength(50).WithMessage("Full name cannot be longer than 50 characters.");

            RuleFor(x => x.RecoveryCode)
                .NotEmpty().WithMessage("Please enter your recoveryCode address.");

            RuleFor(x => x.NewPassword)
                .NotEmpty().WithMessage("Please enter a password.")
                .MaximumLength(50).WithMessage("Full name cannot be longer than 50 characters.");
        }
    }
}
