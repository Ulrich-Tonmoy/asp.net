using FluentValidation;

namespace Blog.Application.DTOs.Subscription.Validators
{
    public class UpdateSubscriptionValidator : AbstractValidator<UpdateSubscriptionDto>
    {
        public UpdateSubscriptionValidator()
        {
            RuleFor(l => l.Name).NotNull();
            RuleFor(l => l.Email).NotNull();
        }
    }
}
