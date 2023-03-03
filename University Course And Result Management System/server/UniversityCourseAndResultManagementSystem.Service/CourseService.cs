using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using UniversityCourseAndResultManagementSystem.Common;
using UniversityCourseAndResultManagementSystem.Common.QueryParameters;
using UniversityCourseAndResultManagementSystem.DTO.CourseDto;
using UniversityCourseAndResultManagementSystem.DTO.CourseDto;
using UniversityCourseAndResultManagementSystem.Model;
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

        public async Task<PagedList<CourseResponseDto>> GetAllCourseAsyncWithParam(CourseQueryParameters courseParam)
        {
            IQueryable<Course> courses = _unitOfWork.CourseRepository.GetAllNoTrackingWithParam(courseParam, x => x.OrderBy(c => c.Id)).Include(c => c.Department).Include(c => c.SemesterCourse).ThenInclude(s => s.Semester).Include(c => c.AssignedCourse).ThenInclude(t => t.Teacher).Include(c => c.Schedules).ThenInclude(r => r.Room);

            List<CourseResponseDto> courseDtos = Mapping.Mapper.Map<List<CourseResponseDto>>(courses);

            var count = await CountAllCourseAsync();
            PagedList<CourseResponseDto> courseResults = PagedList<CourseResponseDto>.ToPagedList(courseDtos, count, courseParam.PageNumber, courseParam.PageSize);

            return courseResults;
        }

        public async Task<PagedList<CourseResponseDto>> GetCourseByDeptAsync(Guid id, CourseQueryParameters courseParam)
        {
            IQueryable<Course> course = _unitOfWork.CourseRepository.GetByConditionNoTracking(c => c.DepartmentId.Equals(id)).Include(c => c.Department).Include(c => c.SemesterCourse).ThenInclude(s => s.Semester).Include(c => c.AssignedCourse).ThenInclude(t => t.Teacher).Include(c => c.Schedules).ThenInclude(r => r.Room);
            if (courseParam.IsAssignedCheck) course = _unitOfWork.CourseRepository.GetByConditionNoTracking(c => c.DepartmentId.Equals(id)).Where(c => c.AssignedCourse.Equals(null));

            List<CourseResponseDto> courseDtos = Mapping.Mapper.Map<List<CourseResponseDto>>(course);

            var count = await CountCourseByDepartmentAsync(id);
            PagedList<CourseResponseDto> courseResults = PagedList<CourseResponseDto>.ToPagedList(courseDtos, count, courseParam.PageNumber, courseParam.PageSize);

            return courseResults;
        }

        public async Task<CourseResponseDto> GetCourseByIdAsync(Guid id)
        {
            Course course = _unitOfWork.CourseRepository.GetByConditionNoTracking(c => c.Id.Equals(id)).Include(c => c.Department).FirstOrDefault();
            CourseResponseDto courseResult = Mapping.Mapper.Map<CourseResponseDto>(course);

            return courseResult;
        }

        public async Task<CourseResponseDto> CreateCourseAsync(CourseCreateDto course)
        {
            Course courseModel = Mapping.Mapper.Map<Course>(course);
            await _unitOfWork.CourseRepository.AddAsync(courseModel);

            SemesterCourse semesterCourse = new SemesterCourse
            {
                SemesterId = course.SemesterId,
                CourseId = courseModel.Id
            };
            await _unitOfWork.SemesterCourseRepository.AddAsync(semesterCourse);

            await _unitOfWork.SaveAsync();
            CourseResponseDto courseResult = Mapping.Mapper.Map<CourseResponseDto>(courseModel);

            return courseResult;
        }

        public async Task<CourseResponseDto> UpdateCourseAsync(CourseUpdateDto course)
        {
            Course courseEntity = _unitOfWork.CourseRepository.GetByConditionNoTracking(c => c.Id.Equals(course.Id)).FirstOrDefault();
            if (courseEntity == null)
            {
                return null;
            }

            Mapping.Mapper.Map(course, courseEntity);

            await _unitOfWork.CourseRepository.Update(courseEntity);
            SemesterCourse semesterCourse = new SemesterCourse
            {
                SemesterId = course.SemesterId,
                CourseId = course.Id
            };
            await _unitOfWork.SemesterCourseRepository.Update(semesterCourse);

            await _unitOfWork.SaveAsync();


            CourseResponseDto courseResult = Mapping.Mapper.Map<CourseResponseDto>(courseEntity);

            return courseResult;
        }

        public async Task<string> DeleteCourseAsync(Guid id)
        {
            Course course = _unitOfWork.CourseRepository.GetByConditionNoTracking(c => c.Id.Equals(id)).FirstOrDefault();
            if (course == null)
            {
                return null;
            }

            await _unitOfWork.CourseRepository.Delete(course);
            await _unitOfWork.SaveAsync();

            return String.Format(GlobalConstants.SUCCESSFULLY_DELETED, "Course");
        }

        public async Task<bool> AnyCourseAsync(string code)
        {
            return await _unitOfWork.CourseRepository.AnyAsync(c => c.Code.Equals(code));
        }

        public async Task<int> CountAllCourseAsync()
        {
            return await _unitOfWork.CourseRepository.CountAllAsync();
        }

        public async Task<int> CountCourseByDepartmentAsync(Guid id)
        {
            return await _unitOfWork.CourseRepository.CountByConditionAsync(c => c.DepartmentId.Equals(id));
        }
    }
}
