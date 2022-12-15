using Microsoft.AspNetCore.Mvc;
using UniversityCourseAndResultManagementSystem.Common;
using UniversityCourseAndResultManagementSystem.Common.QueryParameters;
using UniversityCourseAndResultManagementSystem.DTO.ScheduleDto;
using UniversityCourseAndResultManagementSystem.Service.Contracts;

namespace UniversityCourseAndResultManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private IScheduleService _scheduleService;

        public ScheduleController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ScheduleQueryParameters scheduleParam)
        {
            try
            {
                PagedList<ScheduleResponseDto> scheduleResults = await _scheduleService.GetAllScheduleAsyncWithParam(scheduleParam);

                var scheduleResultstsData = new
                {
                    scheduleResults.TotalCount,
                    scheduleResults.PageSize,
                    scheduleResults.CurrentPage,
                    scheduleResults.TotalPages,
                    scheduleResults.HasNext,
                    scheduleResults.HasPrevious,
                    data = scheduleResults
                };

                return Ok(scheduleResultstsData);
            }
            catch (Exception ex)
            {
                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }


        [HttpGet("{id}", Name = "ScheduleById")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                ScheduleResponseDto scheduleResult = await _scheduleService.GetScheduleByIdAsync(id);

                if (scheduleResult == null)
                {
                    return NotFound();
                }

                return Ok(scheduleResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ScheduleCreateDto schedule)
        {
            try
            {
                if (schedule == null)
                {
                    return BadRequest(string.Format(GlobalConstants.OBJECT_NULL, "Schedule"));
                }

                ScheduleResponseDto createdSchedule = await _scheduleService.CreateScheduleAsync(schedule);

                return CreatedAtRoute("ScheduleById", new { id = createdSchedule.Id }, createdSchedule);
            }
            catch (Exception ex)
            {
                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }


        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ScheduleUpdateDto schedule)
        {
            try
            {
                if (schedule == null)
                {
                    return BadRequest(string.Format(GlobalConstants.OBJECT_NULL, "Schedule"));
                }

                ScheduleResponseDto scheduleEntity = await _scheduleService.UpdateScheduleAsync(schedule);
                if (scheduleEntity == null)
                {
                    return NotFound();
                }

                return Ok(scheduleEntity);
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
                string schedule = await _scheduleService.DeleteScheduleAsync(id);
                if (schedule == null)
                {
                    return NotFound();
                }

                return Ok(schedule);
            }
            catch (Exception ex)
            {
                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }
    }
}
