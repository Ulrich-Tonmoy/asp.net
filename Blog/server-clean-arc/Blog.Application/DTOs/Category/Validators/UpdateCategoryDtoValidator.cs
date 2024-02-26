using Blog.Application.IRepository;
using FluentValidation;

namespace Blog.Application.DTOs.Category.Validators
{
    public class UpdateCategoryDtoValidator : AbstractValidator<UpdateCategoryDto>
    {
        public UpdateCategoryDtoValidator(ICategoryRepository catRepository)
        {
            RuleFor(v => v.Name).NotNull().MustAsync(async (name, token) =>
            {
                var exist = await catRepository.Exists(u => u.Name.Equals(name));
                return !exist;
            });
        }
    }
}
