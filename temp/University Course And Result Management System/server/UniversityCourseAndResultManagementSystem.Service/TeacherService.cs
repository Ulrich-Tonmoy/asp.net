using Microsoft.EntityFrameworkCore;
using UniversityCourseAndResultManagementSystem.Common;
using UniversityCourseAndResultManagementSystem.Common.QueryParameters;
using UniversityCourseAndResultManagementSystem.DTO.TeacherDto;
using UniversityCourseAndResultManagementSystem.Model;
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

        public async Task<PagedList<TeacherResponseDto>> GetAllTeacherAsyncWithParam(TeacherQueryParameters teacherParam)
        {
            IQueryable<Teacher> teachers = _unitOfWork.TeacherRepository.GetAllNoTrackingWithParam(teacherParam, x => x.OrderBy(t => t.Id)).Include(t => t.Department).Include(t => t.Designation);

            List<TeacherResponseDto> teacherDtos = Mapping.Mapper.Map<List<TeacherResponseDto>>(teachers);

            var count = await CountAllTeacherAsync();
            PagedList<TeacherResponseDto> teacherResults = PagedList<TeacherResponseDto>.ToPagedList(teacherDtos, count, teacherParam.PageNumber, teacherParam.PageSize);

            return teacherResults;
        }

        public async Task<PagedList<TeacherResponseDto>> GetTeacherByDeptAsync(Guid id, TeacherQueryParameters teacherParam)
        {
            IQueryable<Teacher> teacher = _unitOfWork.TeacherRepository.GetByConditionNoTracking(t => t.DepartmentId.Equals(id));
            List<TeacherResponseDto> teacherDtos = Mapping.Mapper.Map<List<TeacherResponseDto>>(teacher);

            var count = await CountTeacherByDesignationAsync(id);
            PagedList<TeacherResponseDto> teacherResults = PagedList<TeacherResponseDto>.ToPagedList(teacherDtos, count, teacherParam.PageNumber, teacherParam.PageSize);

            return teacherResults;
        }

        public async Task<TeacherResponseDto> GetTeacherByIdAsync(Guid id)
        {
            Teacher teacher = _unitOfWork.TeacherRepository.GetByConditionNoTracking(t => t.Id.Equals(id)).Include(t => t.Department).Include(t => t.Designation).FirstOrDefault();
            TeacherResponseDto teacherResult = Mapping.Mapper.Map<TeacherResponseDto>(teacher);

            return teacherResult;
        }

        public async Task<TeacherResponseDto> CreateTeacherAsync(TeacherCreateDto teacher)
        {
            Teacher teacherModel = Mapping.Mapper.Map<Teacher>(teacher);
            await _unitOfWork.TeacherRepository.AddAsync(teacherModel);
            await _unitOfWork.SaveAsync();

            TeacherResponseDto teacherResult = Mapping.Mapper.Map<TeacherResponseDto>(teacherModel);

            return teacherResult;
        }

        public async Task<TeacherResponseDto> UpdateTeacherAsync(TeacherUpdateDto teacher)
        {
            Teacher teacherEntity = _unitOfWork.TeacherRepository.GetByConditionNoTracking(t => t.Id.Equals(teacher.Id)).FirstOrDefault();
            if (teacherEntity == null)
            {
                return null;
            }

            Mapping.Mapper.Map(teacher, teacherEntity);

            await _unitOfWork.TeacherRepository.Update(teacherEntity);
            await _unitOfWork.SaveAsync();


            TeacherResponseDto teacherResult = Mapping.Mapper.Map<TeacherResponseDto>(teacherEntity);

            return teacherResult;
        }

        public async Task<string> DeleteTeacherAsync(Guid id)
        {
            Teacher teacher = _unitOfWork.TeacherRepository.GetByConditionNoTracking(t => t.Id.Equals(id)).FirstOrDefault();
            if (teacher == null)
            {
                return null;
            }

            await _unitOfWork.TeacherRepository.Delete(teacher);
            await _unitOfWork.SaveAsync();

            return String.Format(GlobalConstants.SUCCESSFULLY_DELETED, "Teacher");
        }

        public async Task<bool> AnyTeacherAsync(string email)
        {
            return await _unitOfWork.TeacherRepository.AnyAsync(t => t.Email.Equals(email));
        }

        public async Task<int> CountAllTeacherAsync()
        {
            return await _unitOfWork.TeacherRepository.CountAllAsync();
        }

        public async Task<int> CountTeacherByDepartmentAsync(Guid id)
        {
            return await _unitOfWork.TeacherRepository.CountByConditionAsync(t => t.DepartmentId.Equals(id));
        }

        public async Task<int> CountTeacherByDesignationAsync(Guid id)
        {
            return await _unitOfWork.TeacherRepository.CountByConditionAsync(t => t.DesignationId.Equals(id));
        }
    }
}
