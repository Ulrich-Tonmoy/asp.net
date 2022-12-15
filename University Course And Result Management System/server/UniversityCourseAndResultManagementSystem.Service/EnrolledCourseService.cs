using UniversityCourseAndResultManagementSystem.Common;
using UniversityCourseAndResultManagementSystem.Common.QueryParameters;
using UniversityCourseAndResultManagementSystem.DTO.EnrolledCourseDto;
using UniversityCourseAndResultManagementSystem.Repository.Contracts;
using UniversityCourseAndResultManagementSystem.Service.Contracts;

namespace UniversityCourseAndResultManagementSystem.Service
{
    public class EnrolledCourseService : IEnrolledCourseService
    {
        private IUnitOfWork _unitOfWork;

        public EnrolledCourseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<PagedList<EnrolledCourseResponseDto>> GetAllEnrolledCourseAsyncWithParam(EnrolledCourseQueryParameters enrolledCourseParam)
        {
            throw new NotImplementedException();
        }

        public Task<EnrolledCourseResponseDto> GetEnrolledCourseByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<EnrolledCourseResponseDto> CreateEnrolledCourseAsync(EnrolledCourseCreateDto enrolledCourse)
        {
            throw new NotImplementedException();
        }

        public Task<EnrolledCourseResponseDto> UpdateEnrolledCourseAsync(EnrolledCourseUpdateDto enrolledCourse)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteEnrolledCourseAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AnyEnrolledCourseAsync(Guid courseId, Guid studentId)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAllEnrolledCourseAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<EnrolledCourseResponseDto>> CreateEnrolledCourseAsyncRange(List<EnrolledCourseCreateDto> enrolledCourse)
        {
            throw new NotImplementedException();
        }

        public Task<List<EnrolledCourseResponseDto>> UpdateEnrolledCourseAsyncRange(List<EnrolledCourseUpdateDto> enrolledCourse)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteEnrolledCourseAsyncRange(List<Guid> id)
        {
            throw new NotImplementedException();
        }
    }
}
