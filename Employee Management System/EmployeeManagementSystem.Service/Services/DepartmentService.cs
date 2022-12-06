using EmployeeManagementSystem.Common.Constants;
using EmployeeManagementSystem.Service.Services.Contracts;
using EmployeeManagementSystem.Model;
using EmployeeManagementSystem.Common;
using EmployeeManagementSystem.Repository.Contracts;
using EmployeeManagementSystem.DTO.Department;
using EmployeeManagementSystem.Common.QueryParameters;
using EmployeeManagementSystem.Common.Pagination;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace EmployeeManagementSystem.Service.Services
{
    public class DepartmentService : IDepartmentService
    {
        private IUnitOfWork _unitOfWork;

        public DepartmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<DepartmentResponseDto>> GetAllDepartmentsAsync()
        {

            List<Department> departments = await _unitOfWork.DepartmentRepository.GetAllNoTracking().ToListAsync();
            List<DepartmentResponseDto> departmentsResult = Mapping.Mapper.Map<List<DepartmentResponseDto>>(departments);

            return departmentsResult;
        }

        public async Task<PagedList<DepartmentResponseDto>> GetAllDepartmentsAsyncWithParam(DepartmentQueryParameters deptParameters)
        {
            IQueryable<Department> departments = _unitOfWork.DepartmentRepository.GetAllNoTrackingWithParam(deptParameters, x => x.OrderBy(d => d.DepartmentName));

            List<DepartmentResponseDto> deptRes = Mapping.Mapper.Map<List<DepartmentResponseDto>>(departments);

            int count = await _unitOfWork.DepartmentRepository.CountAllAsync();
            PagedList<DepartmentResponseDto> departmentsResult = PagedList<DepartmentResponseDto>.ToPagedList(deptRes, count, deptParameters.PageNumber, deptParameters.PageSize);

            return departmentsResult;
        }

        public async Task<DepartmentResponseDto> GetDepartmentByIdAsync(Guid id)
        {
            Department department = await _unitOfWork.DepartmentRepository.GetByConditionNoTracking(d => d.Id.Equals(id)).FirstOrDefaultAsync();
            DepartmentResponseDto departmentResult = Mapping.Mapper.Map<DepartmentResponseDto>(department);

            return departmentResult;
        }

        public async Task<DepartmentCreateResponseDto> CreateDepartmentAsync(DepartmentCreateDto departmentCreateDto)
        {
            Department departmentModel = Mapping.Mapper.Map<Department>(departmentCreateDto);
            await _unitOfWork.DepartmentRepository.AddAsync(departmentModel);
            await _unitOfWork.SaveAsync();

            DepartmentCreateResponseDto departmentResponseDto = Mapping.Mapper.Map<DepartmentCreateResponseDto>(departmentModel);

            return departmentResponseDto;

        }

        public async Task<List<DepartmentCreateResponseDto>> CreateDepartmentAsyncRange(List<DepartmentCreateDto> departmentCreateDto)
        {
            List<Department> departmentModel = Mapping.Mapper.Map<List<Department>>(departmentCreateDto);

            await _unitOfWork.DepartmentRepository.AddAsyncRange(departmentModel);
            await _unitOfWork.SaveAsync();

            List<DepartmentCreateResponseDto> departmentResponseDto = Mapping.Mapper.Map<List<DepartmentCreateResponseDto>>(departmentModel);

            return departmentResponseDto;

        }

        public async Task<DepartmentUpdateResponseDto> UpdateDepartmentAsync(DepartmentUpdateDto departmentUpdateDto)
        {
            Department departmentEntity = await _unitOfWork.DepartmentRepository.GetByConditionNoTracking(d => d.Id.Equals(departmentUpdateDto.Id)).FirstOrDefaultAsync();

            if (departmentEntity == null)
            {
                return null;
            }

            Mapping.Mapper.Map(departmentUpdateDto, departmentEntity);

            await _unitOfWork.DepartmentRepository.Update(departmentEntity);
            await _unitOfWork.SaveAsync();

            DepartmentUpdateResponseDto departmentResponseDto = Mapping.Mapper.Map<DepartmentUpdateResponseDto>(departmentEntity);

            return departmentResponseDto;
        }

        public async Task<List<DepartmentUpdateResponseDto>> UpdateDepartmentAsyncRange(List<DepartmentUpdateDto> departmentUpdateDto)
        {
            IEnumerable<Guid> id = departmentUpdateDto.Select(d => d.Id);

            List<Department> departmentEntity = await _unitOfWork.DepartmentRepository.GetByConditionNoTracking(d => id.Contains(d.Id)).ToListAsync();

            if (departmentEntity.Count() != id.Count())
            {
                return null;
            }

            Mapping.Mapper.Map(departmentUpdateDto, departmentEntity);

            await _unitOfWork.DepartmentRepository.UpdateRange(departmentEntity);
            await _unitOfWork.SaveAsync();

            List<DepartmentUpdateResponseDto> departmentResponseDto = Mapping.Mapper.Map<List<DepartmentUpdateResponseDto>>(departmentEntity);

            return departmentResponseDto;
        }

        public async Task<String> DeleteDepartmentAsync(Guid id)
        {
            Department department = await _unitOfWork.DepartmentRepository.GetByConditionNoTracking(d => d.Id.Equals(id)).FirstOrDefaultAsync();
            if (department == null)
            {
                return null;
            }

            await _unitOfWork.DepartmentRepository.Delete(department);
            await _unitOfWork.SaveAsync();

            return String.Format(ServerResponseConstants.SUCCESSFULLY_DELETED, "Department");
        }

        public async Task<String> DeleteDepartmentAsyncRange(List<Guid> id)
        {
            List<Department> department = await _unitOfWork.DepartmentRepository.GetByConditionNoTracking(d => id.Contains(d.Id)).ToListAsync();
            if (department.Count() != id.Count())
            {
                return null;
            }

            await _unitOfWork.DepartmentRepository.DeleteRange(department);
            await _unitOfWork.SaveAsync();

            return String.Format(ServerResponseConstants.SUCCESSFULLY_DELETED, "Department");
        }

        public async Task<bool> AnyDepartmentAsync(string deptName)
        {
            return await _unitOfWork.DepartmentRepository.AnyAsync(d => d.DepartmentName.Equals(deptName));
        }

        public async Task<int> CountAllDepartmentAsync()
        {
            var totalDepartment = await _unitOfWork.DepartmentRepository.CountAllAsync();

            return totalDepartment;
        }
    }
}
