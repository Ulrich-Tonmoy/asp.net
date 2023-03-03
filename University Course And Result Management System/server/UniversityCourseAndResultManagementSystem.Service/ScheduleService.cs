using Microsoft.EntityFrameworkCore;
using UniversityCourseAndResultManagementSystem.Common;
using UniversityCourseAndResultManagementSystem.Common.QueryParameters;
using UniversityCourseAndResultManagementSystem.DTO.ScheduleDto;
using UniversityCourseAndResultManagementSystem.Model;
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

        public async Task<PagedList<ScheduleResponseDto>> GetAllScheduleAsyncWithParam(ScheduleQueryParameters scheduleParam)
        {
            IQueryable<Schedule> schedules = _unitOfWork.ScheduleRepository.GetAllNoTrackingWithParam(scheduleParam, x => x.OrderBy(s => s.Id)).Include(c=>c.Course).Include(r=>r.Room);

            List<ScheduleResponseDto> scheduleDtos = Mapping.Mapper.Map<List<ScheduleResponseDto>>(schedules);

            var count = await CountAllScheduleAsync();
            PagedList<ScheduleResponseDto> scheduleResults = PagedList<ScheduleResponseDto>.ToPagedList(scheduleDtos, count, scheduleParam.PageNumber, scheduleParam.PageSize);

            return scheduleResults;
        }

        public async Task<ScheduleResponseDto> GetScheduleByIdAsync(Guid id)
        {
            Schedule schedule = _unitOfWork.ScheduleRepository.GetByConditionNoTracking(c => c.Id.Equals(id)).FirstOrDefault();
            ScheduleResponseDto scheduleResult = Mapping.Mapper.Map<ScheduleResponseDto>(schedule);

            return scheduleResult;
        }

        public async Task<ScheduleResponseDto> CreateScheduleAsync(ScheduleCreateDto schedule)
        {
            Schedule scheduleModel = Mapping.Mapper.Map<Schedule>(schedule);
            await _unitOfWork.ScheduleRepository.AddAsync(scheduleModel);

            await _unitOfWork.SaveAsync();
            ScheduleResponseDto scheduleResult = Mapping.Mapper.Map<ScheduleResponseDto>(scheduleModel);

            return scheduleResult;
        }

        public async Task<ScheduleResponseDto> UpdateScheduleAsync(ScheduleUpdateDto schedule)
        {
            throw new NotImplementedException();
        }

        public async Task<string> DeleteScheduleAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AnyScheduleAsync(Guid courseId, Guid roomId, string day, string from)
        {
            throw new NotImplementedException();
        }

        public async Task<int> CountAllScheduleAsync()
        {
            return await _unitOfWork.ScheduleRepository.CountAllAsync();
        }
    }
}
