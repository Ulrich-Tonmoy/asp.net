using Microsoft.EntityFrameworkCore;
using UniversityCourseAndResultManagementSystem.Common;
using UniversityCourseAndResultManagementSystem.Common.QueryParameters;
using UniversityCourseAndResultManagementSystem.DTO.DepartmentDto;
using UniversityCourseAndResultManagementSystem.Model;
using UniversityCourseAndResultManagementSystem.Repository.Contracts;
using UniversityCourseAndResultManagementSystem.Service.Contracts;

namespace UniversityCourseAndResultManagementSystem.Service
{
    public class DepartmentService : IDepartmentService
    {
        private IUnitOfWork _unitOfWork;

        public DepartmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PagedList<DepartmentResponseDto>> GetAllDepartmentAsyncWithParam(DepartmentQueryParameters departmentParam)
        {
            IQueryable<Department> depts = _unitOfWork.DepartmentRepository.GetAllNoTrackingWithParam(departmentParam, x => x.OrderBy(d => d.Id)).Include(d => d.Students);

            List<DepartmentResponseDto> deptDtos = Mapping.Mapper.Map<List<DepartmentResponseDto>>(depts);

            int count = await CountAllDepartmentAsync();
            PagedList<DepartmentResponseDto> deptResults = PagedList<DepartmentResponseDto>.ToPagedList(deptDtos, count, departmentParam.PageNumber, departmentParam.PageSize);

            return deptResults;
        }

        public async Task<DepartmentResponseDto> GetDepartmentByIdAsync(Guid id)
        {
            Department dept = _unitOfWork.DepartmentRepository.GetByConditionNoTracking(d => d.Id.Equals(id)).FirstOrDefault();
            DepartmentResponseDto deptResult = Mapping.Mapper.Map<DepartmentResponseDto>(dept);

            return deptResult;
        }

        public async Task<DepartmentResponseDto> CreateDepartmentAsync(DepartmentCreateDto department)
        {
            Department dept = Mapping.Mapper.Map<Department>(department);
            await _unitOfWork.DepartmentRepository.AddAsync(dept);
            await _unitOfWork.SaveAsync();

            DepartmentResponseDto deptResult = Mapping.Mapper.Map<DepartmentResponseDto>(dept);

            return deptResult;
        }

        public async Task<DepartmentResponseDto> UpdateDepartmentAsync(DepartmentUpdateDto department)
        {
            Department deptEntity = _unitOfWork.DepartmentRepository.GetByConditionNoTracking(d => d.Id.Equals(department.Id)).FirstOrDefault();
            if (deptEntity == null)
            {
                return null;
            }

            Mapping.Mapper.Map(department, deptEntity);

            await _unitOfWork.DepartmentRepository.Update(deptEntity);
            await _unitOfWork.SaveAsync();


            DepartmentResponseDto deptResult = Mapping.Mapper.Map<DepartmentResponseDto>(deptEntity);

            return deptResult;
        }

        public async Task<string> DeleteDepartmentAsync(Guid id)
        {
            Department dept = _unitOfWork.DepartmentRepository.GetByConditionNoTracking(d => d.Id.Equals(id)).FirstOrDefault();
            if (dept == null)
            {
                return null;
            }

            await _unitOfWork.DepartmentRepository.Delete(dept);
            await _unitOfWork.SaveAsync();

            return string.Format(GlobalConstants.SUCCESSFULLY_DELETED, "Department");
        }

        public async Task<bool> AnyDepartmentAsync(string code)
        {
            return await _unitOfWork.DepartmentRepository.AnyAsync(d => d.Code.Equals(code));
        }

        public async Task<int> CountAllDepartmentAsync()
        {
            return await _unitOfWork.DepartmentRepository.CountAllAsync();
        }

        public async Task<List<DepartmentResponseDto>> CreateDepartmentAsyncRange(List<DepartmentCreateDto> departments)
        {
            List<Department> depts = Mapping.Mapper.Map<List<Department>>(departments);
            await _unitOfWork.DepartmentRepository.AddAsyncRange(depts);
            await _unitOfWork.SaveAsync();

            List<DepartmentResponseDto> deptResults = Mapping.Mapper.Map<List<DepartmentResponseDto>>(depts);

            return deptResults;
        }

        public async Task<List<DepartmentResponseDto>> UpdateDepartmentAsyncRange(List<DepartmentUpdateDto> departments)
        {
            List<Guid> id = departments.Select(d => d.Id).ToList();
            List<Department> deptEntity = await _unitOfWork.DepartmentRepository.GetByConditionNoTracking(d => id.Contains(d.Id)).ToListAsync();
            if (deptEntity.Count() != id.Count())
            {
                return null;
            }

            Mapping.Mapper.Map(departments, deptEntity);

            await _unitOfWork.DepartmentRepository.UpdateRange(deptEntity);
            await _unitOfWork.SaveAsync();


            List<DepartmentResponseDto> deptResults = Mapping.Mapper.Map<List<DepartmentResponseDto>>(deptEntity);

            return deptResults;
        }

        public async Task<string> DeleteDepartmentAsyncRange(List<Guid> ids)
        {
            List<Department> dept = await _unitOfWork.DepartmentRepository.GetByConditionNoTracking(d => ids.Contains(d.Id)).ToListAsync();
            if (dept.Count() != ids.Count())
            {
                return null;
            }

            await _unitOfWork.DepartmentRepository.DeleteRange(dept);
            await _unitOfWork.SaveAsync();

            return string.Format(GlobalConstants.SUCCESSFULLY_DELETED, "Department");
        }
    }
}
