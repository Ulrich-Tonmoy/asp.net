using FluentValidation;

namespace LeaveManagement.Application.DTOs.LeaveType.Validators
{
    public class CreateLeaveTypeDtoValidator : AbstractValidator<CreateLeaveTypeDto>
    {
        public CreateLeaveTypeDtoValidator()
        {
            RuleFor(l => l.Name).NotEmpty().WithMessage("{PropertyName} is required.")
                                .NotNull()
                                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
            RuleFor(l => l.DefaultDays).NotEmpty().WithMessage("{PropertyName} is required.")
                                       .GreaterThan(0).WithMessage("{PropertyName} must be greate than {ComparisonValue}.");
        }
    }
}
