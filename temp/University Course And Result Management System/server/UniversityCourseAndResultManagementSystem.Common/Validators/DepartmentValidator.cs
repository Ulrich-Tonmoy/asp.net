using FluentValidation;
using UniversityCourseAndResultManagementSystem.DTO.DepartmentDto;

namespace UniversityCourseAndResultManagementSystem.Common.Validators
{
    public class DepartmentValidator : AbstractValidator<DepartmentCreateDto>
    {
        public DepartmentValidator()
        {
            RuleFor(d => d.Code).NotEmpty().MinimumLength(2).MaximumLength(7);
            RuleFor(d => d.Name).NotEmpty();
        }
    }
}
