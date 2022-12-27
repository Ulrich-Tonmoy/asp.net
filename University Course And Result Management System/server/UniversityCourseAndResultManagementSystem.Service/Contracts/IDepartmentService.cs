using UniversityCourseAndResultManagementSystem.Common.QueryParameters;
using UniversityCourseAndResultManagementSystem.Common;
using UniversityCourseAndResultManagementSystem.DTO.DepartmentDto;

namespace UniversityCourseAndResultManagementSystem.Service.Contracts
{
    public interface IDepartmentService
    {
        Task<PagedList<DepartmentResponseDto>> GetAllDepartmentAsyncWithParam(DepartmentQueryParameters departmentParam);
        Task<DepartmentResponseDto> GetDepartmentByIdAsync(Guid id);
        Task<DepartmentResponseDto> CreateDepartmentAsync(DepartmentCreateDto department);
        Task<DepartmentResponseDto> UpdateDepartmentAsync(DepartmentUpdateDto department);
        Task<string> DeleteDepartmentAsync(Guid id);
        Task<bool> AnyDepartmentAsync(string code);
        Task<int> CountAllDepartmentAsync();
    }
}
