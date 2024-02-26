using FluentValidation;

namespace Blog.Application.DTOs.Subscription.Validators
{
    public class UpdateSubscriptionDtoValidator : AbstractValidator<UpdateSubscriptionDto>
    {
        public UpdateSubscriptionDtoValidator()
        {
            RuleFor(l => l.Name).NotNull();
            RuleFor(l => l.Email).NotNull();
        }
    }
}
