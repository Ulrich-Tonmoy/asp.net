using UniversityCourseAndResultManagementSystem.Common.QueryParameters;
using UniversityCourseAndResultManagementSystem.Common;
using UniversityCourseAndResultManagementSystem.DTO.SemesterDto;

namespace UniversityCourseAndResultManagementSystem.Service.Contracts
{
    public interface ISemesterService
    {
        Task<PagedList<SemesterResponseDto>> GetAllSemesterAsyncWithParam(SemesterQueryParameters semesterParam);
        Task<SemesterResponseDto> GetSemesterByIdAsync(Guid id);
        Task<SemesterResponseDto> CreateSemesterAsync(SemesterCreateDto semester);
        Task<SemesterResponseDto> UpdateSemesterAsync(SemesterUpdateDto semester);
        Task<string> DeleteSemesterAsync(Guid id);
        Task<bool> AnySemesterAsync(string name);
        Task<int> CountAllSemesterAsync();
    }
}
