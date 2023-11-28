using FluentValidation;
using UniversityCourseAndResultManagementSystem.DTO.StudentDto;

namespace UniversityCourseAndResultManagementSystem.Common.Validators
{
    public class StudentValidator : AbstractValidator<StudentCreateDto>
    {
        public StudentValidator()
        {
            RuleFor(s => s.Name).NotEmpty().MinimumLength(2).MaximumLength(15);
            RuleFor(s => s.Email).NotEmpty().EmailAddress();
            RuleFor(s => s.ContactNo).NotEmpty().MinimumLength(11).MaximumLength(11);
            RuleFor(s => s.Address).NotEmpty().MinimumLength(5).MaximumLength(20);
            RuleFor(s => s.Date).NotEmpty();
        }
    }
}
