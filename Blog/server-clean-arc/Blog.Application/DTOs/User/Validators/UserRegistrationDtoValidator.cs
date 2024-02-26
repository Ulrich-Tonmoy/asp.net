using Blog.Application.IRepository;
using FluentValidation;

namespace Blog.Application.DTOs.User.Validators
{
    public class UserRegistrationDtoValidator : AbstractValidator<UserRegistrationDto>
    {
        public UserRegistrationDtoValidator(IUserRepository userRepository)
        {
            RuleFor(l => l.Name).NotNull();
            RuleFor(l => l.Password).NotNull().MinimumLength(6);
            RuleFor(l => l.ConfirmPassword).NotNull().MinimumLength(6);
            RuleFor(l => l.Email).MustAsync(async (email, token) =>
            {
                var exist = await userRepository.Exists(u => u.Email.Equals(email));
                return !exist;
            });
        }
    }
}
