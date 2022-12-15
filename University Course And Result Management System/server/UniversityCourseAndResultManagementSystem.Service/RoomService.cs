using UniversityCourseAndResultManagementSystem.Common;
using UniversityCourseAndResultManagementSystem.Common.QueryParameters;
using UniversityCourseAndResultManagementSystem.DTO.RoomDto;
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

        public Task<PagedList<RoomResponseDto>> GetAllRoomAsyncWithParam(RoomQueryParameters roomParam)
        {
            throw new NotImplementedException();
        }

        public Task<RoomResponseDto> GetRoomByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<RoomResponseDto> CreateRoomAsync(RoomCreateDto room)
        {
            throw new NotImplementedException();
        }

        public Task<RoomResponseDto> UpdateRoomAsync(RoomUpdateDto room)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteRoomAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AnyRoomAsync(string roomNo)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAllRoomAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<RoomResponseDto>> CreateRoomAsyncRange(List<RoomCreateDto> room)
        {
            throw new NotImplementedException();
        }

        public Task<List<RoomResponseDto>> UpdateRoomAsyncRange(List<RoomUpdateDto> room)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteRoomAsyncRange(List<Guid> id)
        {
            throw new NotImplementedException();
        }
    }
}
