using UniversityCourseAndResultManagementSystem.Common;
using UniversityCourseAndResultManagementSystem.Common.QueryParameters;
using UniversityCourseAndResultManagementSystem.DTO.DepartmentDto;
using UniversityCourseAndResultManagementSystem.Repository.Contracts;
using UniversityCourseAndResultManagementSystem.Service.Contracts;

namespace UniversityCourseAndResultManagementSystem.Service
{
    public class DepartmentService : IDepartmentService
    {
        private IUnitOfWork _unitOfWork;

        public DepartmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<PagedList<DepartmentResponseDto>> GetAllDepartmentAsyncWithParam(DepartmentQueryParameters departmentParam)
        {
            throw new NotImplementedException();
        }

        public Task<DepartmentResponseDto> GetDepartmentByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<DepartmentResponseDto> CreateDepartmentAsync(DepartmentCreateDto department)
        {
            throw new NotImplementedException();
        }

        public Task<DepartmentResponseDto> UpdateDepartmentAsync(DepartmentUpdateDto department)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteDepartmentAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AnyDepartmentAsync(string code)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAllDepartmentAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<DepartmentResponseDto>> CreateDepartmentAsyncRange(List<DepartmentCreateDto> department)
        {
            throw new NotImplementedException();
        }

        public Task<List<DepartmentResponseDto>> UpdateDepartmentAsyncRange(List<DepartmentUpdateDto> department)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteDepartmentAsyncRange(List<Guid> id)
        {
            throw new NotImplementedException();
        }
    }
}
