using UniversityCourseAndResultManagementSystem.Common.QueryParameters;
using UniversityCourseAndResultManagementSystem.Common;
using UniversityCourseAndResultManagementSystem.DTO.ScheduleDto;

namespace UniversityCourseAndResultManagementSystem.Service.Contracts
{
    public interface IScheduleService
    {
        Task<PagedList<ScheduleResponseDto>> GetAllScheduleAsyncWithParam(ScheduleQueryParameters scheduleParam);
        Task<ScheduleResponseDto> GetScheduleByIdAsync(Guid id);
        Task<ScheduleResponseDto> CreateScheduleAsync(ScheduleCreateDto schedule);
        Task<ScheduleResponseDto> UpdateScheduleAsync(ScheduleUpdateDto schedule);
        Task<string> DeleteScheduleAsync(Guid id);
        Task<bool> AnyScheduleAsync(Guid courseId, Guid roomId, string day, string from);
        Task<int> CountAllScheduleAsync();
    }
}
