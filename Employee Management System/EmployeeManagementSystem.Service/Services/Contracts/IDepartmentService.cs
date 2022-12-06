using EmployeeManagementSystem.Common.Pagination;
using EmployeeManagementSystem.Common.QueryParameters;
using EmployeeManagementSystem.DTO.Department;

namespace EmployeeManagementSystem.Service.Services.Contracts
{
    public interface IDepartmentService
    {
        Task<List<DepartmentResponseDto>> GetAllDepartmentsAsync();
        Task<PagedList<DepartmentResponseDto>> GetAllDepartmentsAsyncWithParam(DepartmentQueryParameters deptParameters);
        Task<DepartmentResponseDto> GetDepartmentByIdAsync(Guid id);
        Task<DepartmentCreateResponseDto> CreateDepartmentAsync(DepartmentCreateDto employee);
        Task<List<DepartmentCreateResponseDto>> CreateDepartmentAsyncRange(List<DepartmentCreateDto> employee);
        Task<DepartmentUpdateResponseDto> UpdateDepartmentAsync(DepartmentUpdateDto employee);
        Task<List<DepartmentUpdateResponseDto>> UpdateDepartmentAsyncRange(List<DepartmentUpdateDto> employee);
        Task<string> DeleteDepartmentAsync(Guid id);
        Task<string> DeleteDepartmentAsyncRange(List<Guid> id);
        Task<bool> AnyDepartmentAsync(string deptName);
        Task<int> CountAllDepartmentAsync();
    }
}
