using Blog.Application.IRepository;
using FluentValidation;

namespace Blog.Application.DTOs.Post.Validators
{
    public class UpdatePostDtoValidator : AbstractValidator<UpdatePostDto>
    {
        public UpdatePostDtoValidator(ICategoryRepository catRepository)
        {
            RuleFor(v => v.Title).NotNull();
            RuleFor(v => v.PermaLink).NotNull();
            RuleFor(v => v.HeroImg).NotNull();
            RuleFor(v => v.Excerpt).NotNull();
            RuleFor(v => v.Content).NotNull();
            RuleFor(l => l.CategoryId).MustAsync(async (CategoryId, token) =>
            {
                var exist = await catRepository.Exists(u => u.Id.Equals(CategoryId));
                return !exist;
            });
        }
    }
}
