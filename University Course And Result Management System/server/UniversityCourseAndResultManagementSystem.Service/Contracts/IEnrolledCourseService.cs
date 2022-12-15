using UniversityCourseAndResultManagementSystem.Common.QueryParameters;
using UniversityCourseAndResultManagementSystem.Common;
using UniversityCourseAndResultManagementSystem.DTO.EnrolledCourseDto;

namespace UniversityCourseAndResultManagementSystem.Service.Contracts
{
    public interface IEnrolledCourseService
    {
        Task<PagedList<EnrolledCourseResponseDto>> GetAllEnrolledCourseAsyncWithParam(EnrolledCourseQueryParameters enrolledCourseParam);
        Task<EnrolledCourseResponseDto> GetEnrolledCourseByIdAsync(Guid id);
        Task<EnrolledCourseResponseDto> CreateEnrolledCourseAsync(EnrolledCourseCreateDto enrolledCourse);
        Task<EnrolledCourseResponseDto> UpdateEnrolledCourseAsync(EnrolledCourseUpdateDto enrolledCourse);
        Task<string> DeleteEnrolledCourseAsync(Guid id);
        Task<bool> AnyEnrolledCourseAsync(Guid courseId, Guid studentId);
        Task<int> CountAllEnrolledCourseAsync();

        Task<List<EnrolledCourseResponseDto>> CreateEnrolledCourseAsyncRange(List<EnrolledCourseCreateDto> enrolledCourse);
        Task<List<EnrolledCourseResponseDto>> UpdateEnrolledCourseAsyncRange(List<EnrolledCourseUpdateDto> enrolledCourse);
        Task<string> DeleteEnrolledCourseAsyncRange(List<Guid> id);
    }
}
