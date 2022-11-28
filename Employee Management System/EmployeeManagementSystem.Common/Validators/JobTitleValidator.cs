using EmployeeManagementSystem.DTO.Job;
using FluentValidation;

namespace EmployeeManagementSystem.Common.Validators
{
    public class JobTitleValidator : AbstractValidator<JobCreateDto>
    {
        public JobTitleValidator()
        {
            RuleFor(j => j.JobTitle).NotNull().NotEmpty().MinimumLength(2).MaximumLength(100);
        }
    }
}
