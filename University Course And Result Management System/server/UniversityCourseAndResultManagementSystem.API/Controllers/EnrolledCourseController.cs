using Microsoft.AspNetCore.Mvc;
using UniversityCourseAndResultManagementSystem.Common;
using UniversityCourseAndResultManagementSystem.Common.QueryParameters;
using UniversityCourseAndResultManagementSystem.DTO.EnrolledCourseDto;
using UniversityCourseAndResultManagementSystem.Service.Contracts;

namespace UniversityCourseAndResultManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrolledCourseController : ControllerBase
    {
        private IEnrolledCourseService _enrolledCourseService;

        public EnrolledCourseController(IEnrolledCourseService enrolledCourseService)
        {
            _enrolledCourseService = enrolledCourseService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] EnrolledCourseQueryParameters enrolledCourseParam)
        {
            try
            {
                PagedList<EnrolledCourseResponseDto> enrolledCourseResults = await _enrolledCourseService.GetAllEnrolledCourseAsyncWithParam(enrolledCourseParam);

                var enrolledCourseResultstsData = new
                {
                    enrolledCourseResults.TotalCount,
                    enrolledCourseResults.PageSize,
                    enrolledCourseResults.CurrentPage,
                    enrolledCourseResults.TotalPages,
                    enrolledCourseResults.HasNext,
                    enrolledCourseResults.HasPrevious,
                    data = enrolledCourseResults
                };

                return Ok(enrolledCourseResultstsData);
            }
            catch (Exception ex)
            {
                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }

        [HttpGet("{id}", Name = "EnrolledCourseById")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                EnrolledCourseResponseDto enrolledCourseResult = await _enrolledCourseService.GetEnrolledCourseByIdAsync(id);

                if (enrolledCourseResult == null)
                {
                    return NotFound();
                }

                return Ok(enrolledCourseResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EnrolledCourseCreateDto enrolledCourse)
        {
            try
            {
                if (enrolledCourse == null)
                {
                    return BadRequest(string.Format(GlobalConstants.OBJECT_NULL, "EnrolledCourse"));
                }

                EnrolledCourseResponseDto createdEnrolledCourse = await _enrolledCourseService.CreateEnrolledCourseAsync(enrolledCourse);

                return CreatedAtRoute("EnrolledCourseById", new { id = createdEnrolledCourse.Id }, createdEnrolledCourse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] EnrolledCourseUpdateDto enrolledCourse)
        {
            try
            {
                if (enrolledCourse == null)
                {
                    return BadRequest(string.Format(GlobalConstants.OBJECT_NULL, "EnrolledCourse"));
                }

                EnrolledCourseResponseDto enrolledCourseEntity = await _enrolledCourseService.UpdateEnrolledCourseAsync(enrolledCourse);
                if (enrolledCourseEntity == null)
                {
                    return NotFound();
                }

                return Ok(enrolledCourseEntity);
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
                string enrolledCourse = await _enrolledCourseService.DeleteEnrolledCourseAsync(id);
                if (enrolledCourse == null)
                {
                    return NotFound();
                }

                return Ok(enrolledCourse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }
    }
}
