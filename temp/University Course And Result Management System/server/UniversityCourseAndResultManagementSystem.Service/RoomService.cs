using UniversityCourseAndResultManagementSystem.Common;
using UniversityCourseAndResultManagementSystem.Common.QueryParameters;
using UniversityCourseAndResultManagementSystem.DTO.RoomDto;
using UniversityCourseAndResultManagementSystem.Model;
using UniversityCourseAndResultManagementSystem.Repository.Contracts;
using UniversityCourseAndResultManagementSystem.Service.Contracts;

namespace UniversityCourseAndResultManagementSystem.Service
{
    public class RoomService : IRoomService
    {
        private IUnitOfWork _unitOfWork;

        public RoomService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PagedList<RoomResponseDto>> GetAllRoomAsyncWithParam(RoomQueryParameters roomParam)
        {
            IQueryable<Room> rooms = _unitOfWork.RoomRepository.GetAllNoTrackingWithParam(roomParam, x => x.OrderBy(s => s.Id));

            List<RoomResponseDto> roomDtos = Mapping.Mapper.Map<List<RoomResponseDto>>(rooms);

            var count = await CountAllRoomAsync();
            PagedList<RoomResponseDto> roomResults = PagedList<RoomResponseDto>.ToPagedList(roomDtos, count, roomParam.PageNumber, roomParam.PageSize);

            return roomResults;
        }

        public async Task<RoomResponseDto> GetRoomByIdAsync(Guid id)
        {
            Room room = _unitOfWork.RoomRepository.GetByConditionNoTracking(c => c.Id.Equals(id)).FirstOrDefault();
            RoomResponseDto roomResult = Mapping.Mapper.Map<RoomResponseDto>(room);

            return roomResult;
        }

        public async Task<RoomResponseDto> CreateRoomAsync(RoomCreateDto room)
        {
            Room roomModel = Mapping.Mapper.Map<Room>(room);
            await _unitOfWork.RoomRepository.AddAsync(roomModel);

            await _unitOfWork.SaveAsync();
            RoomResponseDto roomResult = Mapping.Mapper.Map<RoomResponseDto>(roomModel);

            return roomResult;
        }

        public async Task<string> UnAllocateRoomAsync()
        {
            IQueryable<Schedule> schedules = _unitOfWork.ScheduleRepository.GetAllNoTracking();
            foreach (var schedule in schedules)
            {
                schedule.IsDeleted = true;
                await _unitOfWork.ScheduleRepository.Update(schedule);
            }
            await _unitOfWork.SaveAsync();
            return String.Format(GlobalConstants.SUCCESSFULLY_DELETED, "Room"); ;
        }

        public async Task<RoomResponseDto> UpdateRoomAsync(RoomUpdateDto room)
        {
            throw new NotImplementedException();
        }

        public async Task<string> DeleteRoomAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AnyRoomAsync(string roomNo)
        {
            throw new NotImplementedException();
        }

        public async Task<int> CountAllRoomAsync()
        {
            return await _unitOfWork.RoomRepository.CountAllAsync();
        }
    }
}
