using UniversityCourseAndResultManagementSystem.Common;
using UniversityCourseAndResultManagementSystem.Common.QueryParameters;
using UniversityCourseAndResultManagementSystem.DTO.RoomDto;

namespace UniversityCourseAndResultManagementSystem.Service.Contracts
{
    public interface IRoomService
    {
        Task<PagedList<RoomResponseDto>> GetAllRoomAsyncWithParam(RoomQueryParameters roomParam);
        Task<RoomResponseDto> GetRoomByIdAsync(Guid id);
        Task<RoomResponseDto> CreateRoomAsync(RoomCreateDto room);
        Task<string> UnAllocateRoomAsync();
        Task<RoomResponseDto> UpdateRoomAsync(RoomUpdateDto room);
        Task<string> DeleteRoomAsync(Guid id);
        Task<bool> AnyRoomAsync(string roomNo);
        Task<int> CountAllRoomAsync();
    }
}
