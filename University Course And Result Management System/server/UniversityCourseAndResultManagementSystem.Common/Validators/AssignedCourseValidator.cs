using FluentValidation;
using UniversityCourseAndResultManagementSystem.DTO.AssignedCourseDto;

namespace UniversityCourseAndResultManagementSystem.Common.Validators
{
    public class AssignedCourseValidator : AbstractValidator<AssignedCourseCreateDto>
    {
        public AssignedCourseValidator()
        {
            RuleFor(a => a.TeacherId).NotEmpty();
            RuleFor(a => a.CourseId).NotEmpty();
        }
    }
}
