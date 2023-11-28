using Microsoft.AspNetCore.Mvc;
using UniversityCourseAndResultManagementSystem.Common;
using UniversityCourseAndResultManagementSystem.Common.QueryParameters;
using UniversityCourseAndResultManagementSystem.DTO.CourseDto;
using UniversityCourseAndResultManagementSystem.DTO.TeacherDto;
using UniversityCourseAndResultManagementSystem.Model;
using UniversityCourseAndResultManagementSystem.Service;
using UniversityCourseAndResultManagementSystem.Service.Contracts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UniversityCourseAndResultManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] TeacherQueryParameters teacherParam)
        {
            try
            {
                PagedList<TeacherResponseDto> teacherResults = await _teacherService.GetAllTeacherAsyncWithParam(teacherParam);

                var teacherResultstsData = new
                {
                    teacherResults.TotalCount,
                    teacherResults.PageSize,
                    teacherResults.CurrentPage,
                    teacherResults.TotalPages,
                    teacherResults.HasNext,
                    teacherResults.HasPrevious,
                    data = teacherResults
                };

                return Ok(teacherResultstsData);
            }
            catch (Exception ex)
            {
                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }

        [HttpGet("dept/{id}")]
        public async Task<IActionResult> GetByDept([FromQuery] TeacherQueryParameters teacherParam, Guid id)
        {
            try
            {
                PagedList<TeacherResponseDto> teacherResults = await _teacherService.GetTeacherByDeptAsync(id, teacherParam);

                var teacherResultstsData = new
                {
                    teacherResults.TotalCount,
                    teacherResults.PageSize,
                    teacherResults.CurrentPage,
                    teacherResults.TotalPages,
                    teacherResults.HasNext,
                    teacherResults.HasPrevious,
                    data = teacherResults
                };

                return Ok(teacherResultstsData);
            }
            catch (Exception ex)
            {
                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }


        [HttpGet("{id}", Name = "TeacherById")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                TeacherResponseDto teacherResult = await _teacherService.GetTeacherByIdAsync(id);

                if (teacherResult == null)
                {
                    return NotFound();
                }

                return Ok(teacherResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TeacherCreateDto teacher)
        {
            try
            {
                if (teacher == null)
                {
                    return BadRequest(string.Format(GlobalConstants.OBJECT_NULL, "Teacher"));
                }

                TeacherResponseDto createdTeacher = await _teacherService.CreateTeacherAsync(teacher);

                return CreatedAtRoute("TeacherById", new { id = createdTeacher.Id }, createdTeacher);
            }
            catch (Exception ex)
            {
                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }


        [HttpPut]
        public async Task<IActionResult> Put([FromBody] TeacherUpdateDto teacher)
        {
            try
            {
                if (teacher == null)
                {
                    return BadRequest(string.Format(GlobalConstants.OBJECT_NULL, "Course"));
                }

                TeacherResponseDto teacherEntity = await _teacherService.UpdateTeacherAsync(teacher);
                if (teacherEntity == null)
                {
                    return NotFound();
                }

                return Ok(teacherEntity);
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
                string teacher = await _teacherService.DeleteTeacherAsync(id);
                if (teacher == null)
                {
                    return NotFound();
                }

                return Ok(new { response = teacher });
            }
            catch (Exception ex)
            {
                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }
    }
}
