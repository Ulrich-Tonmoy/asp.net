using FluentValidation;
using UniversityCourseAndResultManagementSystem.DTO.SemesterDto;

namespace UniversityCourseAndResultManagementSystem.Common.Validators
{
    public class SemesterValidator : AbstractValidator<SemesterCreateDto>
    {
        public SemesterValidator()
        {
            RuleFor(s => s.Name).NotEmpty().MinimumLength(2).MaximumLength(15);
        }
    }
}
