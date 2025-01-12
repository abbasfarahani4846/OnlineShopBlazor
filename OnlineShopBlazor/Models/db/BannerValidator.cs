using FluentValidation;

using OnlineShopBlazor.Models.Db;

namespace OnlineShopBlazor.Validators
{
    public class BannerValidator : AbstractValidator<Banner>
    {
        public BannerValidator()
        {
            RuleFor(b => b.Title)
                .NotEmpty().WithMessage("عنوان الزامی است.")
                .MaximumLength(100).WithMessage("عنوان نمی‌تواند بیشتر از 100 کاراکتر باشد.");

            RuleFor(b => b.Description)
                 .NotEmpty().WithMessage("عنوان الزامی است.")
                .MaximumLength(500).WithMessage("توضیحات نمی‌تواند بیشتر از 500 کاراکتر باشد.");

        }
    }

}
