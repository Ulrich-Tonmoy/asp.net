using UniversityCourseAndResultManagementSystem.Common;
using UniversityCourseAndResultManagementSystem.Common.QueryParameters;
using UniversityCourseAndResultManagementSystem.DTO.CourseDto;
using UniversityCourseAndResultManagementSystem.Repository.Contracts;
using UniversityCourseAndResultManagementSystem.Service.Contracts;

namespace UniversityCourseAndResultManagementSystem.Service
{
    public class CourseService : ICourseService
    {
        private IUnitOfWork _unitOfWork;

        public CourseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<PagedList<CourseResponseDto>> GetAllCourseAsyncWithParam(CourseQueryParameters courseParam)
        {
            throw new NotImplementedException();
        }

        public Task<CourseResponseDto> GetCourseByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<CourseResponseDto> CreateCourseAsync(CourseCreateDto course)
        {
            throw new NotImplementedException();
        }

        public Task<CourseResponseDto> UpdateCourseAsync(CourseUpdateDto course)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteCourseAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AnyCourseAsync(string code)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAllCourseAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> CountCourseByDepartmentAsync(Guid departmentId)
        {
            throw new NotImplementedException();
        }

        public Task<List<CourseResponseDto>> CreateCourseAsyncRange(List<CourseCreateDto> course)
        {
            throw new NotImplementedException();
        }

        public Task<List<CourseResponseDto>> UpdateCourseAsyncRange(List<CourseUpdateDto> course)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteCourseAsyncRange(List<Guid> id)
        {
            throw new NotImplementedException();
        }
    }
}
