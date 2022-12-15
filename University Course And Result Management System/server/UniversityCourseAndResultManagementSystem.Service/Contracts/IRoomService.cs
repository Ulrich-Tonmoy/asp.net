using UniversityCourseAndResultManagementSystem.Common.QueryParameters;
using UniversityCourseAndResultManagementSystem.Common;
using UniversityCourseAndResultManagementSystem.DTO.RoomDto;

namespace UniversityCourseAndResultManagementSystem.Service.Contracts
{
    public interface IRoomService
    {
        Task<PagedList<RoomResponseDto>> GetAllRoomAsyncWithParam(RoomQueryParameters roomParam);
        Task<RoomResponseDto> GetRoomByIdAsync(Guid id);
        Task<RoomResponseDto> CreateRoomAsync(RoomCreateDto room);
        Task<RoomResponseDto> UpdateRoomAsync(RoomUpdateDto room);
        Task<string> DeleteRoomAsync(Guid id);
        Task<bool> AnyRoomAsync(string roomNo);
        Task<int> CountAllRoomAsync();

        Task<List<RoomResponseDto>> CreateRoomAsyncRange(List<RoomCreateDto> room);
        Task<List<RoomResponseDto>> UpdateRoomAsyncRange(List<RoomUpdateDto> room);
        Task<string> DeleteRoomAsyncRange(List<Guid> id);
    }
}
