using FluentValidation;
using LeaveManagement.Application.IRepository;

namespace LeaveManagement.Application.DTOs.LeaveAllocation.Validators
{
    public class CreateLeaveAllocationDtoValidator : AbstractValidator<CreateLeaveAllocationDto>
    {
        public CreateLeaveAllocationDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            RuleFor(l => l.NumberOfDays).GreaterThan(0).WithMessage("{PropertyName} must greater than {ComparisonValue}");

            RuleFor(l => l.Period).GreaterThanOrEqualTo(DateTime.Now.Year).WithMessage("{PropertyName} must be after {ComparisonValue}");

            RuleFor(l => l.LeaveTypeId).NotNull().MustAsync(async (id, token) =>
            {
                var leaveTypeExists = await leaveTypeRepository.Exists(id);
                return leaveTypeExists;
            }).WithMessage("{PropertyName} does not exist.");
        }
    }
}
