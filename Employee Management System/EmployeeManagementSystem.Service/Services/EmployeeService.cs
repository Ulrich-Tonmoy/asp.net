using EmployeeManagementSystem.Model;
using EmployeeManagementSystem.Common.Constants;
using EmployeeManagementSystem.Service.Services.Contracts;
using EmployeeManagementSystem.Common;
using EmployeeManagementSystem.Repository.Contracts;
using EmployeeManagementSystem.DTO.Employee;
using EmployeeManagementSystem.Common.QueryParameters;
using EmployeeManagementSystem.Common.Pagination;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Service.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<EmployeeResponseDto>> GetAllEmployeesAsync()
        {

            List<Employee> employees = await _unitOfWork.EmployeeRepository.GetAllNoTracking().ToListAsync();
            List<EmployeeResponseDto> employeesResult = Mapping.Mapper.Map<List<EmployeeResponseDto>>(employees);

            return employeesResult;
        }

        public async Task<PagedList<EmployeeResponseDto>> GetAllEmployeesAsyncWithParam(EmployeeQueryParameters empParameters)
        {
            IQueryable<Employee> employees = _unitOfWork.EmployeeRepository.GetAllNoTrackingWithParam(empParameters, x => x.OrderBy(e => e.Id));

            List<EmployeeResponseDto> empRes = Mapping.Mapper.Map<List<EmployeeResponseDto>>(employees);

            var count = await _unitOfWork.EmployeeRepository.CountAllAsync();
            PagedList<EmployeeResponseDto> employeesResult = PagedList<EmployeeResponseDto>.ToPagedList(empRes, count, empParameters.PageNumber, empParameters.PageSize);

            return employeesResult;
        }

        public async Task<EmployeeResponseDto> GetEmployeeByIdAsync(Guid id)
        {
            Employee employee = _unitOfWork.EmployeeRepository.GetByConditionNoTracking(e => e.Id.Equals(id)).FirstOrDefault();
            EmployeeResponseDto employeeResult = Mapping.Mapper.Map<EmployeeResponseDto>(employee);

            return employeeResult;
        }

        public async Task<EmployeeCreateResponseDto> CreateEmployeeAsync(EmployeeCreateDto employeeCreateDto)
        {
            Employee employeeModel = Mapping.Mapper.Map<Employee>(employeeCreateDto);
            await _unitOfWork.EmployeeRepository.AddAsync(employeeModel);
            await _unitOfWork.SaveAsync();

            EmployeeCreateResponseDto employeeResponseDto = Mapping.Mapper.Map<EmployeeCreateResponseDto>(employeeModel);

            return employeeResponseDto;
        }

        public async Task<List<EmployeeCreateResponseDto>> CreateEmployeeAsyncRange(List<EmployeeCreateDto> employeeCreateDto)
        {
            List<Employee> employeeModel = Mapping.Mapper.Map<List<Employee>>(employeeCreateDto);

            await _unitOfWork.EmployeeRepository.AddAsyncRange(employeeModel);
            await _unitOfWork.SaveAsync();

            List<EmployeeCreateResponseDto> employeeResponseDto = Mapping.Mapper.Map<List<EmployeeCreateResponseDto>>(employeeModel);

            return employeeResponseDto;
        }

        public async Task<EmployeeUpdateResponseDto> UpdateEmployeeAsync(EmployeeUpdateDto employeeUpateDto)
        {
            Employee employeeEntity = _unitOfWork.EmployeeRepository.GetByConditionNoTracking(e => e.Id.Equals(employeeUpateDto.Id)).FirstOrDefault();
            if (employeeEntity == null)
            {
                return null;
            }

            Mapping.Mapper.Map(employeeUpateDto, employeeEntity);

            await _unitOfWork.EmployeeRepository.Update(employeeEntity);
            await _unitOfWork.SaveAsync();


            EmployeeUpdateResponseDto employeeResponseDto = Mapping.Mapper.Map<EmployeeUpdateResponseDto>(employeeEntity);

            return employeeResponseDto;
        }

        public async Task<List<EmployeeUpdateResponseDto>> UpdateEmployeeAsyncRange(List<EmployeeUpdateDto> employeeUpdateDto)
        {
            IEnumerable<Guid> id = employeeUpdateDto.Select(e => e.Id);

            List<Employee> employeeEntity = await _unitOfWork.EmployeeRepository.GetByConditionNoTracking(e => id.Contains(e.Id)).ToListAsync();
            if (employeeEntity.Count() != id.Count())
            {
                return null;
            }

            Mapping.Mapper.Map(employeeUpdateDto, employeeEntity);

            await _unitOfWork.EmployeeRepository.UpdateRange(employeeEntity);
            await _unitOfWork.SaveAsync();


            List<EmployeeUpdateResponseDto> employeeResponseDto = Mapping.Mapper.Map<List<EmployeeUpdateResponseDto>>(employeeEntity);

            return employeeResponseDto;
        }

        public async Task<String> DeleteEmployeeAsync(Guid id)
        {
            Employee employee = _unitOfWork.EmployeeRepository.GetByConditionNoTracking(e => e.Id.Equals(id)).FirstOrDefault();
            if (employee == null)
            {
                return null;
            }

            await _unitOfWork.EmployeeRepository.Delete(employee);
            await _unitOfWork.SaveAsync();

            return String.Format(ServerResponseConstants.SUCCESSFULLY_DELETED, "Employee");
        }

        public async Task<String> DeleteEmployeeAsyncRange(List<Guid> id)
        {
            List<Employee> employee = await _unitOfWork.EmployeeRepository.GetByConditionNoTracking(e => id.Contains(e.Id)).ToListAsync();
            if (employee.Count() != id.Count())
            {
                return null;
            }

            await _unitOfWork.EmployeeRepository.DeleteRange(employee);
            await _unitOfWork.SaveAsync();

            return String.Format(ServerResponseConstants.SUCCESSFULLY_DELETED, "Employee");
        }

        public async Task<bool> AnyEmployeeAsync(string email)
        {
            return await _unitOfWork.EmployeeRepository.AnyAsync(e => e.Email.Equals(email));
        }

        public async Task<int> CountAllEmployeeAsync()
        {
            var totalEmployee = await _unitOfWork.EmployeeRepository.CountAllAsync();

            return totalEmployee;
        }
        public async Task<int> CountEmployeeByJobTitleAsync(Guid id)
        {
            var totalEmployeeByJobTitle = await _unitOfWork.EmployeeRepository.CountByConditionAsync(e => e.JobTitleId.Equals(id));

            return totalEmployeeByJobTitle;
        }
        public async Task<int> CountEmployeeByDepartmentAsync(Guid id)
        {
            var totalEmployeeByDepartment = await _unitOfWork.EmployeeRepository.CountByConditionAsync(e => e.DepartmentId.Equals(id));

            return totalEmployeeByDepartment;
        }
    }
}
