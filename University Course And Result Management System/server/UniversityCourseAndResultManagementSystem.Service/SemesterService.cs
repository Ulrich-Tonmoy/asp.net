using Microsoft.EntityFrameworkCore;
using UniversityCourseAndResultManagementSystem.Common;
using UniversityCourseAndResultManagementSystem.Common.QueryParameters;
using UniversityCourseAndResultManagementSystem.DTO.CourseDto;
using UniversityCourseAndResultManagementSystem.DTO.SemesterDto;
using UniversityCourseAndResultManagementSystem.Model;
using UniversityCourseAndResultManagementSystem.Repository.Contracts;
using UniversityCourseAndResultManagementSystem.Service.Contracts;

namespace UniversityCourseAndResultManagementSystem.Service
{
    public class SemesterService : ISemesterService
    {
        private IUnitOfWork _unitOfWork;

        public SemesterService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PagedList<SemesterResponseDto>> GetAllSemesterAsyncWithParam(SemesterQueryParameters semesterParam)
        {
            IQueryable<Semester> semesters = _unitOfWork.SemesterRepository.GetAllNoTrackingWithParam(semesterParam, x => x.OrderBy(s => s.Id));

            List<SemesterResponseDto> semesterDtos = Mapping.Mapper.Map<List<SemesterResponseDto>>(semesters);

            var count = await CountAllSemesterAsync();
            PagedList<SemesterResponseDto> semesterResults = PagedList<SemesterResponseDto>.ToPagedList(semesterDtos, count, semesterParam.PageNumber, semesterParam.PageSize);

            return semesterResults;
        }

        public async Task<SemesterResponseDto> GetSemesterByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<SemesterResponseDto> CreateSemesterAsync(SemesterCreateDto semester)
        {
            Semester semesterModel = Mapping.Mapper.Map<Semester>(semester);
            await _unitOfWork.SemesterRepository.AddAsync(semesterModel);
            await _unitOfWork.SaveAsync();

            SemesterResponseDto semesterResult = Mapping.Mapper.Map<SemesterResponseDto>(semesterModel);

            return semesterResult;
        }

        public async Task<SemesterResponseDto> UpdateSemesterAsync(SemesterUpdateDto semester)
        {
            throw new NotImplementedException();
        }

        public async Task<string> DeleteSemesterAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AnySemesterAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<int> CountAllSemesterAsync()
        {
            return await _unitOfWork.SemesterRepository.CountAllAsync();
        }
    }
}
