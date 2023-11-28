using Microsoft.AspNetCore.Mvc;
using UniversityCourseAndResultManagementSystem.Common;
using UniversityCourseAndResultManagementSystem.Common.QueryParameters;
using UniversityCourseAndResultManagementSystem.DTO.DepartmentDto;
using UniversityCourseAndResultManagementSystem.Service.Contracts;

namespace UniversityCourseAndResultManagementSystem.API.Controllers
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
        public async Task<IActionResult> Get([FromQuery] DepartmentQueryParameters deptParam)
        {
            try
            {
                PagedList<DepartmentResponseDto> deptResults = await _departmentService.GetAllDepartmentAsyncWithParam(deptParam);

                var deptResponse = new
                {
                    deptResults.TotalCount,
                    deptResults.PageSize,
                    deptResults.CurrentPage,
                    deptResults.TotalPages,
                    deptResults.HasNext,
                    deptResults.HasPrevious,
                    data = deptResults
                };

                return Ok(deptResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }

        [HttpGet("{id}", Name = "DepartmentById")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                DepartmentResponseDto deptResponse = await _departmentService.GetDepartmentByIdAsync(id);

                if (deptResponse == null)
                {
                    return NotFound();
                }

                return Ok(deptResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DepartmentCreateDto dept)
        {
            try
            {
                if (dept == null)
                    return BadRequest(string.Format(GlobalConstants.OBJECT_NULL, "Department"));
                else if (await _departmentService.AnyDepartmentAsync(dept.Code))
                    return BadRequest(string.Format(GlobalConstants.OBJECT_Exist, "Department", "Code"));

                DepartmentResponseDto createdDept = await _departmentService.CreateDepartmentAsync(dept);

                return CreatedAtRoute("DepartmentById", new { id = createdDept.Id }, createdDept);
            }
            catch (Exception ex)
            {
                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] DepartmentUpdateDto dept)
        {
            try
            {
                if (dept == null)
                    return BadRequest(string.Format(GlobalConstants.OBJECT_NULL, "Department"));

                DepartmentResponseDto deptResponse = await _departmentService.UpdateDepartmentAsync(dept);
                if (deptResponse == null)
                {
                    return NotFound();
                }

                return Ok(deptResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                string deptResponse = await _departmentService.DeleteDepartmentAsync(id);
                if (deptResponse == null)
                {
                    return NotFound();
                }

                return Ok(new { response = deptResponse });
            }
            catch (Exception ex)
            {
                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }
    }
}
