using FluentValidation;

using OnlineShopBlazor.Models.Db;

namespace OnlineShopBlazor.Models.db
{
    public class BannerValidation : AbstractValidator<Banner>
    {
            public BannerValidation()
            {
                RuleFor(banner => banner.Title).NotEmpty().MaximumLength(50);
                RuleFor(banner => banner.Description).NotEmpty().MaximumLength(50);
            }
    }
}
