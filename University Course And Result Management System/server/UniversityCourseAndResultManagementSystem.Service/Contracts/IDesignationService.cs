using UniversityCourseAndResultManagementSystem.Common.QueryParameters;
using UniversityCourseAndResultManagementSystem.Common;
using UniversityCourseAndResultManagementSystem.DTO.DesignationDto;

namespace UniversityCourseAndResultManagementSystem.Service.Contracts
{
    public interface IDesignationService
    {
        Task<PagedList<DesignationResponseDto>> GetAllDesignationAsyncWithParam(DesignationQueryParameters designationParam);
        Task<DesignationResponseDto> GetDesignationByIdAsync(Guid id);
        Task<DesignationResponseDto> CreateDesignationAsync(DesignationCreateDto designation);
        Task<DesignationResponseDto> UpdateDesignationAsync(DesignationUpdateDto designation);
        Task<string> DeleteDesignationAsync(Guid id);
        Task<bool> AnyDesignationAsync(string name);
        Task<int> CountAllDesignationAsync();

        Task<List<DesignationResponseDto>> CreateDesignationAsyncRange(List<DesignationCreateDto> designations);
        Task<List<DesignationResponseDto>> UpdateDesignationAsyncRange(List<DesignationUpdateDto> designations);
        Task<string> DeleteDesignationAsyncRange(List<Guid> ids);
    }
}
