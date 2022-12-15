using UniversityCourseAndResultManagementSystem.Common;
using UniversityCourseAndResultManagementSystem.Common.QueryParameters;
using UniversityCourseAndResultManagementSystem.DTO.TeacherDto;
using UniversityCourseAndResultManagementSystem.Repository.Contracts;
using UniversityCourseAndResultManagementSystem.Service.Contracts;

namespace UniversityCourseAndResultManagementSystem.Service
{
    public class TeacherService : ITeacherService
    {
        private IUnitOfWork _unitOfWork;

        public TeacherService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<PagedList<TeacherResponseDto>> GetAllTeacherAsyncWithParam(TeacherQueryParameters teacherParam)
        {
            throw new NotImplementedException();
        }

        public Task<TeacherResponseDto> GetTeacherByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<TeacherResponseDto> CreateTeacherAsync(TeacherCreateDto teacher)
        {
            throw new NotImplementedException();
        }

        public Task<TeacherResponseDto> UpdateTeacherAsync(TeacherUpdateDto teacher)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteTeacherAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AnyTeacherAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAllTeacherAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> CountTeacherByDepartmentAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountTeacherByDesignationAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TeacherResponseDto>> CreateTeacherAsyncRange(List<TeacherCreateDto> teacher)
        {
            throw new NotImplementedException();
        }

        public Task<List<TeacherResponseDto>> UpdateTeacherAsyncRange(List<TeacherUpdateDto> teacher)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteTeacherAsyncRange(List<Guid> id)
        {
            throw new NotImplementedException();
        }
    }
}
