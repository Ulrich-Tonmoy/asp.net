using UniversityCourseAndResultManagementSystem.Common;
using UniversityCourseAndResultManagementSystem.Common.QueryParameters;
using UniversityCourseAndResultManagementSystem.DTO.TeacherDto;

namespace UniversityCourseAndResultManagementSystem.Service.Contracts
{
    public interface ITeacherService
    {
        Task<PagedList<TeacherResponseDto>> GetAllTeacherAsyncWithParam(TeacherQueryParameters teacherParam);
        Task<PagedList<TeacherResponseDto>> GetTeacherByDeptAsync(Guid id, TeacherQueryParameters teacherParam);
        Task<TeacherResponseDto> GetTeacherByIdAsync(Guid id);
        Task<TeacherResponseDto> CreateTeacherAsync(TeacherCreateDto teacher);
        Task<TeacherResponseDto> UpdateTeacherAsync(TeacherUpdateDto teacher);
        Task<string> DeleteTeacherAsync(Guid id);
        Task<bool> AnyTeacherAsync(string email);
        Task<int> CountAllTeacherAsync();
        Task<int> CountTeacherByDesignationAsync(Guid id);
        Task<int> CountTeacherByDepartmentAsync(Guid id);
    }
}
