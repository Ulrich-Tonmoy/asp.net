using UniversityCourseAndResultManagementSystem.Common;
using UniversityCourseAndResultManagementSystem.Common.QueryParameters;
using UniversityCourseAndResultManagementSystem.DTO.SemesterDto;
using UniversityCourseAndResultManagementSystem.Repository.Contracts;
using UniversityCourseAndResultManagementSystem.Service.Contracts;

namespace UniversityCourseAndResultManagementSystem.Service
{
    public class SemesterService : ISemesterService
    {
        private IUnitOfWork _unitOfWork;

        public SemesterService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<PagedList<SemesterResponseDto>> GetAllSemesterAsyncWithParam(SemesterQueryParameters semesterParam)
        {
            throw new NotImplementedException();
        }

        public Task<SemesterResponseDto> GetSemesterByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<SemesterResponseDto> CreateSemesterAsync(SemesterCreateDto semester)
        {
            throw new NotImplementedException();
        }

        public Task<SemesterResponseDto> UpdateSemesterAsync(SemesterUpdateDto semester)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteSemesterAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AnySemesterAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAllSemesterAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<SemesterResponseDto>> CreateSemesterAsyncRange(List<SemesterCreateDto> semester)
        {
            throw new NotImplementedException();
        }

        public Task<List<SemesterResponseDto>> UpdateSemesterAsyncRange(List<SemesterUpdateDto> semester)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteSemesterAsyncRange(List<Guid> id)
        {
            throw new NotImplementedException();
        }
    }
}
