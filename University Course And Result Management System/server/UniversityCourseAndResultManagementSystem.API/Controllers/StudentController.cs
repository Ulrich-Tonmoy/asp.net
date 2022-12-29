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

                var studentResponse = new
                {
                    studentResults.TotalCount,
                    studentResults.PageSize,
                    studentResults.CurrentPage,
                    studentResults.TotalPages,
                    studentResults.HasNext,
                    studentResults.HasPrevious,
                    data = studentResults
                };

                return Ok(studentResponse);
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
                StudentResponseDto studentResponse = await _studentService.GetStudentByIdAsync(id);

                if (studentResponse == null)
                {
                    return NotFound();
                }

                return Ok(studentResponse);
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

                StudentResponseDto studentResponse = await _studentService.UpdateStudentAsync(student);
                if (studentResponse == null)
                {
                    return NotFound();
                }

                return Ok(studentResponse);
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
                string studentResponse = await _studentService.DeleteStudentAsync(id);
                if (studentResponse == null)
                {
                    return NotFound();
                }

                return Ok(new { response = studentResponse });
            }
            catch (Exception ex)
            {
                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }
    }
}
