using Microsoft.AspNetCore.Mvc;
using UniversityCourseAndResultManagementSystem.Common;
using UniversityCourseAndResultManagementSystem.Common.QueryParameters;
using UniversityCourseAndResultManagementSystem.DTO.AssignedCourseDto;
using UniversityCourseAndResultManagementSystem.Service.Contracts;

namespace UniversityCourseAndResultManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignedCourseController : ControllerBase
    {
        private IAssignedCourseService _assignedCourseService;

        public AssignedCourseController(IAssignedCourseService assignedCourseService)
        {
            _assignedCourseService = assignedCourseService;
        }


        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] AssignedCourseQueryParameters assignedCourseParam)
        {
            try
            {
                PagedList<AssignedCourseResponseDto> assignedCourseResults = await _assignedCourseService.GetAllAssignedCourseAsyncWithParam(assignedCourseParam);

                var assignedCourseResultsData = new
                {
                    assignedCourseResults.TotalCount,
                    assignedCourseResults.PageSize,
                    assignedCourseResults.CurrentPage,
                    assignedCourseResults.TotalPages,
                    assignedCourseResults.HasNext,
                    assignedCourseResults.HasPrevious,
                    data = assignedCourseResults
                };

                return Ok(assignedCourseResultsData);
            }
            catch (Exception ex)
            {

                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }

        [HttpGet("/unassign")]
        public async Task<IActionResult> UnAssignAllCourse([FromQuery] AssignedCourseQueryParameters assignedCourseParam)
        {
            try
            {
                string assignedCourseResultsData = await _assignedCourseService.UnAssignAllCourseAsync(assignedCourseParam);
                if (assignedCourseResultsData == null)
                {
                    return NotFound();
                }

                return Ok(new { response = assignedCourseResultsData });
            }
            catch (Exception ex)
            {

                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }

        [HttpGet("{id}", Name = "AssignedCourseById")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                AssignedCourseResponseDto assignedCourseResult = await _assignedCourseService.GetAssignedCourseByIdAsync(id);

                if (assignedCourseResult == null)
                {
                    return NotFound();
                }

                return Ok(assignedCourseResult);
            }
            catch (Exception ex)
            {

                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AssignedCourseCreateDto assignedCourse)
        {
            try
            {
                if (assignedCourse == null)
                {
                    return BadRequest(string.Format(GlobalConstants.OBJECT_NULL, "AssignedCourse"));
                }

                AssignedCourseResponseDto createdAssignedCourse = await _assignedCourseService.CreateAssignedCourseAsync(assignedCourse);

                return CreatedAtRoute("AssignedCourseById", new { id = createdAssignedCourse.Id }, createdAssignedCourse);
            }
            catch (Exception ex)
            {

                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }

        [HttpPatch("unassign")]
        public async Task<IActionResult> UnAssign()
        {
            try
            {
                string course = await _assignedCourseService.UnAssignCourseAsync();
                return Ok(course);
            }
            catch (Exception ex)
            {
                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] AssignedCourseUpdateDto assignedCourse)
        {
            try
            {
                if (assignedCourse == null)
                {
                    return BadRequest(string.Format(GlobalConstants.OBJECT_NULL, "AssignedCourse"));
                }

                AssignedCourseResponseDto assignedCourseEntity = await _assignedCourseService.UpdateAssignedCourseAsync(assignedCourse);
                if (assignedCourseEntity == null)
                {
                    return NotFound();
                }

                return Ok(assignedCourseEntity);
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
                string assignedCourse = await _assignedCourseService.DeleteAssignedCourseAsync(id);
                if (assignedCourse == null)
                {
                    return NotFound();
                }

                return Ok(new { response = assignedCourse });
            }
            catch (Exception ex)
            {

                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }
    }
}
