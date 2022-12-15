using FluentValidation;
using UniversityCourseAndResultManagementSystem.DTO.TeacherDto;

namespace UniversityCourseAndResultManagementSystem.Common.Validators
{
    public class TeacherValidator : AbstractValidator<TeacherCreateDto>
    {
        public TeacherValidator()
        {
            RuleFor(t => t.Name).NotEmpty().MinimumLength(3).MaximumLength(15);
            RuleFor(t => t.Address).NotEmpty().MinimumLength(5).MaximumLength(20);
            RuleFor(t => t.Email).NotEmpty().EmailAddress();
            RuleFor(t => t.ContactNo).NotEmpty().MinimumLength(11).MaximumLength(11);
            RuleFor(t => t.DesignationId).NotEmpty();
            RuleFor(t => t.DepartmentId).NotEmpty();
            RuleFor(t => t.CreditToBeTaken).NotEmpty().GreaterThan(0);
        }
    }
}
