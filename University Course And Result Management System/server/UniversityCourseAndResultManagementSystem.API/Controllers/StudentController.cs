using Microsoft.AspNetCore.Mvc;
using UniversityCourseAndResultManagementSystem.Common;
using UniversityCourseAndResultManagementSystem.Common.QueryParameters;
using UniversityCourseAndResultManagementSystem.DTO.StudentDto;
using UniversityCourseAndResultManagementSystem.Service.Contracts;

namespace UniversityCourseAndResultManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] StudentQueryParameters studentParam)
        {
            try
            {
                PagedList<StudentResponseDto> studentResults = await _studentService.GetAllStudentAsyncWithParam(studentParam);

                var studentResultstsData = new
                {
                    studentResults.TotalCount,
                    studentResults.PageSize,
                    studentResults.CurrentPage,
                    studentResults.TotalPages,
                    studentResults.HasNext,
                    studentResults.HasPrevious,
                    data = studentResults
                };

                return Ok(studentResultstsData);
            }
            catch (Exception ex)
            {
                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }


        [HttpGet("{id}", Name = "StudentById")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                StudentResponseDto studentResult = await _studentService.GetStudentByIdAsync(id);

                if (studentResult == null)
                {
                    return NotFound();
                }

                return Ok(studentResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StudentCreateDto student)
        {
            try
            {
                if (student == null)
                {
                    return BadRequest(string.Format(GlobalConstants.OBJECT_NULL, "Student"));
                }

                StudentResponseDto createdStudent = await _studentService.CreateStudentAsync(student);

                return CreatedAtRoute("StudentById", new { id = createdStudent.Id }, createdStudent);
            }
            catch (Exception ex)
            {
                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }


        [HttpPut]
        public async Task<IActionResult> Put([FromBody] StudentUpdateDto student)
        {
            try
            {
                if (student == null)
                {
                    return BadRequest(string.Format(GlobalConstants.OBJECT_NULL, "Student"));
                }

                StudentResponseDto studentEntity = await _studentService.UpdateStudentAsync(student);
                if (studentEntity == null)
                {
                    return NotFound();
                }

                return Ok(studentEntity);
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
                string student = await _studentService.DeleteStudentAsync(id);
                if (student == null)
                {
                    return NotFound();
                }

                return Ok(student);
            }
            catch (Exception ex)
            {
                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }
    }
}
