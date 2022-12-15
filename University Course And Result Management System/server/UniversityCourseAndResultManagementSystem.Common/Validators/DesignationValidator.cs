using FluentValidation;
using UniversityCourseAndResultManagementSystem.DTO.DesignationDto;

namespace UniversityCourseAndResultManagementSystem.Common.Validators
{
    public class DesignationValidator : AbstractValidator<DesignationCreateDto>
    {
        public DesignationValidator()
        {
            RuleFor(d => d.Name).NotEmpty().MinimumLength(5);
            RuleFor(d => d.Description).NotEmpty().MinimumLength(5);
        }
    }
}
