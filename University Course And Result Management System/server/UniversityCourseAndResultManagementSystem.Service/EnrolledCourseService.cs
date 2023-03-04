using Microsoft.EntityFrameworkCore;
using UniversityCourseAndResultManagementSystem.Common;
using UniversityCourseAndResultManagementSystem.Common.QueryParameters;
using UniversityCourseAndResultManagementSystem.DTO.EnrolledCourseDto;
using UniversityCourseAndResultManagementSystem.DTO.StudentDto;
using UniversityCourseAndResultManagementSystem.Model;
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

        public async Task<PagedList<EnrolledCourseResponseDto>> GetAllEnrolledCourseAsyncWithParam(EnrolledCourseQueryParameters enrolledCourseParam)
        {
            IQueryable<EnrolledCourse> enrolledCourses = _unitOfWork.EnrolledCourseRepository.GetAllNoTrackingWithParam(enrolledCourseParam, x => x.OrderBy(a => a.Id)).Include(c => c.Course);

            List<EnrolledCourseResponseDto> enrolledCourseDtos = Mapping.Mapper.Map<List<EnrolledCourseResponseDto>>(enrolledCourses);

            var count = await CountAllEnrolledCourseAsync();
            PagedList<EnrolledCourseResponseDto> enrolledCourseResults = PagedList<EnrolledCourseResponseDto>.ToPagedList(enrolledCourseDtos, count, enrolledCourseParam.PageNumber, enrolledCourseParam.PageSize);

            return enrolledCourseResults;
        }

        public async Task<EnrolledCourseResponseDto> GetEnrolledCourseByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<EnrolledCourseResponseDto> CreateEnrolledCourseAsync(EnrolledCourseCreateDto enrolledCourse)
        {
            EnrolledCourse enrolledCourseModel = Mapping.Mapper.Map<EnrolledCourse>(enrolledCourse);
            await _unitOfWork.EnrolledCourseRepository.AddAsync(enrolledCourseModel);

            StudentEnrolledCourse _studentEnrolledCourse = new StudentEnrolledCourse
            {
                EnrolledCourseId = enrolledCourseModel.Id,
                StudentId = enrolledCourse.StudentId
            };
            await _unitOfWork.StudentEnrolledCourseRepository.AddAsync(_studentEnrolledCourse);

            await _unitOfWork.SaveAsync();

            EnrolledCourseResponseDto enrolledCourseResult = Mapping.Mapper.Map<EnrolledCourseResponseDto>(enrolledCourseModel);

            return enrolledCourseResult;
        }

        public async Task<EnrolledCourseResponseDto> UpdateEnrolledCourseAsync(EnrolledCourseUpdateDto enrolledCourse)
        {
            EnrolledCourse enrolledCourseEntity = _unitOfWork.EnrolledCourseRepository.GetByConditionNoTracking(s => s.Id.Equals(enrolledCourse.Id)).FirstOrDefault();
            if (enrolledCourseEntity == null)
            {
                return null;
            }

            Mapping.Mapper.Map(enrolledCourse, enrolledCourseEntity);

            await _unitOfWork.EnrolledCourseRepository.Update(enrolledCourseEntity);
            await _unitOfWork.SaveAsync();

            EnrolledCourseResponseDto enrolledCourseResult = Mapping.Mapper.Map<EnrolledCourseResponseDto>(enrolledCourseEntity);

            return enrolledCourseResult;
        }

        public async Task<string> DeleteEnrolledCourseAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AnyEnrolledCourseAsync(Guid courseId, Guid studentId)
        {
            throw new NotImplementedException();
        }

        public async Task<int> CountAllEnrolledCourseAsync()
        {
            return await _unitOfWork.EnrolledCourseRepository.CountAllAsync();
        }
    }
}
