using EmployeeManagementSystem.DTO.Employee;
using FluentValidation;

namespace EmployeeManagementSystem.Common.Validators
{
    public class EmployeeValidator : AbstractValidator<EmployeeCreateDto>
    {
        public EmployeeValidator()
        {
            RuleFor(e => e.FirstName).NotNull().NotEmpty().MinimumLength(2).MaximumLength(100);
            RuleFor(e => e.LastName).NotNull().NotEmpty().MinimumLength(2).MaximumLength(100);
            RuleFor(e => e.Email).NotNull().NotEmpty().EmailAddress();
        }
    }
}
