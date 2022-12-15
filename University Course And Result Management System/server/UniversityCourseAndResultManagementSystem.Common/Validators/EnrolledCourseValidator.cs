using FluentValidation;
using UniversityCourseAndResultManagementSystem.DTO.EnrolledCourseDto;

namespace UniversityCourseAndResultManagementSystem.Common.Validators
{
    public class EnrolledCourseValidator : AbstractValidator<EnrolledCourseCreateDto>
    {
        public EnrolledCourseValidator()
        {
            RuleFor(e => e.CourseId).NotEmpty();
            RuleFor(e => e.Date).NotEmpty();
            RuleFor(e => e.Grade).Null();
        }
    }
}
