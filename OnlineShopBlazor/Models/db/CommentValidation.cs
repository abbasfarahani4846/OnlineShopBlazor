using FluentValidation;

using OnlineShopBlazor.Models.Db;

namespace OnlineShopBlazor.Models.db
{
    public class CommentValidation : AbstractValidator<Comment>
    {
        public CommentValidation()
        {
            RuleFor(p => p.Name)
               .NotEmpty()
               .MaximumLength(50);

            RuleFor(p => p.Email)
              .NotEmpty()
              .MaximumLength(50);

            RuleFor(p => p.CommentText)
              .NotEmpty()
              .MaximumLength(500);
        }
    }
}
