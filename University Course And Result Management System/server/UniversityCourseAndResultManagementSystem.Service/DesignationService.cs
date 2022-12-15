using UniversityCourseAndResultManagementSystem.Common;
using UniversityCourseAndResultManagementSystem.Common.QueryParameters;
using UniversityCourseAndResultManagementSystem.DTO.DesignationDto;
using UniversityCourseAndResultManagementSystem.Repository.Contracts;
using UniversityCourseAndResultManagementSystem.Service.Contracts;

namespace UniversityCourseAndResultManagementSystem.Service
{
    public class DesignationService : IDesignationService
    {
        private IUnitOfWork _unitOfWork;

        public DesignationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<PagedList<DesignationResponseDto>> GetAllDesignationAsyncWithParam(DesignationQueryParameters designationParam)
        {
            throw new NotImplementedException();
        }

        public Task<DesignationResponseDto> GetDesignationByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<DesignationResponseDto> CreateDesignationAsync(DesignationCreateDto designation)
        {
            throw new NotImplementedException();
        }

        public Task<DesignationResponseDto> UpdateDesignationAsync(DesignationUpdateDto designation)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteDesignationAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AnyDesignationAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAllDesignationAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<DesignationResponseDto>> CreateDesignationAsyncRange(List<DesignationCreateDto> designation)
        {
            throw new NotImplementedException();
        }

        public Task<List<DesignationResponseDto>> UpdateDesignationAsyncRange(List<DesignationUpdateDto> designation)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteDesignationAsyncRange(List<Guid> id)
        {
            throw new NotImplementedException();
        }
    }
}
