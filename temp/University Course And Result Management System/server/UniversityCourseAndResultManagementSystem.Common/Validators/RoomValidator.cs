using FluentValidation;
using UniversityCourseAndResultManagementSystem.DTO.RoomDto;

namespace UniversityCourseAndResultManagementSystem.Common.Validators
{
    public class RoomValidator : AbstractValidator<RoomCreateDto>
    {
        public RoomValidator()
        {
            RuleFor(r => r.RoomNo).NotEmpty().MinimumLength(3);
        }
    }
}
