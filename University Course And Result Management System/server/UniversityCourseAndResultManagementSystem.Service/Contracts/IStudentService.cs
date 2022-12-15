using UniversityCourseAndResultManagementSystem.Common.QueryParameters;
using UniversityCourseAndResultManagementSystem.Common;
using UniversityCourseAndResultManagementSystem.DTO.StudentDto;

namespace UniversityCourseAndResultManagementSystem.Service.Contracts
{
    public interface IStudentService
    {
        Task<PagedList<StudentResponseDto>> GetAllStudentAsyncWithParam(StudentQueryParameters studentParam);
        Task<StudentResponseDto> GetStudentByIdAsync(Guid id);
        Task<StudentResponseDto> CreateStudentAsync(StudentCreateDto student);
        Task<StudentResponseDto> UpdateStudentAsync(StudentUpdateDto student);
        Task<string> DeleteStudentAsync(Guid id);
        Task<bool> AnyStudentAsync(string regiNo);
        Task<int> CountAllStudentAsync();
        Task<int> CountStudentByDepartmentAsync(Guid id);

        Task<List<StudentResponseDto>> CreateStudentAsyncRange(List<StudentCreateDto> student);
        Task<List<StudentResponseDto>> UpdateStudentAsyncRange(List<StudentUpdateDto> student);
        Task<string> DeleteStudentAsyncRange(List<Guid> id);
    }
}
