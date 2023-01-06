using Microsoft.EntityFrameworkCore;
using UniversityCourseAndResultManagementSystem.Common;
using UniversityCourseAndResultManagementSystem.Common.QueryParameters;
using UniversityCourseAndResultManagementSystem.DTO.AssignedCourseDto;
using UniversityCourseAndResultManagementSystem.DTO.CourseDto;
using UniversityCourseAndResultManagementSystem.Model;
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

        public async Task<PagedList<AssignedCourseResponseDto>> GetAllAssignedCourseAsyncWithParam(AssignedCourseQueryParameters assignedCourseParam)
        {
            IQueryable<AssignedCourse> assignedCourses = _unitOfWork.AssignedCourseRepository.GetAllNoTrackingWithParam(assignedCourseParam, x => x.OrderBy(a => a.Id)).Include(c => c.Course).Include(a => a.Teacher);

            List<AssignedCourseResponseDto> assignedCourseDtos = Mapping.Mapper.Map<List<AssignedCourseResponseDto>>(assignedCourses);

            var count = await CountAllAssignedCourseAsync();
            PagedList<AssignedCourseResponseDto> assignedCourseResults = PagedList<AssignedCourseResponseDto>.ToPagedList(assignedCourseDtos, count, assignedCourseParam.PageNumber, assignedCourseParam.PageSize);

            return assignedCourseResults;
        }

        public async Task<AssignedCourseResponseDto> GetAssignedCourseByIdAsync(Guid id)
        {
            AssignedCourse assignedCourse = _unitOfWork.AssignedCourseRepository.GetByConditionNoTracking(a => a.Id.Equals(id)).Include(c => c.Course).Include(a => a.Teacher).FirstOrDefault();
            AssignedCourseResponseDto assignedCourseResult = Mapping.Mapper.Map<AssignedCourseResponseDto>(assignedCourse);

            return assignedCourseResult;
        }

        public async Task<AssignedCourseResponseDto> CreateAssignedCourseAsync(AssignedCourseCreateDto assignedCourse)
        {
            AssignedCourse assignedCourseModel = Mapping.Mapper.Map<AssignedCourse>(assignedCourse);
            await _unitOfWork.AssignedCourseRepository.AddAsync(assignedCourseModel);

            Course course = _unitOfWork.CourseRepository.GetByConditionNoTracking(c => c.Id.Equals(assignedCourse.CourseId)).FirstOrDefault();
            Teacher teacher = _unitOfWork.TeacherRepository.GetByConditionNoTracking(t => t.Id.Equals(assignedCourse.TeacherId)).FirstOrDefault();
            teacher.CreditTaken += course.Credit;
            _unitOfWork.TeacherRepository.Update(teacher);

            await _unitOfWork.SaveAsync();

            AssignedCourseResponseDto courseResult = Mapping.Mapper.Map<AssignedCourseResponseDto>(assignedCourseModel);

            return courseResult;
        }

        public async Task<AssignedCourseResponseDto> UpdateAssignedCourseAsync(AssignedCourseUpdateDto assignedCourse)
        {
            throw new NotImplementedException();
        }

        public async Task<string> DeleteAssignedCourseAsync(Guid id)
        {
            AssignedCourse assignedCourse = _unitOfWork.AssignedCourseRepository.GetByConditionNoTracking(c => c.Id.Equals(id)).FirstOrDefault();
            if (assignedCourse == null)
            {
                return null;
            }

            await _unitOfWork.AssignedCourseRepository.Delete(assignedCourse);
            await _unitOfWork.SaveAsync();

            return String.Format(GlobalConstants.SUCCESSFULLY_DELETED, "AssignedCourse");
        }

        public async Task<bool> AnyAssignedCourseAsync(Guid courseId, Guid teacherId)
        {
            throw new NotImplementedException();
        }

        public async Task<int> CountAllAssignedCourseAsync()
        {
            return await _unitOfWork.AssignedCourseRepository.CountAllAsync();
        }
    }
}
