using FluentValidation;

namespace Blog.Application.DTOs.SubscriptionValidators
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
