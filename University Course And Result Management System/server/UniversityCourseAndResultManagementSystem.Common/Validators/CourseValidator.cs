using FluentValidation;
using UniversityCourseAndResultManagementSystem.DTO.CourseDto;

namespace UniversityCourseAndResultManagementSystem.Common.Validators
{
    public class CourseValidator : AbstractValidator<CourseCreateDto>
    {
        public CourseValidator()
        {
            RuleFor(c => c.Code).NotEmpty().MinimumLength(5);
            RuleFor(c => c.Name).NotEmpty().MinimumLength(2);
            RuleFor(c => c.Credit).NotEmpty().ExclusiveBetween(0.5f, 5f);
            RuleFor(c => c.Description).NotEmpty().MinimumLength(5);
            RuleFor(c => c.DepartmentId).NotEmpty();
        }
    }
}
