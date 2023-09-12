using FluentValidation;
using LeaveManagement.Application.IRepository;

namespace LeaveManagement.Application.DTOs.LeaveRequest.Validators
{
    public class UpdateLeaveRequestDtoValidator : AbstractValidator<UpdateLeaveRequestDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public UpdateLeaveRequestDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;

            RuleFor(l => l.Id).NotNull().WithMessage("{PropertyName} must be present");
            RuleFor(l => l.StartDate).NotEmpty().LessThan(l => l.EndDate).WithMessage("{PropertyName} must be before {ComparisonValue}");
            RuleFor(l => l.EndDate).NotEmpty().GreaterThan(l => l.StartDate).WithMessage("{PropertyName} must be after {ComparisonValue}");
            RuleFor(l => l.LeaveTypeId).MustAsync(async (id, token) =>
            {
                var leaveTypeExist = await _leaveTypeRepository.Exists(id);
                return !leaveTypeExist;
            }).WithMessage("{PropertyName does not exist.");
        }
    }
}
