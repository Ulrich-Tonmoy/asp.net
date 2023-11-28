using EmployeeManagementSystem.Common.Pagination;
using EmployeeManagementSystem.Common.QueryParameters;
using EmployeeManagementSystem.DTO.Job;

namespace EmployeeManagementSystem.Service.Services.Contracts
{
    public interface IJobService
    {
        Task<List<JobResponseDto>> GetAllJobAsync();
        Task<PagedList<JobResponseDto>> GetAllJobAsyncWithParam(JobQueryParameters jobParameters);
        Task<JobResponseDto> GetJobByIdAsync(Guid id);
        Task<JobCreateResponseDto> CreateJobAsync(JobCreateDto employee);
        Task<List<JobCreateResponseDto>> CreateJobAsyncRange(List<JobCreateDto> employee);
        Task<JobUpdateResponseDto> UpdateJobAsync(JobUpdateDto employee);
        Task<List<JobUpdateResponseDto>> UpdateJobAsyncRange(List<JobUpdateDto> employee);
        Task<string> DeleteJobAsync(Guid id);
        Task<string> DeleteJobAsyncRange(List<Guid> id);
        Task<bool> AnyJobAsync(string jobTitle);
        Task<int> CountAllJobAsync();
    }
}
