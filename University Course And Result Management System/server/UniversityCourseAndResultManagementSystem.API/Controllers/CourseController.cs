using Microsoft.AspNetCore.Mvc;
using UniversityCourseAndResultManagementSystem.Common;
using UniversityCourseAndResultManagementSystem.Common.QueryParameters;
using UniversityCourseAndResultManagementSystem.DTO.CourseDto;
using UniversityCourseAndResultManagementSystem.Service.Contracts;

namespace UniversityCourseAndResultManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }


        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] CourseQueryParameters courseParam)
        {
            try
            {
                PagedList<CourseResponseDto> courseResults = await _courseService.GetAllCourseAsyncWithParam(courseParam);

                var courseResultstsData = new
                {
                    courseResults.TotalCount,
                    courseResults.PageSize,
                    courseResults.CurrentPage,
                    courseResults.TotalPages,
                    courseResults.HasNext,
                    courseResults.HasPrevious,
                    data = courseResults
                };

                return Ok(courseResultstsData);
            }
            catch (Exception ex)
            {
                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }


        [HttpGet("dept/{id}")]
        public async Task<IActionResult> GetByDept([FromQuery] CourseQueryParameters courseParam, Guid id)
        {
            try
            {
                PagedList<CourseResponseDto> courseResults = await _courseService.GetCourseByDeptAsync(id, courseParam);

                var courseResultstsData = new
                {
                    courseResults.TotalCount,
                    courseResults.PageSize,
                    courseResults.CurrentPage,
                    courseResults.TotalPages,
                    courseResults.HasNext,
                    courseResults.HasPrevious,
                    data = courseResults
                };

                return Ok(courseResultstsData);
            }
            catch (Exception ex)
            {
                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }

        [HttpGet("{id}", Name = "CourseById")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                CourseResponseDto courseResult = await _courseService.GetCourseByIdAsync(id);

                if (courseResult == null)
                {
                    return NotFound();
                }

                return Ok(courseResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CourseCreateDto course)
        {
            try
            {
                if (course == null)
                {
                    return BadRequest(string.Format(GlobalConstants.OBJECT_NULL, "Course"));
                }

                CourseResponseDto createdCourse = await _courseService.CreateCourseAsync(course);

                return CreatedAtRoute("CourseById", new { id = createdCourse.Id }, createdCourse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CourseUpdateDto course)
        {
            try
            {
                if (course == null)
                {
                    return BadRequest(string.Format(GlobalConstants.OBJECT_NULL, "Course"));
                }

                CourseResponseDto courseEntity = await _courseService.UpdateCourseAsync(course);
                if (courseEntity == null)
                {
                    return NotFound();
                }

                return Ok(courseEntity);
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
                string course = await _courseService.DeleteCourseAsync(id);
                if (course == null)
                {
                    return NotFound();
                }

                return Ok(new { response = course });
            }
            catch (Exception ex)
            {
                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }
    }
}
