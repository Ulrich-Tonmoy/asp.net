using FluentValidation;
using UniversityCourseAndResultManagementSystem.DTO.ScheduleDto;

namespace UniversityCourseAndResultManagementSystem.Common.Validators
{
    public class ScheduleValidator : AbstractValidator<ScheduleCreateDto>
    {
        public ScheduleValidator()
        {
            RuleFor(s => s.RoomId).NotEmpty();
            RuleFor(s => s.Day).NotEmpty();
            RuleFor(s => s.From).NotEmpty();
            RuleFor(s => s.To).NotEmpty();
            RuleFor(s => s.CourseId).NotEmpty();
        }
    }
}
