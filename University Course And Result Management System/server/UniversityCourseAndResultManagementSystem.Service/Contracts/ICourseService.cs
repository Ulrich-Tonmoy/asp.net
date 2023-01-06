using UniversityCourseAndResultManagementSystem.Common.QueryParameters;
using UniversityCourseAndResultManagementSystem.Common;
using UniversityCourseAndResultManagementSystem.DTO.CourseDto;

namespace UniversityCourseAndResultManagementSystem.Service.Contracts
{
    public interface ICourseService
    {
        Task<PagedList<CourseResponseDto>> GetAllCourseAsyncWithParam(CourseQueryParameters courseParam);
        Task<PagedList<CourseResponseDto>> GetCourseByDeptAsync(Guid id, CourseQueryParameters courseParam);
        Task<CourseResponseDto> GetCourseByIdAsync(Guid id);
        Task<CourseResponseDto> CreateCourseAsync(CourseCreateDto course);
        Task<CourseResponseDto> UpdateCourseAsync(CourseUpdateDto course);
        Task<string> DeleteCourseAsync(Guid id);
        Task<bool> AnyCourseAsync(string code);
        Task<int> CountAllCourseAsync();
        Task<int> CountCourseByDepartmentAsync(Guid id);
    }
}
