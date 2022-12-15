using UniversityCourseAndResultManagementSystem.Common;
using UniversityCourseAndResultManagementSystem.Common.QueryParameters;
using UniversityCourseAndResultManagementSystem.DTO.AssignedCourseDto;
using UniversityCourseAndResultManagementSystem.Repository.Contracts;
using UniversityCourseAndResultManagementSystem.Service.Contracts;

namespace UniversityCourseAndResultManagementSystem.Service
{
    public class AssignedCourseService : IAssignedCourseService
    {
        private IUnitOfWork _unitOfWork;

        public AssignedCourseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<PagedList<AssignedCourseResponseDto>> GetAllAssignedCourseAsyncWithParam(AssignedCourseQueryParameters assignedCourseParam)
        {
            throw new NotImplementedException();
        }

        public Task<AssignedCourseResponseDto> GetAssignedCourseByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<AssignedCourseResponseDto> CreateAssignedCourseAsync(AssignedCourseCreateDto assignedCourse)
        {
            throw new NotImplementedException();
        }

        public Task<AssignedCourseResponseDto> UpdateAssignedCourseAsync(AssignedCourseUpdateDto assignedCourse)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteAssignedCourseAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AnyAssignedCourseAsync(Guid courseId, Guid teacherId)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAllAssignedCourseAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<AssignedCourseResponseDto>> CreateAssignedCourseAsyncRange(List<AssignedCourseCreateDto> assignedCourse)
        {
            throw new NotImplementedException();
        }

        public Task<List<AssignedCourseResponseDto>> UpdateAssignedCourseAsyncRange(List<AssignedCourseUpdateDto> assignedCourse)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteAssignedCourseAsyncRange(List<Guid> id)
        {
            throw new NotImplementedException();
        }
    }
}
