using EmployeeManagementSystem.DTO.Department;
using FluentValidation;

namespace EmployeeManagementSystem.Common.Validators
{
    public class DepartmentValidator : AbstractValidator<DepartmentCreateDto>
    {
        public DepartmentValidator()
        {
            RuleFor(d => d.DepartmentName).NotNull().NotEmpty().MinimumLength(2).MaximumLength(100);
        }
    }
}
