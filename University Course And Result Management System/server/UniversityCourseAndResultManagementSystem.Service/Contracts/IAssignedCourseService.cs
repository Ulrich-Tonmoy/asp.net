using UniversityCourseAndResultManagementSystem.Common.QueryParameters;
using UniversityCourseAndResultManagementSystem.Common;
using UniversityCourseAndResultManagementSystem.DTO.AssignedCourseDto;

namespace UniversityCourseAndResultManagementSystem.Service.Contracts
{
    public interface IAssignedCourseService
    {
        Task<PagedList<AssignedCourseResponseDto>> GetAllAssignedCourseAsyncWithParam(AssignedCourseQueryParameters assignedCourseParam);
        Task<AssignedCourseResponseDto> GetAssignedCourseByIdAsync(Guid id);
        Task<AssignedCourseResponseDto> CreateAssignedCourseAsync(AssignedCourseCreateDto assignedCourse);
        Task<AssignedCourseResponseDto> UpdateAssignedCourseAsync(AssignedCourseUpdateDto assignedCourse);
        Task<string> DeleteAssignedCourseAsync(Guid id);
        Task<bool> AnyAssignedCourseAsync(Guid courseId, Guid teacherId);
        Task<int> CountAllAssignedCourseAsync();

        Task<List<AssignedCourseResponseDto>> CreateAssignedCourseAsyncRange(List<AssignedCourseCreateDto> assignedCourse);
        Task<List<AssignedCourseResponseDto>> UpdateAssignedCourseAsyncRange(List<AssignedCourseUpdateDto> assignedCourse);
        Task<string> DeleteAssignedCourseAsyncRange(List<Guid> id);
    }
}
