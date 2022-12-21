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
            IQueryable<Course> courses = _unitOfWork.CourseRepository.GetAllNoTrackingWithParam(courseParam, x => x.OrderBy(c => c.Id)).Include(c => c.Department);

            List<CourseResponseDto> courseDtos = Mapping.Mapper.Map<List<CourseResponseDto>>(courses);

            var count = await CountAllCourseAsync();
            PagedList<CourseResponseDto> CourseResults = PagedList<CourseResponseDto>.ToPagedList(courseDtos, count, courseParam.PageNumber, courseParam.PageSize);

            return CourseResults;
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

        public async Task<List<CourseResponseDto>> CreateCourseAsyncRange(List<CourseCreateDto> courses)
        {
            List<Course> courseModels = Mapping.Mapper.Map<List<Course>>(courses);

            await _unitOfWork.CourseRepository.AddAsyncRange(courseModels);
            await _unitOfWork.SaveAsync();

            List<CourseResponseDto> courseResults = Mapping.Mapper.Map<List<CourseResponseDto>>(courseModels);

            return courseResults;
        }

        public async Task<List<CourseResponseDto>> UpdateCourseAsyncRange(List<CourseUpdateDto> courses)
        {
            List<Guid> id = courses.Select(c => c.Id).ToList();

            List<Course> courseEntity = await _unitOfWork.CourseRepository.GetByConditionNoTracking(c => id.Contains(c.Id)).ToListAsync();
            if (courseEntity.Count() != id.Count())
            {
                return null;
            }

            Mapping.Mapper.Map(courses, courseEntity);

            await _unitOfWork.CourseRepository.UpdateRange(courseEntity);
            await _unitOfWork.SaveAsync();


            List<CourseResponseDto> courseResults = Mapping.Mapper.Map<List<CourseResponseDto>>(courseEntity);

            return courseResults;
        }

        public async Task<string> DeleteCourseAsyncRange(List<Guid> ids)
        {
            List<Course> course = await _unitOfWork.CourseRepository.GetByConditionNoTracking(c => ids.Contains(c.Id)).ToListAsync();
            if (course.Count() != ids.Count())
            {
                return null;
            }

            await _unitOfWork.CourseRepository.DeleteRange(course);
            await _unitOfWork.SaveAsync();

            return String.Format(GlobalConstants.SUCCESSFULLY_DELETED, "Course");
        }
    }
}
