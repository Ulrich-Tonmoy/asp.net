using EmployeeManagementSystem.Common.Constants;
using EmployeeManagementSystem.Common.Pagination;
using EmployeeManagementSystem.Common.QueryParameters;
using EmployeeManagementSystem.DTO.Department;
using EmployeeManagementSystem.Service.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace EmployeeManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDepartments()
        {
            try
            {
                List<DepartmentResponseDto> departmentsResult = await _departmentService.GetAllDepartmentsAsync();

                return Ok(departmentsResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ServerResponseConstants.SERVER_ERROR + ex);
            }
        }

        [HttpGet("params")]
        public async Task<IActionResult> GetAllDepartmentsWithParams([FromQuery] DepartmentQueryParameters deptParameters)
        {
            try
            {
                PagedList<DepartmentResponseDto> departmentsResults = await _departmentService.GetAllDepartmentsAsyncWithParam(deptParameters);

                var departmentsResultsData = new
                {
                    departmentsResults.TotalCount,
                    departmentsResults.PageSize,
                    departmentsResults.CurrentPage,
                    departmentsResults.TotalPages,
                    departmentsResults.HasNext,
                    departmentsResults.HasPrevious,
                    data = departmentsResults
                };

                return Ok(departmentsResultsData);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ServerResponseConstants.SERVER_ERROR + ex);
            }
        }

        [HttpGet("any")]
        public async Task<IActionResult> GetAnyDepartmentExist([FromQuery] string deptName)
        {
            try
            {
                var departmentExist = await _departmentService.AnyDepartmentAsync(deptName);

                return Ok(departmentExist);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ServerResponseConstants.SERVER_ERROR + ex);
            }
        }

        [HttpGet("count")]
        public async Task<IActionResult> GetAllDepartmentsCount()
        {
            try
            {
                var departmentsCount = await _departmentService.CountAllDepartmentAsync();

                return Ok(departmentsCount);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ServerResponseConstants.SERVER_ERROR + ex);
            }
        }

        [HttpGet("{id}", Name = "DepartmentById")]
        public async Task<IActionResult> GetDepartmentById(Guid id)
        {
            try
            {
                DepartmentResponseDto departmentResult = await _departmentService.GetDepartmentByIdAsync(id);

                if (departmentResult == null)
                {
                    return NotFound();
                }

                return Ok(departmentResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ServerResponseConstants.SERVER_ERROR + ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartment([FromBody] DepartmentCreateDto department)
        {
            try
            {
                if (department == null)
                {
                    return BadRequest(String.Format(ServerResponseConstants.OBJECT_NULL, "Department"));
                }

                DepartmentCreateResponseDto createdDepartment = await _departmentService.CreateDepartmentAsync(department);

                return CreatedAtRoute("DepartmentById", new { id = createdDepartment.Id }, createdDepartment);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ServerResponseConstants.SERVER_ERROR + ex);
            }
        }

        [HttpPost("range")]
        public async Task<IActionResult> CreateDepartmentRange([FromBody] List<DepartmentCreateDto> department)
        {
            try
            {
                if (department == null)
                {
                    return BadRequest(String.Format(ServerResponseConstants.OBJECT_NULL, "Department"));
                }

                List<DepartmentCreateResponseDto> createdDepartment = await _departmentService.CreateDepartmentAsyncRange(department);

                var ids = createdDepartment.Select(d => new { deptId = d.Id });
                return CreatedAtRoute("DepartmentById", new { id = ids }, createdDepartment);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ServerResponseConstants.SERVER_ERROR + ex);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDepartment([FromBody] DepartmentUpdateDto department)
        {
            try
            {
                if (department == null)
                {
                    return BadRequest(String.Format(ServerResponseConstants.OBJECT_NULL, "Department"));
                }

                DepartmentUpdateResponseDto departmentEntity = await _departmentService.UpdateDepartmentAsync(department);
                if (departmentEntity == null)
                {
                    return NotFound();
                }

                return Ok(departmentEntity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ServerResponseConstants.SERVER_ERROR + ex);
            }
        }

        [HttpPut("range")]
        public async Task<IActionResult> UpdateDepartmentRange([FromBody] List<DepartmentUpdateDto> department)
        {
            try
            {
                if (department == null)
                {
                    return BadRequest(String.Format(ServerResponseConstants.OBJECT_NULL, "Department"));
                }

                List<DepartmentUpdateResponseDto> departmentEntity = await _departmentService.UpdateDepartmentAsyncRange(department);
                if (departmentEntity == null)
                {
                    return NotFound();
                }

                return Ok(departmentEntity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ServerResponseConstants.SERVER_ERROR + ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(Guid id)
        {
            try
            {
                string department = await _departmentService.DeleteDepartmentAsync(id);
                if (department == null)
                {
                    return NotFound();
                }

                return Ok(department);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ServerResponseConstants.SERVER_ERROR + ex);
            }
        }

        [HttpDelete("range")]
        public async Task<IActionResult> DeleteDepartmentRange(List<Guid> id)
        {
            try
            {
                string department = await _departmentService.DeleteDepartmentAsyncRange(id);
                if (department == null)
                {
                    return NotFound();
                }

                return Ok(department);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ServerResponseConstants.SERVER_ERROR + ex);
            }
        }
    }
}
