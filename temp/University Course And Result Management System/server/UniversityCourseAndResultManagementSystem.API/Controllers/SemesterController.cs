using Microsoft.AspNetCore.Mvc;
using UniversityCourseAndResultManagementSystem.Common;
using UniversityCourseAndResultManagementSystem.Common.QueryParameters;
using UniversityCourseAndResultManagementSystem.DTO.SemesterDto;
using UniversityCourseAndResultManagementSystem.Service.Contracts;

namespace UniversityCourseAndResultManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SemesterController : ControllerBase
    {
        private ISemesterService _semesterService;

        public SemesterController(ISemesterService semesterService)
        {
            _semesterService = semesterService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] SemesterQueryParameters semesterParam)
        {
            try
            {
                PagedList<SemesterResponseDto> semesterResults = await _semesterService.GetAllSemesterAsyncWithParam(semesterParam);

                var semesterResultstsData = new
                {
                    semesterResults.TotalCount,
                    semesterResults.PageSize,
                    semesterResults.CurrentPage,
                    semesterResults.TotalPages,
                    semesterResults.HasNext,
                    semesterResults.HasPrevious,
                    data = semesterResults
                };

                return Ok(semesterResultstsData);
            }
            catch (Exception ex)
            {
                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }


        [HttpGet("{id}", Name = "SemesterById")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                SemesterResponseDto semesterResult = await _semesterService.GetSemesterByIdAsync(id);

                if (semesterResult == null)
                {
                    return NotFound();
                }

                return Ok(semesterResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SemesterCreateDto semester)
        {
            try
            {
                if (semester == null)
                {
                    return BadRequest(string.Format(GlobalConstants.OBJECT_NULL, "Semester"));
                }

                SemesterResponseDto createdSemester = await _semesterService.CreateSemesterAsync(semester);

                return CreatedAtRoute("SemesterById", new { id = createdSemester.Id }, createdSemester);
            }
            catch (Exception ex)
            {
                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }


        [HttpPut]
        public async Task<IActionResult> Put([FromBody] SemesterUpdateDto semester)
        {
            try
            {
                if (semester == null)
                {
                    return BadRequest(string.Format(GlobalConstants.OBJECT_NULL, "Semester"));
                }

                SemesterResponseDto semesterEntity = await _semesterService.UpdateSemesterAsync(semester);
                if (semesterEntity == null)
                {
                    return NotFound();
                }

                return Ok(semesterEntity);
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
                string semester = await _semesterService.DeleteSemesterAsync(id);
                if (semester == null)
                {
                    return NotFound();
                }

                return Ok(semester);
            }
            catch (Exception ex)
            {
                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }
    }
}
