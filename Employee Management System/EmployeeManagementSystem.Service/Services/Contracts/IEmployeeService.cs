using EmployeeManagementSystem.Common.Pagination;
using EmployeeManagementSystem.Common.QueryParameters;
using EmployeeManagementSystem.DTO.Employee;
using System.Dynamic;

namespace EmployeeManagementSystem.Service.Services.Contracts
{
    public interface IEmployeeService
    {
        Task<List<EmployeeResponseDto>> GetAllEmployeesAsync();
        Task<PagedList<ExpandoObject>> GetAllEmployeesAsyncWithParam(EmployeeQueryParameters empParameters);
        Task<EmployeeResponseDto> GetEmployeeByIdAsync(Guid id);
        Task<EmployeeCreateResponseDto> CreateEmployeeAsync(EmployeeCreateDto employee);
        Task<List<EmployeeCreateResponseDto>> CreateEmployeeAsyncRange(List<EmployeeCreateDto> employee);
        Task<EmployeeUpdateResponseDto> UpdateEmployeeAsync(EmployeeUpdateDto employee);
        Task<List<EmployeeUpdateResponseDto>> UpdateEmployeeAsyncRange(List<EmployeeUpdateDto> employee);
        Task<string> DeleteEmployeeAsync(Guid id);
        Task<string> DeleteEmployeeAsyncRange(List<Guid> id);
        Task<bool> AnyEmployeeAsync(string email);
        Task<int> CountAllEmployeeAsync();
        Task<int> CountEmployeeByJobTitleAsync(Guid id);
        Task<int> CountEmployeeByDepartmentAsync(Guid id);
    }
}
