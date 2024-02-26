using Blog.Application.IRepository;
using FluentValidation;

namespace Blog.Application.DTOs.Subscription.Validators
{
    public class CreateSubscriptionDtoValidator : AbstractValidator<CreateSubscriptionDto>
    {
        public CreateSubscriptionDtoValidator(ISubscriptionRepository subRepository)
        {
            RuleFor(l => l.Name).NotNull();
            RuleFor(l => l.Email).MustAsync(async (email, token) =>
            {
                var exist = await subRepository.Exists(u => u.Email.Equals(email));
                return !exist;
            });
        }
    }
}
