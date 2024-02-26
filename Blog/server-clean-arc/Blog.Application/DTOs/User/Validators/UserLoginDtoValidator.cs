using FluentValidation;

namespace Blog.Application.DTOs.User.Validators
{
    public class UserLoginDtoValidator : AbstractValidator<UserLoginDto>
    {
        public UserLoginDtoValidator()
        {
            RuleFor(l => l.Password).NotNull().MinimumLength(6);
            RuleFor(l => l.Email).NotNull();
        }
    }
}
