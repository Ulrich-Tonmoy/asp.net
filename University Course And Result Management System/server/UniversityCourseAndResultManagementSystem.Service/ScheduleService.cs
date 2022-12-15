using UniversityCourseAndResultManagementSystem.Common;
using UniversityCourseAndResultManagementSystem.Common.QueryParameters;
using UniversityCourseAndResultManagementSystem.DTO.ScheduleDto;
using UniversityCourseAndResultManagementSystem.Repository.Contracts;
using UniversityCourseAndResultManagementSystem.Service.Contracts;

namespace UniversityCourseAndResultManagementSystem.Service
{
    public class ScheduleService : IScheduleService
    {
        private IUnitOfWork _unitOfWork;

        public ScheduleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<PagedList<ScheduleResponseDto>> GetAllScheduleAsyncWithParam(ScheduleQueryParameters scheduleParam)
        {
            throw new NotImplementedException();
        }

        public Task<ScheduleResponseDto> GetScheduleByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ScheduleResponseDto> CreateScheduleAsync(ScheduleCreateDto schedule)
        {
            throw new NotImplementedException();
        }

        public Task<ScheduleResponseDto> UpdateScheduleAsync(ScheduleUpdateDto schedule)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteScheduleAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AnyScheduleAsync(Guid courseId, Guid roomId, string day, string from)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAllScheduleAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<ScheduleResponseDto>> CreateScheduleAsyncRange(List<ScheduleCreateDto> schedule)
        {
            throw new NotImplementedException();
        }

        public Task<List<ScheduleResponseDto>> UpdateScheduleAsyncRange(List<ScheduleUpdateDto> schedule)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteScheduleAsyncRange(List<Guid> id)
        {
            throw new NotImplementedException();
        }
    }
}
