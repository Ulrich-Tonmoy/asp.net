using EmployeeManagementSystem.Common.Constants;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagementSystem.Service.Services.Contracts;
using EmployeeManagementSystem.DTO.Employee;
using EmployeeManagementSystem.Common.QueryParameters;
using EmployeeManagementSystem.Common.Pagination;
using System.Collections.Generic;
using System.Dynamic;

namespace EmployeeManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            try
            {
                List<EmployeeResponseDto> employeesResults = await _employeeService.GetAllEmployeesAsync();

                return Ok(employeesResults);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ServerResponseConstants.SERVER_ERROR + ex);
            }
        }

        [HttpGet("params")]
        public async Task<IActionResult> GetAllEmployeesWithParams([FromQuery] EmployeeQueryParameters empParameters)
        {
            try
            {
                PagedList<ExpandoObject> employeesResults = await _employeeService.GetAllEmployeesAsyncWithParam(empParameters);

                var employeesResultsData = new
                {
                    employeesResults.TotalCount,
                    employeesResults.PageSize,
                    employeesResults.CurrentPage,
                    employeesResults.TotalPages,
                    employeesResults.HasNext,
                    employeesResults.HasPrevious,
                    data = employeesResults
                };

                return Ok(employeesResultsData);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ServerResponseConstants.SERVER_ERROR + ex);
            }
        }

        [HttpGet("any")]
        public async Task<IActionResult> GetAnyEmployeeExist([FromQuery] string email)
        {
            try
            {
                var employeeExist = await _employeeService.AnyEmployeeAsync(email);

                return Ok(employeeExist);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ServerResponseConstants.SERVER_ERROR + ex);
            }
        }

        [HttpGet("count")]
        public async Task<IActionResult> GetAllEmployeesCount()
        {
            try
            {
                int employeesResultsCount = await _employeeService.CountAllEmployeeAsync();

                return Ok(employeesResultsCount);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ServerResponseConstants.SERVER_ERROR + ex);
            }
        }

        [HttpGet("count/dept/{id}")]
        public async Task<IActionResult> GetAllEmployeesCountByDepartment(Guid id)
        {
            try
            {
                int employeesResultsCount = await _employeeService.CountEmployeeByDepartmentAsync(id);

                return Ok(employeesResultsCount);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ServerResponseConstants.SERVER_ERROR + ex);
            }
        }

        [HttpGet("count/job/{id}")]
        public async Task<IActionResult> GetAllEmployeesCountByJobTitle(Guid id)
        {
            try
            {
                int employeesResultsCount = await _employeeService.CountEmployeeByJobTitleAsync(id);

                return Ok(employeesResultsCount);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ServerResponseConstants.SERVER_ERROR + ex);
            }
        }

        [HttpGet("{id}", Name = "EmployeeById")]
        public async Task<IActionResult> GetEmployeeById(Guid id)
        {
            try
            {
                EmployeeResponseDto employeeResult = await _employeeService.GetEmployeeByIdAsync(id);

                if (employeeResult == null)
                {
                    return NotFound();
                }

                return Ok(employeeResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ServerResponseConstants.SERVER_ERROR + ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeCreateDto employee)
        {
            try
            {
                if (employee == null)
                {
                    return BadRequest(string.Format(ServerResponseConstants.OBJECT_NULL, "Employee"));
                }

                EmployeeCreateResponseDto createdEmployee = await _employeeService.CreateEmployeeAsync(employee);

                return CreatedAtRoute("EmployeeById", new { id = createdEmployee.Id }, createdEmployee);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ServerResponseConstants.SERVER_ERROR + ex);
            }
        }

        [HttpPost("range")]
        public async Task<IActionResult> CreateEmployeeRange([FromBody] List<EmployeeCreateDto> employee)
        {
            try
            {
                if (employee == null)
                {
                    return BadRequest(string.Format(ServerResponseConstants.OBJECT_NULL, "Employee"));
                }

                List<EmployeeCreateResponseDto> createdEmployee = await _employeeService.CreateEmployeeAsyncRange(employee);

                var ids = createdEmployee.Select(d => new { empId = d.Id });
                return CreatedAtRoute("EmployeeById", new { id = ids }, createdEmployee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ServerResponseConstants.SERVER_ERROR + ex);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee([FromBody] EmployeeUpdateDto employee)
        {
            try
            {
                if (employee == null)
                {
                    return BadRequest(string.Format(ServerResponseConstants.OBJECT_NULL, "Employee"));
                }

                EmployeeUpdateResponseDto employeeEntity = await _employeeService.UpdateEmployeeAsync(employee);
                if (employeeEntity == null)
                {
                    return NotFound();
                }

                return Ok(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ServerResponseConstants.SERVER_ERROR + ex);
            }
        }

        [HttpPut("range")]
        public async Task<IActionResult> UpdateEmployeeRange([FromBody] List<EmployeeUpdateDto> employee)
        {
            try
            {
                if (employee == null)
                {
                    return BadRequest(string.Format(ServerResponseConstants.OBJECT_NULL, "Employee"));
                }

                List<EmployeeUpdateResponseDto> employeeEntity = await _employeeService.UpdateEmployeeAsyncRange(employee);
                if (employeeEntity == null)
                {
                    return NotFound();
                }

                return Ok(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ServerResponseConstants.SERVER_ERROR + ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            try
            {
                string employee = await _employeeService.DeleteEmployeeAsync(id);
                if (employee == null)
                {
                    return NotFound();
                }

                return Ok(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ServerResponseConstants.SERVER_ERROR + ex);
            }
        }

        [HttpDelete("range")]
        public async Task<IActionResult> DeleteEmployeeRange(List<Guid> id)
        {
            try
            {
                string employee = await _employeeService.DeleteEmployeeAsyncRange(id);
                if (employee == null)
                {
                    return NotFound();
                }

                return Ok(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ServerResponseConstants.SERVER_ERROR + ex);
            }
        }
    }
}
