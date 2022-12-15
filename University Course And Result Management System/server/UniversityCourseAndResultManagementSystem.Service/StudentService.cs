using UniversityCourseAndResultManagementSystem.Common;
using UniversityCourseAndResultManagementSystem.Common.QueryParameters;
using UniversityCourseAndResultManagementSystem.DTO.StudentDto;
using UniversityCourseAndResultManagementSystem.Repository.Contracts;
using UniversityCourseAndResultManagementSystem.Service.Contracts;

namespace UniversityCourseAndResultManagementSystem.Service
{
    public class StudentService : IStudentService
    {
        private IUnitOfWork _unitOfWork;

        public StudentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<PagedList<StudentResponseDto>> GetAllStudentAsyncWithParam(StudentQueryParameters studentParam)
        {
            throw new NotImplementedException();
        }

        public Task<StudentResponseDto> GetStudentByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<StudentResponseDto> CreateStudentAsync(StudentCreateDto student)
        {
            throw new NotImplementedException();
        }

        public Task<StudentResponseDto> UpdateStudentAsync(StudentUpdateDto student)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteStudentAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AnyStudentAsync(string regiNo)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAllStudentAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> CountStudentByDepartmentAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<StudentResponseDto>> CreateStudentAsyncRange(List<StudentCreateDto> student)
        {
            throw new NotImplementedException();
        }

        public Task<List<StudentResponseDto>> UpdateStudentAsyncRange(List<StudentUpdateDto> student)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteStudentAsyncRange(List<Guid> id)
        {
            throw new NotImplementedException();
        }
    }
}
